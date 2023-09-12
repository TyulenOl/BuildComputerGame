using System.Collections.Generic;
using System.Linq;

public class FunctionDuplication: Callback
{
    public IReadOnlyList<ComputerFunctions> Value;
    public ComputerPart ComputerPart { get; }

    public FunctionDuplication(ComputerPart part, IEnumerable<ComputerFunctions> duplicatedFunctions)
    {
        ComputerPart = part;
        Value = duplicatedFunctions.ToList();
    }
}