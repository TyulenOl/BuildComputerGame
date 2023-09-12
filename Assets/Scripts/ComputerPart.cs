
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create ComputerPart", fileName = "New ComputerPart", order = 50)]
public class ComputerPart: ScriptableObject
{
    [SerializeField] private ComputerPartType myType;
    [SerializeField] private List<ComputerFunctions> myFunctions;

    public ComputerPartType Type => myType;
    public IReadOnlyCollection<ComputerFunctions> Functions => myFunctions;
}