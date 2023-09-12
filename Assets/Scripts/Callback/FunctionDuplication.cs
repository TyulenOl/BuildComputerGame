using System.Collections.Generic;
using System.Linq;

public class FunctionDuplication: Callback
{
    public IReadOnlyList<ComputerFunctions> Value;

    public FunctionDuplication(IEnumerable<ComputerFunctions> duplicatedFunctions)
    {
        Value = duplicatedFunctions.ToList();
    }
}