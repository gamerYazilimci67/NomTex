using System.Drawing.Text;

namespace NomTex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox2.SelectedIndex = 0;
        }

        bool kaydedildimi = false;
        string dosya_yolu = "";
        string dosya_icerigi = "";

        public void ara(string aranacakMetin)
        {
            int index = richTextBox1.Text.IndexOf(aranacakMetin);

            if (index != -1)
            {
                richTextBox1.Select(index, aranacakMetin.Length);
                MessageBox.Show("Metin Bulundu", "NomTex", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Metin Bulunamadý", "NomTex", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "NomTex | Dosya Aç";
            openFileDialog.Filter = "Metin Dosyalarý|*.txt|RTF Dosyalarý|*.rtf|Tüm Dosyalar|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dosya_yolu = openFileDialog.FileName;
                if (openFileDialog.FileName.EndsWith(".rtf"))
                {
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    dosya_icerigi = File.ReadAllText(dosya_yolu);

                    richTextBox1.Text = dosya_icerigi;

                }


            }
        }



        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dosya_yolu == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Dosyayý Kaydedin";
                saveFileDialog.Filter = "Metin Dosyalarý|*.txt|RTF Dosyalarý|*.rtf|Tüm Dosyalar|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog.FileName.EndsWith(".rtf"))
                    {
                        richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        dosya_yolu = saveFileDialog.FileName;
                        File.WriteAllText(dosya_yolu, richTextBox1.Text);
                    }

                }
            }
            else
            {
                File.WriteAllText(dosya_yolu, richTextBox1.Text);
            }

            kaydedildimi = true;
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string klasor_yolu = folderBrowserDialog.SelectedPath;
                string dosya_ismi = "YeniDosya.txt";
                dosya_yolu = Path.Combine(klasor_yolu, dosya_ismi);

                richTextBox1.Text = "";



            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();


            if (colorDialog.ShowDialog() == DialogResult.OK)
            {

                richTextBox1.SelectionColor = colorDialog.Color;
                pictureBox1.BackColor = colorDialog.Color;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int fontbuyukluk = trackBar1.Value;
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, fontbuyukluk, richTextBox1.SelectionFont.Style);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildimi == false)
            {
                if (richTextBox1.Text == "")
                {

                }
                else
                {
                    DialogResult result = MessageBox.Show("Dosyanýzý Kaydetmediniz! Kaydetmek ister misiniz?", "Uyarý!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (dosya_yolu == "")
                        {
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Title = "Dosyayý Kaydedin";
                            saveFileDialog.Filter = "Metin Dosyalarý|*.txt|RTF Dosyalarý|*.rtf|Tüm Dosyalar|*.*";

                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                dosya_yolu = saveFileDialog.FileName;
                                File.WriteAllText(dosya_yolu, richTextBox1.Text);
                            }
                        }
                        else
                        {
                            File.WriteAllText(dosya_yolu, richTextBox1.Text);

                        }
                        kaydedildimi = true;
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }

                }

            }
        }




        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem != null)
            {
                richTextBox1.SelectionFont = new Font(comboBox1.SelectedItem.ToString(), richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
            }
            else
            {
                richTextBox1.SelectionFont = new Font("Arial", richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var installedFonts = new InstalledFontCollection())
            {
                foreach (var font in installedFonts.Families)
                {
                    comboBox1.Items.Add(font.Name);
                }
            }
        }

        private void bulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secilifontstil = comboBox2.SelectedIndex;

            FontStyle fontstil = FontStyle.Regular;

            if (secilifontstil == 0)
            {
                fontstil = FontStyle.Regular;
            }
            else if (secilifontstil == 1)
            {
                fontstil = FontStyle.Bold;
            }
            else if (secilifontstil == 2)
            {
                fontstil = FontStyle.Italic;
            }
            else if (secilifontstil == 3)
            {
                fontstil = FontStyle.Underline;
            }
            else if (secilifontstil == 4)
            {
                fontstil = FontStyle.Strikeout;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, fontstil);


        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
        }

        private void yapýþtýrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.Paste();
            }
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = "";

            }
        }

        private void kopyalaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
        }

        private void yapýþtýrToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.Paste();
            }
        }

        private void kesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
        }
    }
}
