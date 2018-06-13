namespace Meeting3.AdvancedProgrammingPart1
{
    internal class Either<TErrorType, TValueType>
    {
        public Either(TErrorType error)
        {
            Left = error;
        }

        public Either(TValueType value)
        {
            Right = value;
        }

        public TErrorType Left { get; }

        public TValueType Right { get; }
    }
}
