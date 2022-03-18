using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;

namespace Hack_NBS_Create
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "NBS Create Files (*.spex)|*.spex";

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.textBox1.Text = openFileDialog.FileName;
                    this.button2.Enabled = true;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(this.textBox1.Text))
            {
                this.button2.Enabled = true;
            }
            else
            {
                this.button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string newFileName = this.textBox1.Text.Replace(".spex", "_hacked.spex");

            System.IO.File.Copy(this.textBox1.Text, newFileName);

            SQLiteConnection sqlite_conn = new SQLiteConnection($"Data Source={newFileName}; Version = 3; New = True; Compress = True;");
            sqlite_conn.Open();

            SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "UPDATE Entity SET IsUserClause = 1";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();

            if(MessageBox.Show("A copy of the spex file has been edited. Would you like to open and check it?", "File processed", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(newFileName);
                startInfo.UseShellExecute = true;
                Process.Start(startInfo);
            }

            this.textBox1.Text = string.Empty;
        }

    }
}
