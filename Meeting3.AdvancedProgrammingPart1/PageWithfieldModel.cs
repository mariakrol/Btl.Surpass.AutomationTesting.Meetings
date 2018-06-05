namespace Meeting3.AdvancedProgrammingPart1
{
    internal class PageWithFieldModel
    {
        public PageWithFieldModel()
        {
            FieldFrom15To20 = new NumericField(15, 20);
            FieldFrom1To10 = new NumericField(1, 10);
        }

        private NumericField FieldFrom15To20 { get; }

        private NumericField FieldFrom1To10 { get; }
    }
}
