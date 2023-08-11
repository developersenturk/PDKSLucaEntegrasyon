namespace PDKSLucaEntegrasyon.Forms
{
    partial class LicenceEdit
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
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit1.Properties).BeginInit();
            SuspendLayout();
            // 
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(103, 25);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(225, 13);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Lisanlama İçin Destek Aldığınız Firmayı Arayınız.";
            // 
            // labelControl2
            // 
            labelControl2.Location = new System.Drawing.Point(34, 47);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(18, 13);
            labelControl2.TabIndex = 1;
            labelControl2.Text = "Kod";
            // 
            // labelControl3
            // 
            labelControl3.Location = new System.Drawing.Point(34, 75);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(43, 13);
            labelControl3.TabIndex = 1;
            labelControl3.Text = "Karşı kod";
            // 
            // textEdit1
            // 
            textEdit1.Location = new System.Drawing.Point(103, 44);
            textEdit1.Name = "textEdit1";
            textEdit1.Size = new System.Drawing.Size(242, 20);
            textEdit1.TabIndex = 2;
            // 
            // memoEdit1
            // 
            memoEdit1.Location = new System.Drawing.Point(103, 70);
            memoEdit1.Name = "memoEdit1";
            memoEdit1.Size = new System.Drawing.Size(364, 155);
            memoEdit1.TabIndex = 3;
            // 
            // simpleButton1
            // 
            simpleButton1.Location = new System.Drawing.Point(381, 231);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(86, 30);
            simpleButton1.TabIndex = 4;
            simpleButton1.Text = "Kaydet";
            simpleButton1.Click += SimpleButton1_Click;
            // 
            // LicenceEdit
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(482, 266);
            Controls.Add(simpleButton1);
            Controls.Add(memoEdit1);
            Controls.Add(textEdit1);
            Controls.Add(labelControl3);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "LicenceEdit";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "LicenceEdit";
            FormClosing += LicenceEdit_FormClosing;
            Load += LicenceEdit_Load;
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit1.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}