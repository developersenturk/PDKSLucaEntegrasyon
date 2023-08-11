namespace PDKSLucaEntegrasyon
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            textEdit2 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit2.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit2.Properties).BeginInit();
            SuspendLayout();
            // 
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(24, 10);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(10, 13);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Yıl";
            // 
            // dateEdit1
            // 
            dateEdit1.EditValue = null;
            dateEdit1.Location = new System.Drawing.Point(78, 7);
            dateEdit1.Name = "dateEdit1";
            dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit1.Properties.DisplayFormat.FormatString = "yyyy";
            dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEdit1.Properties.EditFormat.FormatString = "yyyy";
            dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEdit1.Properties.MaskSettings.Set("mask", "yyyy");
            dateEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            dateEdit1.Size = new System.Drawing.Size(100, 20);
            dateEdit1.TabIndex = 1;
            // 
            // labelControl2
            // 
            labelControl2.Location = new System.Drawing.Point(24, 36);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(13, 13);
            labelControl2.TabIndex = 0;
            labelControl2.Text = "Ay";
            // 
            // dateEdit2
            // 
            dateEdit2.EditValue = null;
            dateEdit2.Location = new System.Drawing.Point(78, 33);
            dateEdit2.Name = "dateEdit2";
            dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit2.Properties.DisplayFormat.FormatString = "MMMM";
            dateEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEdit2.Properties.EditFormat.FormatString = "MMMM";
            dateEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEdit2.Properties.MaskSettings.Set("mask", "MMMM");
            dateEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            dateEdit2.Size = new System.Drawing.Size(100, 20);
            dateEdit2.TabIndex = 1;
            // 
            // simpleButton1
            // 
            simpleButton1.Location = new System.Drawing.Point(268, 119);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(75, 23);
            simpleButton1.TabIndex = 2;
            simpleButton1.Text = "Kaydet";
            simpleButton1.Click += SimpleButton1_Click;
            // 
            // labelControl3
            // 
            labelControl3.Location = new System.Drawing.Point(24, 62);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(45, 13);
            labelControl3.TabIndex = 0;
            labelControl3.Text = "Kayıt Yeri";
            // 
            // textEdit1
            // 
            textEdit1.Location = new System.Drawing.Point(78, 59);
            textEdit1.Name = "textEdit1";
            textEdit1.Size = new System.Drawing.Size(265, 20);
            textEdit1.TabIndex = 3;
            textEdit1.DoubleClick += TextEdit1_DoubleClick;
            // 
            // labelControl4
            // 
            labelControl4.Location = new System.Drawing.Point(24, 93);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(48, 13);
            labelControl4.TabIndex = 0;
            labelControl4.Text = "Dosya Adı";
            // 
            // textEdit2
            // 
            textEdit2.Location = new System.Drawing.Point(78, 86);
            textEdit2.Name = "textEdit2";
            textEdit2.Size = new System.Drawing.Size(169, 20);
            textEdit2.TabIndex = 4;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(370, 154);
            Controls.Add(textEdit2);
            Controls.Add(textEdit1);
            Controls.Add(simpleButton1);
            Controls.Add(labelControl4);
            Controls.Add(labelControl3);
            Controls.Add(dateEdit2);
            Controls.Add(labelControl2);
            Controls.Add(dateEdit1);
            Controls.Add(labelControl1);
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            IconOptions.Image = (System.Drawing.Image)resources.GetObject("FrmMain.IconOptions.Image");
            MaximizeBox = false;
            Name = "FrmMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Kaletek Luca Entegrasyon";
            Load += FrmMain_Load;
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit2.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit2.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEdit2;
    }
}

