namespace ScreenFighter
{
    partial class SettingsForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxFull = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFull = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.comboBoxImageFormat = new System.Windows.Forms.ComboBox();
            this.labelImageFormat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(173, 99);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(254, 99);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxFull
            // 
            this.textBoxFull.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxFull.Location = new System.Drawing.Point(15, 25);
            this.textBoxFull.Name = "textBoxFull";
            this.textBoxFull.ReadOnly = true;
            this.textBoxFull.Size = new System.Drawing.Size(283, 20);
            this.textBoxFull.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Path for fullscreen screenshots:";
            // 
            // buttonFull
            // 
            this.buttonFull.Location = new System.Drawing.Point(304, 23);
            this.buttonFull.Name = "buttonFull";
            this.buttonFull.Size = new System.Drawing.Size(25, 23);
            this.buttonFull.TabIndex = 4;
            this.buttonFull.Text = "...";
            this.buttonFull.UseVisualStyleBackColor = true;
            this.buttonFull.Click += new System.EventHandler(this.buttonFull_Click);
            // 
            // comboBoxImageFormat
            // 
            this.comboBoxImageFormat.FormattingEnabled = true;
            this.comboBoxImageFormat.Location = new System.Drawing.Point(15, 64);
            this.comboBoxImageFormat.Name = "comboBoxImageFormat";
            this.comboBoxImageFormat.Size = new System.Drawing.Size(121, 21);
            this.comboBoxImageFormat.TabIndex = 5;
            // 
            // labelImageFormat
            // 
            this.labelImageFormat.AutoSize = true;
            this.labelImageFormat.Location = new System.Drawing.Point(12, 48);
            this.labelImageFormat.Name = "labelImageFormat";
            this.labelImageFormat.Size = new System.Drawing.Size(71, 13);
            this.labelImageFormat.TabIndex = 6;
            this.labelImageFormat.Text = "Image format:";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(342, 135);
            this.Controls.Add(this.labelImageFormat);
            this.Controls.Add(this.comboBoxImageFormat);
            this.Controls.Add(this.buttonFull);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFull);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxFull;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFull;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox comboBoxImageFormat;
        private System.Windows.Forms.Label labelImageFormat;
    }
}