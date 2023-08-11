using DevExpress.XtraEditors;
using PDKSLucaEntegrasyon.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace PDKSLucaEntegrasyon.Forms
{
    public partial class LicenceEdit : DevExpress.XtraEditors.XtraForm
    {
        readonly EncryptDecrypt encryptDecrypt = EncryptDecrypt.GetInstance();
        readonly TraceLog traceLog = new();
        public LicenceEdit()
        {
            InitializeComponent();
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                encryptDecrypt.Decrypt(textEdit1.Text, encryptDecrypt.Password);
                string dosya_dizini = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Licence.lis";
                File.Delete(dosya_dizini);
                traceLog.Loglama(dosya_dizini, memoEdit1.Text);
                XtraMessageBox.Show("Lisan İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hatalı Lisans", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        public string LisansKoduUret()
        {
            string lisanskodu = "";
            ManagementObjectSearcher MOS = new("Select * from Win32_OperatingSystem");
            foreach (ManagementObject mo in MOS.Get().Cast<ManagementObject>())
            {
                lisanskodu = encryptDecrypt.Encrypt(mo["SerialNumber"].ToString());
            }
            return lisanskodu;
        }

        private void LicenceEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LicenceEdit_Load(object sender, EventArgs e)
        {
            textEdit1.Text = LisansKoduUret();
        }
    }
}