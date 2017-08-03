using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace Notepad
{
    public partial class Form1 : Form
    {
        private string _path;
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _path = string.Empty;
            textBox.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() {Filter = @"Text Documents|*.txt", ValidateNames = true, Multiselect = false})
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        
                        using (StreamReader sr = new StreamReader(ofd.FileName, Encoding.Default))
                        {
                            _path = ofd.FileName;
                            Task<string> text = sr.ReadToEndAsync();
                            textBox.Text = text.Result;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }


            }
        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_path))
            {

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = @"Text Documents|*.txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {

                        try
                        {
                            _path = sfd.FileName;
                            using (StreamWriter sw = new StreamWriter(sfd.FileName, true, Encoding.GetEncoding(1251)))
                            {
                                await sw.WriteLineAsync(textBox.Text);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                        }

                     }
                        
                  }    
               
            }
            else
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(_path))
                    {
                        await sw.WriteLineAsync(textBox.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private async void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = @"Text Documents|*.txt", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        _path = sfd.FileName;
                        using (StreamWriter sw = new StreamWriter(sfd.FileName, true, Encoding.GetEncoding(1251)))
                        {
                            await sw.WriteLineAsync(textBox.Text);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }

            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
              Application.Exit();  
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmAbout frm = new FrmAbout())
            {
                frm.ShowDialog();
            }
        }
    }
}
