namespace Meeting3.AdvancedProgrammingPart1.ValidationWithEither
{
    internal class PageWithFieldModel
    {
        public PageWithFieldModel()
        {
            FieldFrom15To20 = new NumericField(15, 20);
        }

        public Either<string, int> FillField(int value)
        {
            FieldFrom15To20.Fill(value);

            if (!string.IsNullOrEmpty(FieldFrom15To20.GetValidationMessage()))
            {
                return new Either<string, int> (FieldFrom15To20.GetValidationMessage());
            }

            return new Either<string, int> (FieldFrom15To20.Text);
        }

        private NumericField FieldFrom15To20 { get; }
    }
}
