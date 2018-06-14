namespace Meeting3.AdvancedProgrammingPart1
{
    internal static class Swapper
    {

        public static void Swap<TObject>(ref TObject left, ref TObject right)
        {
            TObject temp = left;
            left = right;
            right = temp;
        }
    }
}
