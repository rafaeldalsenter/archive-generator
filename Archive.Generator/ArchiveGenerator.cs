using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Archive.Generator
{
    public class ArchiveGenerator<T>
        where T : IBaseArchiveGenerator
    {
        public bool GenerateFile(string pathFile, string nameFile, ICollection<T> objects)
        {
            File.WriteAllLines($"{pathFile}\\{nameFile}", objects.Select(x => x.GenerateString()));





            return true;
        }
    }
}
