namespace Meeting4.AdvancedProgrammingPart2.BuildinDelegatesSamples
{
    internal delegate TOtherObject ConvertToOtherObject<in TObject, out TOtherObject>(TObject @object);
}