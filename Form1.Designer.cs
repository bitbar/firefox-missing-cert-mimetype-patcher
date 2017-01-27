using System.Collections.Generic;
using System.Windows.Forms;
namespace FirefoxMissingCertMimeTypePatcher
{
    partial class Form1
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

        private void AddCheckbox()
        {

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            if (!Tools.MimeTypesRdfExist())
            {
                MessageBox.Show("Can't find mimeTypes.rdf in your Firefox Profile folder:\n"
                    + Tools.GetMimeTypesRdfPath()
                    + "\nCheck if you are running this app with Administrator privilages."
                );
            }

            this.certs = new List<Cert>();
            this.certs.Add(new Cert("pem", "application/x-pem-file"));
            this.certs.Add(new Cert("cer", "application/pkix-cert"));
            this.certs.Add(new Cert("crt", "application/x-x509-user-cert"));
            this.certs.Add(new Cert("der", "application/x-x509-ca-cert"));
            this.certs.Add(new Cert("p7b", "application/x-pkcs7-certificates"));
            this.certs.Add(new Cert("p7c", "application/pkcs7-mime"));
            this.certs.Add(new Cert("p12", "application/x-pkcs12"));
            this.certs.Add(new Cert("pfx", "application/x-pkcs12"));

            this.label1 = new System.Windows.Forms.Label();
            this.fixMissing = new System.Windows.Forms.Button();

            this.checkboxes = new Dictionary<string, System.Windows.Forms.CheckBox>();
            foreach (Cert cert in this.certs)
            {
                this.checkboxes[cert.ext] = new System.Windows.Forms.CheckBox();
            }

            this.SuspendLayout();

            // 
            // Add checkboxes
            //
            int i = 0;
            int checkboxesEndY = 0;
            foreach (Cert cert in this.certs)
            {
                this.checkboxes[cert.ext].AutoSize = true;
                this.checkboxes[cert.ext].Checked = cert.getStatus();
                //this.checkboxes[cert.ext].CheckState = System.Windows.Forms.CheckState.Checked;
                this.checkboxes[cert.ext].Enabled = false;
                this.checkboxes[cert.ext].FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.checkboxes[cert.ext].Location = new System.Drawing.Point(26, 39 + 24 * i++);
                this.checkboxes[cert.ext].Name = "checkBox_" + cert.ext;
                this.checkboxes[cert.ext].Size = new System.Drawing.Size(164, 18);
                this.checkboxes[cert.ext].TabIndex = 0;
                this.checkboxes[cert.ext].Text = "." + cert.ext + " (" + cert.mimeType + ")";
                this.checkboxes[cert.ext].UseVisualStyleBackColor = true;
            }
            checkboxesEndY = 39 + 24 * i;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your mimeTypes.rdf status:";

            // 
            // fixMissing
            // 
            this.fixMissing.Location = new System.Drawing.Point(83, checkboxesEndY + 10);
            this.fixMissing.Name = "fixMissing";
            this.fixMissing.Size = new System.Drawing.Size(120, 24);
            this.fixMissing.TabIndex = 0;
            this.fixMissing.Text = "Fix missing";
            this.fixMissing.UseVisualStyleBackColor = true;
            this.fixMissing.Click += new System.EventHandler(this.fixMissing_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, checkboxesEndY + 50);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fixMissing);
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            foreach (KeyValuePair<string, System.Windows.Forms.CheckBox> checkbox in this.checkboxes)
            {
                this.Controls.Add(checkbox.Value);
            }

            this.Name = "Form";
            this.Text = "Firefox Missing Cert Mime-Types Patcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button fixMissing;

        private List<Cert> certs { get; set; }
        private Dictionary<string, System.Windows.Forms.CheckBox> checkboxes { get; set; }
    }
}

