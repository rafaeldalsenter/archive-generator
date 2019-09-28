using Archive.Generator.ConverterValues;
using System.Linq;

namespace Archive.Generator
{
    public abstract class BaseArchiveGenerator : IBaseArchiveGenerator
    {
        public string GenerateString()
        {
            var convertValues = GetType()
                .GetProperties()
                .Select(x => new ConverterValueChain().Get(x.GetValue(this, null), x.GetCustomAttributes(false)))
                .ToList();

            // TODO Order by attribute

            // TODO convertValues concatenates using separator or no

            throw new System.NotImplementedException();
        }
    }
}