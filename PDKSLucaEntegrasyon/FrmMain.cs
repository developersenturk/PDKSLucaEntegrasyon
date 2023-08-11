using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using PDKSLucaEntegrasyon.DataAccess;
using ClosedXML.Excel;
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace PDKSLucaEntegrasyon
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm

    {
        TraceLog traceLog = new TraceLog();
        readonly DatabaseManager db = new();
        public FrmMain()
        {
            InitializeComponent();
            dateEdit1.EditValue = DateTime.Now;
            dateEdit2.EditValue = DateTime.Now;
            //textEdit1.Text = "D:\\PROJECTS\\PDKSLucaEntegrasyon\\PDKSLucaEntegrasyon\\bin\\Debug\\net7.0-windows\\sample.xls";

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!db.Connectstatus)
            {
                Application.ExitThread();
            }
           
        }
        public void log(string msg)
        {
            traceLog.Loglama(Directory.GetCurrentDirectory() + "\\general.log", DateTime.Now + "--" + msg);
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                XtraMessageBox.Show("Kayıt yeri Boş olamaz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (string.IsNullOrEmpty(textEdit2.Text))
            {
                XtraMessageBox.Show("Lütfen bir dosya adı giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string saveFilePath = "";
            using (XLWorkbook workbook = new(Directory.GetCurrentDirectory() + "\\Sablon.xlsx"))
            {
                var worksheet = workbook.Worksheet("Sheet1");
                worksheet.Range("A1:AQ1").Value = $"{dateEdit2.Text}/{dateEdit1.Text} ayı Puantaj Listesi";

                LoadDays(worksheet);
                LoadPuantaj(worksheet);
                LoadExtra(worksheet);

                saveFilePath = textEdit1.Text + "\\" + textEdit2.Text + ".xls";
                workbook.SaveAs(saveFilePath + "x");
                ConvertXLSX_XLS(saveFilePath);
            }
            //
        }
        public static void ConvertXLSX_XLS(string file)
        {
            FileInfo fi = new(file);
            SpreadsheetControl spreadsheet = new();
            spreadsheet.LoadDocument(file + "x");
            spreadsheet.SaveDocument(fi.FullName, DevExpress.Spreadsheet.DocumentFormat.Xls);

            File.Delete(file + "x");
            Process.Start(new ProcessStartInfo { FileName = file, UseShellExecute = true });
        }
        private void LoadDays(IXLWorksheet ws)
        {
            int dayCount = DateTime.DaysInMonth(dateEdit1.DateTime.Year, dateEdit2.DateTime.Month);

            for (int i = 6; i <= 36; i++)
            {
                ws.Cell(8, i).Value = "";
            }

            int day = 0;
            for (int i = 6; i <= 36; i++)
            {
                day++;
                if (day > dayCount)
                {
                    break;
                }
                ws.Cell(8, i).Value = day;
            }

            day = 0;
            for (int i = 6; i <= 36; i++)
            {
                ws.Cell(9, i).Value = "";
            }

            for (int i = 6; i <= 36; i++)
            {
                day++;
                if (day > dayCount)
                {
                    break;
                }
                DateTime date = new(dateEdit1.DateTime.Year, dateEdit2.DateTime.Month, day);
                ws.Cell(9, i).Value = date.ToString("ddd");
            }
        }

        private void LoadPuantaj(IXLWorksheet ws)
        {
            List<PuantajModel> models = GetParameterList();
            DbResult res = db.Execute("select id,ad,soyad,kimlikno,isegiristarihi,istencikistarihi from personel where year(istencikistarihi)>="+dateEdit1.DateTime.Year+" and month(istencikistarihi) >= " + dateEdit2.DateTime.Month + " and year(isegiristarihi) <= " + dateEdit1.DateTime.Year + " and month(isegiristarihi) <= " + dateEdit2.DateTime.Month + " or year(isegiristarihi) <= " + dateEdit1.DateTime.Year + " and month(isegiristarihi) <= " + dateEdit2.DateTime.Month + " and istencikistarihi is null order by ad asc");
            if (res != null)
            {
                int startRow = 10;
                for (int i = 0; i < res.Data.Rows.Count; i++)
                {
                    int CalGun = 0;
                    int IzinGun = 0;
                    int GunTop = 0;
                    int EksikGun = 0;

                    ws.Cell("A" + startRow).Value = (i + 1).ToString();
                    ws.Cell("A" + startRow).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    ws.Cell("B" + startRow).Value = (res.Data.Rows[i]["ad"].ToString() + " " + res.Data.Rows[i]["soyad"].ToString()).ToUpper();
                    ws.Cell("C" + startRow).Value = res.Data.Rows[i]["kimlikno"].ToString().ToUpper();
                    ws.Cell("D" + startRow).Value = Convert.ToDateTime(res.Data.Rows[i]["isegiristarihi"]).ToString("dd/MM/yyyy");
                    ws.Cell("E" + startRow).Value = !string.IsNullOrEmpty(res.Data.Rows[i]["istencikistarihi"].ToString()) ? Convert.ToDateTime(res.Data.Rows[i]["istencikistarihi"]).ToString("dd/MM/yyyy") : "";
                    if (res.Data.Rows[i]["kimlikno"].ToString() == "56776380518")
                    {

                    }

                    DbResult resPuantaj = db.Execute("SELECT tarih,aciklama FROM pts_puantaj WHERE YEAR(tarih) = " + dateEdit1.DateTime.Year + " AND MONTH(tarih) = " + dateEdit2.DateTime.Month + " AND personelid = " + res.Data.Rows[i]["id"] + " order by tarih asc;");
                    if (resPuantaj.Status == 1)
                    {
                        for (int k = 0; k < resPuantaj.Data.Rows.Count; k++)
                        {
                            DataRow row = resPuantaj.Data.Rows[k];
                            DateTime date = Convert.ToDateTime(row["tarih"].ToString());
                            for (int j = 6; j <= 36; j++)
                            {
                                if (ws.Cell(8, j).Value.ToString().Trim() == date.Day.ToString())
                                {
                                    string symbol = models.Where(x => x.Text.Contains(row["aciklama"].ToString().Trim())).Select(x => x.Symbol).FirstOrDefault();
                                    string cell = ws.Cell(startRow, j).Address.ToString();
                                    ws.Cell(cell).Value = string.IsNullOrEmpty(symbol) ? "-" : symbol;
                                    ws.Cell(cell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    switch (symbol)
                                    {
                                        case "N":
                                            ws.Cell(cell).Style.Fill.BackgroundColor = ws.Cell("Q3").Style.Fill.BackgroundColor; // Color index for green
                                            CalGun++; GunTop++;
                                            break;
                                        case "T":
                                            ws.Cell(cell).Style.Fill.BackgroundColor = ws.Cell("V3").Style.Fill.BackgroundColor; // Color index for yellow
                                            GunTop++;
                                            break;
                                        case "H":
                                            ws.Cell(cell).Style.Fill.BackgroundColor = ws.Cell("AA3").Style.Fill.BackgroundColor; // Color index for red
                                            GunTop++;
                                            break;
                                        case "İ":
                                            ws.Cell(cell).Style.Fill.BackgroundColor = ws.Cell("AF3").Style.Fill.BackgroundColor; // Color index for light blue
                                            IzinGun++; GunTop++;
                                            break;
                                        case "G":
                                            ws.Cell(cell).Style.Fill.BackgroundColor = ws.Cell("AK3").Style.Fill.BackgroundColor; // Color index for light orange
                                            CalGun++; GunTop++;
                                            break;
                                        case "R":
                                            ws.Cell(cell).Style.Fill.BackgroundColor = ws.Cell("Q4").Style.Fill.BackgroundColor; // Color index for green
                                            EksikGun++; GunTop++;
                                            break;
                                        case "E":
                                            ws.Cell(cell).Style.Fill.BackgroundColor = ws.Cell("V4").Style.Fill.BackgroundColor; // Color index for yellow
                                            EksikGun++; GunTop++;
                                            break;
                                        case "Y":
                                            ws.Cell(cell).Style.Fill.BackgroundColor = ws.Cell("AA4").Style.Fill.BackgroundColor; // Color index for red
                                            CalGun++; GunTop++;
                                            break;
                                        case "S":
                                            ws.Cell(cell).Style.Fill.BackgroundColor = ws.Cell("AF4").Style.Fill.BackgroundColor; // Color index for light blue
                                            GunTop++;
                                            break;
                                        case "O":
                                            ws.Cell(cell).Style.Fill.BackgroundColor = ws.Cell("AK4").Style.Fill.BackgroundColor; // Color index for light orange
                                            CalGun++;
                                            break;
                                        case "K":
                                            ws.Cell(cell).Style.Fill.BackgroundColor = ws.Cell("Q5").Style.Fill.BackgroundColor; // Color index for green
                                            CalGun++; GunTop++;
                                            break;
                                        case "C":
                                            ws.Cell(cell).Style.Fill.BackgroundColor = ws.Cell("AA6").Style.Fill.BackgroundColor; // Color index for red
                                            CalGun++; GunTop++;
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                }
                                else
                                {

                                }
                            }
                        }
                        ws.Cell("AK" + startRow).Value = CalGun.ToString();
                        ws.Cell("AM" + startRow).Value = IzinGun.ToString();
                        ws.Cell("AN" + startRow).Value = GunTop.ToString();
                        ws.Cell("AO" + startRow).Value = EksikGun.ToString();

                        ws.Cell("AK" + startRow).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("AL" + startRow).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("AM" + startRow).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("AN" + startRow).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell("AO" + startRow).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        if (EksikGun == 0 && GunTop == 31)
                        {
                            ws.Cell("AL" + startRow).Value = "30";
                        }
                        else
                        {
                            ws.Cell("AL" + startRow).Value = (GunTop - EksikGun).ToString();
                        }
                    }
                    startRow++;
                }
            }
        }
        private void LoadExtra(IXLWorksheet ws)
        {
            List<KazanKesintiModel> models = GetKazanKesintiParameters();
            IXLRange range = ws.Range("AQ7:BM7");
            DbResult res = db.Execute("select id from personel where year(istencikistarihi)>=" + dateEdit1.DateTime.Year + " and month(istencikistarihi) >= " + dateEdit2.DateTime.Month + " and year(isegiristarihi) <= " + dateEdit1.DateTime.Year + " and month(isegiristarihi) <= " + dateEdit2.DateTime.Month + " or year(isegiristarihi) <= " + dateEdit1.DateTime.Year + " and month(isegiristarihi) <= " + dateEdit2.DateTime.Month + " and istencikistarihi is null order by ad asc");
            int startRow = 10;
            for (int i = 0; i < res.Data.Rows.Count; i++)
            {
                int personelid = Convert.ToInt32(res.Data.Rows[i][0]);
                DbResult resExtra = db.Execute("select * from pts_puantajtoplam where personelid=" + personelid + " and year(bittarih)=" + dateEdit1.DateTime.Year + " and MONTH(bittarih)=" + dateEdit2.DateTime.Month + " and year(bastarih)=" + dateEdit2.DateTime.Year + " and MONTH(bastarih)=" + dateEdit2.DateTime.Month + " order by id desc limit 1");
                if (resExtra.Data.Rows.Count == 0)
                {
                    startRow++;
                    continue;
                }

                for (int j = 0; j < models.Count; j++)
                {
                    if (resExtra.Data != null)
                    {
                        var deger = resExtra.Data.Rows[0][models[j].Pdks];
                        IXLCell valueExists = range.Cells().FirstOrDefault(cell => cell.Value.ToString() == models[j].Luca);
                        if (valueExists != null)
                        {
                            int columnIndex = valueExists.Address.ColumnNumber;
                            ws.Cell(startRow, columnIndex).Value = deger.ToString();
                        }
                    }
                }
                startRow++;
            }
        }

        private static List<PuantajModel> GetParameterList()
        {
            string filepath = Directory.GetCurrentDirectory() + "\\Parametre.json";
            string icerik = "";
            using (StreamReader sr = new(filepath))
            {
                icerik = sr.ReadToEnd();
            }
            List<PuantajModel> model = JsonConvert.DeserializeObject<List<PuantajModel>>(icerik);
            return model;
        }
        private static List<KazanKesintiModel> GetKazanKesintiParameters()
        {
            string filepath = Directory.GetCurrentDirectory() + "\\KazanKesintiParametre.json";
            string icerik = "";
            using (StreamReader sr = new(filepath))
            {
                icerik = sr.ReadToEnd();
            }
            List<KazanKesintiModel> model = JsonConvert.DeserializeObject<List<KazanKesintiModel>>(icerik);
            return model;
        }

        private void TextEdit1_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textEdit1.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
