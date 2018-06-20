namespace Meeting4.AdvancedProgrammingPart2.BuiltinDelegatesSamples
{
    internal delegate TOtherObject ConvertToOtherObject<in TObject, out TOtherObject>(TObject @object);
}