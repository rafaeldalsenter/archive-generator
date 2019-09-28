using System;
using System.Collections.Generic;
using System.Text;

namespace Archive.Generator
{
    public class ArchiveGenerator<T>
        where T : IBaseArchiveGenerator
    {
        public bool GenerateFile(string pathFile, string nameFile, ICollection<T> objects)
        {
            // TODO Dar um generateString() de todos os objects

            return false;
        }
    }
}