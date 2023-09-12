
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create ComputerPart", fileName = "New ComputerPart", order = 50)]
public class ComputerPart: ScriptableObject
{
    [SerializeField] private string partName;
    [SerializeField] private Sprite sprite;
    
    [SerializeField] private ComputerPartType myType;
    [SerializeField] private List<ComputerFunctions> myFunctions;

    public ComputerPartType Type => myType;
    public IReadOnlyCollection<ComputerFunctions> Functions => myFunctions;

    public string Name => partName;

    public Sprite Sprite => sprite;
}