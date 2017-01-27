using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FirefoxMissingCertMimeTypePatcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fixMissing_Click(object sender, EventArgs e)
        {
            Tools.CreateBackup();

            int i = 0;
            foreach (Cert cert in this.certs)
            {
                if(cert.addEntry()) 
                {
                    i++;
                }
                this.checkboxes[cert.ext].Checked = true;
            }
            MessageBox.Show(i > 0 ? "Done!\nAdded " + i.ToString() + " entries.\nPlease restart Firefox to load changes." : "Nothing to do - everything is fine" );
        }

    }
}
