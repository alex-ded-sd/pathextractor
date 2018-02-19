namespace PathsExtractor.WinFormClient
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Windows.Forms;
	using Core;

	public partial class Form1 : Form
	{
		public Form1() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
				try {
					IEnumerable<string> filesPaths = 
                        Extractor.GetFilesPaths(folderBrowserDialog1.SelectedPath, new[] { "*.mp3", "*.jpg" });
					ExcelImporter.Export("content.xlsx", filesPaths);
				}
				catch {
					MessageBox.Show("Ошибка в ядре", "Упс", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			}
			else {
				MessageBox.Show("Что то пошло не так", "Упс", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void button2_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    IEnumerable<FileInfo> filesPaths = 
                        Extractor.GetFiles(folderBrowserDialog2.SelectedPath, new[] { "*.mp3", "*.jpg" });
                    Translit.TranslitFileNames(filesPaths);
                    MessageBox.Show("Слава Богу, ошибок нет! Всё сработало", "", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка в ядре", "Упс", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Что то пошло не так", "Упс", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
