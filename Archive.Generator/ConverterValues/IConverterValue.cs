namespace Archive.Generator.ConverterValues
{
    internal interface IConverterValue
    {
        string GetString(object value, object[] attributes);
    }
}