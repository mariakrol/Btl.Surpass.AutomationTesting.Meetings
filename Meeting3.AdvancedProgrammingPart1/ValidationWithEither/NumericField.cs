namespace Meeting3.AdvancedProgrammingPart1.ValidationWithEither
{
    internal class NumericField
    {
        public NumericField(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        private int MinValue { get; }

        private int MaxValue { get; }

        public int Text { get; set; }

        private string ValidationMessage { get; set; }

        public void Fill(int value)
        {
            Text = 0;

            bool isValueValid = Validate(value, out string message);
            ValidationMessage = message;

            if (isValueValid)
            {
                Text = value;
            }
        }

        public string GetValidationMessage() => ValidationMessage;

        private bool Validate(int value, out string validationMessage)
        {
            validationMessage = string.Empty;
            
            if (MinValue <= value && value <= MaxValue)
            {
                return true;
            }
            validationMessage = value < MinValue ? "Value is smaller than minimum" : "Value is bigger than max value";

            return false;
        }
    }
}