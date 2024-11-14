namespace FormsGrundlagen
{
    partial class frm_MainApp
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
            this.btt_cancel = new System.Windows.Forms.Button();
            this.btt_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_mainInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btt_cancel
            // 
            this.btt_cancel.Location = new System.Drawing.Point(78, 170);
            this.btt_cancel.Name = "btt_cancel";
            this.btt_cancel.Size = new System.Drawing.Size(75, 23);
            this.btt_cancel.TabIndex = 0;
            this.btt_cancel.Text = "Abbruch";
            this.btt_cancel.UseVisualStyleBackColor = true;
            this.btt_cancel.Click += new System.EventHandler(this.btt_cancel_Click);
            // 
            // btt_save
            // 
            this.btt_save.Location = new System.Drawing.Point(288, 170);
            this.btt_save.Name = "btt_save";
            this.btt_save.Size = new System.Drawing.Size(75, 23);
            this.btt_save.TabIndex = 1;
            this.btt_save.Text = "Speichern";
            this.btt_save.UseVisualStyleBackColor = true;
            this.btt_save.Click += new System.EventHandler(this.btt_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name: ";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(122, 96);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(241, 20);
            this.txt_name.TabIndex = 3;
            // 
            // lbl_mainInfo
            // 
            this.lbl_mainInfo.AutoSize = true;
            this.lbl_mainInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mainInfo.Location = new System.Drawing.Point(34, 25);
            this.lbl_mainInfo.Name = "lbl_mainInfo";
            this.lbl_mainInfo.Size = new System.Drawing.Size(278, 24);
            this.lbl_mainInfo.TabIndex = 4;
            this.lbl_mainInfo.Text = "Hello World Application V1.0";
            // 
            // frm_MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 274);
            this.Controls.Add(this.lbl_mainInfo);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btt_save);
            this.Controls.Add(this.btt_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frm_MainApp";
            this.Text = "Grundlagen Forms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btt_cancel;
        private System.Windows.Forms.Button btt_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_mainInfo;
    }
}

