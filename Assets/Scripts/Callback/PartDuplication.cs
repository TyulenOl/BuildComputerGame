public class PartDuplication: Callback
{
    public readonly ComputerPart ExistingPart;
    public readonly ComputerPart ExtraPart;

    public PartDuplication(ComputerPart existingPart, ComputerPart extraPart)
    {
        ExistingPart = existingPart;
        ExtraPart = extraPart;
    }
}