namespace Meeting3.AdvancedProgrammingPart1
{
    internal class Convertor
    {
        public int ConvertDoubleToInt(double sourceValue)
        {
            if (sourceValue > int.MaxValue || sourceValue < int.MinValue)
            {
                //error?
            }

            return (int) sourceValue;
        }
    }
}
