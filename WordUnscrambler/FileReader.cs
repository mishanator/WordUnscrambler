using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class FileReader
    {
        public string[] Read(string fileName)
        {
            string[] contents;
            try
            {
                contents = File.ReadAllLines(fileName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return contents;
        }
    }
}
