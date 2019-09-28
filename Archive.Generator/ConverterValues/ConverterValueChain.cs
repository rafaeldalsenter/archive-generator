using Archive.Generator.ConverterValues.Chain;

namespace Archive.Generator.ConverterValues
{
    internal class ConverterValueChain
    {
        private readonly ConverterValueBase _converterTypeDateTime;
        private readonly ConverterValueBase _converterTypeDecimal;
        private readonly ConverterValueBase _converterTypeInt;
        private readonly ConverterValueBase _converterTypeString;

        internal ConverterValueChain()
        {
            _converterTypeDateTime = new ConverterValueDateTime();
            _converterTypeDecimal = new ConverterValueDecimal();
            _converterTypeInt = new ConverterValueInt();
            _converterTypeString = new ConverterValueString();

            _converterTypeDateTime.SetNext(_converterTypeDecimal);
            _converterTypeDecimal.SetNext(_converterTypeInt);
            _converterTypeInt.SetNext(_converterTypeString);
        }

        internal string Get(object value, object[] attributes) => _converterTypeDateTime.GetString(value, attributes);
    }
}