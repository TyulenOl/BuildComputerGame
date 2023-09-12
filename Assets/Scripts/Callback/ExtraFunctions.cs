using System.Collections.Generic;
using System.Linq;

public class ExtraFunctions: Callback
{
    public IReadOnlyList<ComputerFunctions> Value;

    public ComputerPart Part { get; }

    public ExtraFunctions(ComputerPart part, IEnumerable<ComputerFunctions> extraFunctions)
    {
        Value = extraFunctions.ToList();
        Part = part;
    }
}
