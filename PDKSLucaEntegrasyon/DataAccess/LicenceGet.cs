using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDKSLucaEntegrasyon.DataAccess
{
    public class LicenceGet
    {
        readonly EncryptDecrypt encryptDecrypt = EncryptDecrypt.GetInstance();

        public string LisansKodu { get; set; }
        public string LisansSahibi { get; set; }
        public string KarsiKod { get; set; }
        public string GecerlilikTarihi { get; set; }
        public string TerminalAdedi { get; set; }

        private static LicenceGet _instance;
        private LicenceGet() { LicenceRead(); }
        public static LicenceGet GetInstance() { if (_instance == null) { _instance = new LicenceGet(); } return _instance; }
        public void LicenceRead()
        {
            string dosya_dizini = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Licence.lis";
            StreamReader sr = new StreamReader(dosya_dizini);
            string Veri = sr.ReadLine();
            LisansKodu = Veri;
            sr.Close();
            LicenceAyristir(encryptDecrypt.Decrypt(Veri, encryptDecrypt.Password));
        }
        public void LicenceAyristir(string metin)
        {
            string[] sifre = metin.Split('-');
            LisansSahibi = sifre[0];
            KarsiKod = sifre[1];
            GecerlilikTarihi = sifre[2];
            TerminalAdedi = sifre[3];
        }
    }
}
