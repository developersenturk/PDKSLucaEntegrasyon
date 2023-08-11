using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using PDKSLucaEntegrasyon.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PDKSLucaEntegrasyon
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //string constr = "Server = " + SetServer.Default.ServerName + "; Database = " + SetServer.Default.Database + "; Uid = " + SetServer.Default.Username + "; Pwd = " + SetServer.Default.Password + "; ";
            string constr = ConfigurationManager.ConnectionStrings["dataConnect"].ConnectionString;
            string dosya_dizini = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Licence.lis";
            Forms.LicenceEdit licenceEdit = new Forms.LicenceEdit();

            if (File.Exists(dosya_dizini) == true)
            {
                LicenceGet licenceGet = LicenceGet.GetInstance();
                if (licenceEdit.LisansKoduUret() == licenceGet.KarsiKod)
                {
                    Application.Run(new FrmMain());
                }
                else
                {
                    Application.Run(new Forms.LicenceEdit());
                }
            }
            else
            {
                Application.Run(new Forms.LicenceEdit());
            }

        }
        public static string GetConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["dataConnect"].ConnectionString;
            }
        }
    }
}
