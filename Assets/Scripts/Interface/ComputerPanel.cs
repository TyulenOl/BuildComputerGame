namespace Interface
{
    public class ComputerPanel : PartsPanel
    {
        public void AddPart(ComputerPart computerPart)
        {
            Computer.Instance.AddPart(computerPart, out var callback);
        }

        public override void RemovePart(CompPartInfo computerPartInfo)
        {
            Computer.Instance.RemovePart(computerPartInfo.ComputerPartData);
        }

        public override void AddVisualPart(CompPartInfo compPartInfo)
        {
            base.AddVisualPart(compPartInfo);
            if (Computer.Instance != null)
            {
                AddPart(compPartInfo.ComputerPartData);
            }
        }
    }
}