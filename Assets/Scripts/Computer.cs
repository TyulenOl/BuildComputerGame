using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class Computer: MonoBehaviour
{
    public static Computer Instance { get; private set; }
    [SerializeField] private List<ComputerFunctions> requiredFunctions;
    /// <summary>
    /// в этот список можно добавлять части "по-умолчанию" вроде монитора, которые добавятся автоматически
    /// </summary>
    [SerializeField] private List<ComputerPart> defaultsParts;
    
    private Dictionary<ComputerPartType, ComputerPart> addedParts;
    private HashSet<ComputerFunctions> addedFunctionsSet;
    private HashSet<ComputerFunctions> requiredFunctionsSet;

    public UnityEvent<HashSet<ComputerFunctions>> computerFunctionsChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Дублирование компьютеров!");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        addedParts = new Dictionary<ComputerPartType, ComputerPart>();
        addedFunctionsSet = new HashSet<ComputerFunctions>();
        requiredFunctionsSet = new HashSet<ComputerFunctions>(requiredFunctions);
        
        foreach (var part in defaultsParts)
            AddPart(part, out var callback);
    }

    public void AddPart([NotNull] ComputerPart part, out Callback callback)
    {
        if (part == null) throw new ArgumentNullException(nameof(part));
        callback = null;
        
        if (addedParts.TryGetValue(part.Type, out var addedPart))
        {
            callback = new PartDuplication(addedPart, part);
            return;
        }

        // если хотя бы одна функция уже есть
        if (part.Functions.Any(x => addedFunctionsSet.Contains(x)))
        {
            callback = new FunctionDuplication(part.Functions.Intersect(addedFunctionsSet));
            return;
        }
        
        // eсли есть лишняя функция
        if (part.Functions.Any(x => !requiredFunctionsSet.Contains(x)))
        {
            callback = new ExtraFunctions(part.Functions.Except(requiredFunctionsSet));
            Add();
            return;
        }

        Add();
        
        void Add()
        {
            addedParts[part.Type] = part;
            foreach (var function in part.Functions)
            {
                addedFunctionsSet.Add(function);
            }
            computerFunctionsChanged.Invoke(addedFunctionsSet);
        }
    }

    public bool RemovePart([NotNull] ComputerPart part)
    {
        if (part == null) throw new ArgumentNullException(nameof(part));

        if (addedParts.TryGetValue(part.Type, out var value) && value.Equals(part))
        {
            addedParts.Remove(part.Type);
            foreach (var function in part.Functions)
                addedFunctionsSet.Remove(function);
            computerFunctionsChanged.Invoke(addedFunctionsSet);
            return true;
        }

        return false;
    }

    public IEnumerable<ComputerFunctions> GetNeededFunctions()
    {
        return requiredFunctionsSet.Except(addedFunctionsSet);
    }
    
    public IEnumerable<ComputerFunctions> GetExtraFunctions()
    {
        return addedFunctionsSet.Except(requiredFunctionsSet);
    }
}