using System.Collections.Generic;
using System.Linq;

public class ExtraFunctions: Callback
{
    public IReadOnlyList<ComputerFunctions> Value;

    public ExtraFunctions(IEnumerable<ComputerFunctions> extraFunctions)
    {
        Value = extraFunctions.ToList();
    }
}
