using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDKSLucaEntegrasyon.DataAccess
{
    public class TraceLog
    {
        public int Loglama(string DosyaYolu, string Metin)
        {
            try
            {
                FileStream fs = new FileStream(DosyaYolu, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(Metin);
                sw.Flush();
                sw.Close();
                return 1;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }
    }
}
