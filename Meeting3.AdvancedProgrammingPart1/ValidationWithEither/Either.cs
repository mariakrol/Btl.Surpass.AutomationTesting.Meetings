namespace Meeting3.AdvancedProgrammingPart1.ValidationWithEither
{
    internal class Either<TErrorType, TValueType>
    {
        public Either(TErrorType error)
        {
            Error = error;
        }

        public Either(TValueType value)
        {
            Result = value;
        }

        public TErrorType Error { get; }

        public TValueType Result { get; }
    }
}
