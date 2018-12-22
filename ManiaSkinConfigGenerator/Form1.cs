using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace ManiaSkinConfigGenerator
{
    public partial class Form1 : Form
    {
        public string skinname;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Keys.Text != "")
            {
                GenerateV2();
            }
        }

        void GenerateV2()
        {
            int i;
            string result_ = "nl// Begin Config Key " + Keys.Text + " nlnl[Mania]", numwidth = "", numlinewidth = "";
            foreach (Control control_ in groupBox2.Controls)
            {
                if (control_ is ComboBox)
                {
                    if (control_.Text != "")
                    {
                        ComboBox cm = control_ as ComboBox;
                        result_ += "nl" + cm.Name + ": " + cm.SelectedIndex;
                    }
                }    
            }
            foreach (Control control_ in groupBox2.Controls)
            {
                if (control_ is TextBox)
                {
                    if (control_.Text != "")
                    {
                        if (control_.Name == "ColumnWidth")
                        {
                            for (i = 0; i < Convert.ToInt32(Keys.Text); i++)
                            {
                                numwidth += ColumnWidth.Text + ",";
                            }
                            result_ += "nl" + control_.Name + ": " + numwidth.Substring(0, numwidth.Length - 1);
                        } else if (control_.Name == "ColumnLineWidth") {
                            for (i = 0; i < Convert.ToInt32(Keys.Text); i++)
                            {
                                numlinewidth += ColumnLineWidth.Text + ",";
                            }
                            result_ += "nl" + control_.Name + ": " + numlinewidth.Substring(0, numlinewidth.Length - 1);
                        } else if (control_.Name != "KeyImage" && control_.Name != "NoteImage" && control_.Name.Substring(0, 6) != "Colour" && control_.Name != "StageRight" && control_.Name != "StageLeft")
                        {
                            result_ += "nl" + control_.Name + ": " + control_.Text;
                        }
                    }
                }
            }
            result_ += "nlnl//Begin Imagenl";
            buatFolder(KeyImage.Text);
            buatFolder(NoteImage.Text);
            foreach (Control control_ in groupBox2.Controls)
            {
                if (control_ is TextBox)
                {
                    if (control_.Text != "")
                    {
                        if (control_.Name.Substring(0, 5) == "Stage")
                        {
                            result_ += "nl" + control_.Name + ": " + control_.Text;
                        }
                        if (control_.Name == "KeyImage")
                        {
                            for (i=0; i < Keys.SelectedIndex; i++)
                            {
                                result_ += "nl" + control_.Name + i + ": " + control_.Text + i;
                                result_ += "nl" + control_.Name + i + "D: " + control_.Text + i + "D";
                                CopyFile(Skin.GetKeyImage(), GetDir(KeyImage.Text) + GetFileName(KeyImage.Text) + i + ".png");
                                CopyFile(Skin.GetKeyImageD(), GetDir(KeyImage.Text) + GetFileName(KeyImage.Text) + i + "D.png");
                            }
                        } else if (control_.Name == "NoteImage")
                        {
                            for (i = 0; i < Keys.SelectedIndex; i++)
                            {
                                result_ += "nl" + control_.Name + i + ": " + control_.Text + i;
                                result_ += "nl" + control_.Name + i + "H: " + control_.Text + i + "H";
                                result_ += "nl" + control_.Name + i + "T: " + control_.Text + i + "T";
                                result_ += "nl" + control_.Name + i + "L: " + control_.Text + i + "L";
                                CopyFile(Skin.GetNoteImage(), GetDir(NoteImage.Text) + GetFileName(NoteImage.Text) + i + ".png");
                                CopyFile(Skin.GetNoteImageH(), GetDir(NoteImage.Text) + GetFileName(NoteImage.Text) + i + "H.png");
                                CopyFile(Skin.GetNoteImageT(), GetDir(NoteImage.Text) + GetFileName(NoteImage.Text) + i + "T.png");
                                CopyFile(Skin.GetNoteImageL(), GetDir(NoteImage.Text) + GetFileName(NoteImage.Text) + i + "L.png");
                            }
                        }
                    }
                }
            }
            buatFolder(StageLeft.Text);
            buatFolder(StageRight.Text);
            CopyFile(Skin.GetStageLeft(), GetDir(StageLeft.Text) + GetFileName(StageLeft.Text) + ".png");
            CopyFile(Skin.GetStageRight(), GetDir(StageRight.Text) + GetFileName(StageRight.Text) + ".png");
            result_ += "nlnl//End Imagenl";
            result_ += "nl//Begin Colournl";
            foreach (Control control_ in groupBox2.Controls)
            {
                if (control_ is TextBox)
                {
                    if (control_.Text != "")
                    {
                        if (control_.Name.Substring(0, 6) == "Colour") 
                        {
                            if (control_.Name == "Colour")
                            {
                                for (i = 0; i < Keys.SelectedIndex; i++)
                                {
                                    result_ += "nl" + control_.Name + (i + 1) + ": " + control_.Text;
                                }
                            }
                            if (control_.Name == "ColourLight")
                            {
                                for (i = 0; i < Keys.SelectedIndex; i++)
                                {
                                    result_ += "nl" + control_.Name + (i + 1) + ": " + control_.Text;
                                }
                            } else if (control_.Name != "Colour")
                            {
                                result_ += "nl" + control_.Name + ": " + control_.Text;
                            }
                        }
                    }
                }
            }
            result_ += "nlnl//End Colour";
            result_ += "nlnl//End Config Key " + Keys.Text;
            result.Text = result_.Replace("nl", Environment.NewLine);
            buatFileConfig(result.Text);
            MessageBox.Show("Config Berhasil dibuat, File bisa dilihat di Folder Output", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        string GetFileName(string path)
        {
            string[] dir = path.Split('\\');
            string FileName = "";
            int jml = 0;
            for (int i = 0; i < (dir.Length - 1); i++)
            {
                jml++;
            }
            FileName += dir[jml];
            return FileName;
        }

        void CopyFile(string from, string newfile)
        {
            try
            {
                if (File.Exists(newfile))
                {
                    File.Delete(newfile);
                    File.Copy(from, newfile);
                } else
                {
                    File.Copy(from, newfile);
                }
            } catch (Exception ex)
            {
                //error
            }
        }

        void buatFileConfig(string Config)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "SkinOutput\\" + Skin.GetSkinName() + "\\" + Keys.Text + "K.ini";
            if (File.Exists(path))
            {
                File.Delete(path);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(Config);
                }
            } else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(Config);
                }
            }
        }

        string GetDir(string path)
        {
            string[] dir = path.Split('\\');
            string resdir = "";
            for (int i = 0; i < (dir.Length - 1); i++)
            {
                resdir += dir[i] + "\\";
            }
            string path_ = AppDomain.CurrentDomain.BaseDirectory + "SkinOutput\\" + Skin.GetSkinName() + "\\" + resdir;
            return path_;
        }

        void buatFolder(string path)
        {
            try
            {
                if (!Directory.Exists(GetDir(path)))
                {
                    DirectoryInfo di = Directory.CreateDirectory(GetDir(path));
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show(ioex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AcceptButton = btn_Generate;
            Form frm2 = new Form2();
            frm2.ShowDialog();
        }

        public void load_()
        {
            this.Text = "Mania Skin Key Config Generator (BETA) - " + Skin.GetSkinName();
            buatOutput();
        }

        void buatOutput()
        {
            try
            {
                if (!Directory.Exists(GetDir("SkinOutput")))
                {
                    DirectoryInfo di = Directory.CreateDirectory(GetDir("SkinOutput"));
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show(ioex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin menutup Aplikasi ?", "Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            } else
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "SkinOutput\\" + Skin.GetSkinName();
            Process.Start("explorer.exe", path);
        }

        private void keluarAplikasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new AboutBox1();
            about.ShowDialog();
        }

        private void Keys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Keys.Text != "")
            {
                KeyImage.Text = "Mania\\" + Keys.Text + "K\\" + "Keys\\Key-";
                NoteImage.Text = "Mania\\" + Keys.Text + "K\\" + "Notes\\Note-";
                StageLeft.Text = "Mania\\" + Keys.Text + "K\\" + "Stage\\StageLeft";
                StageRight.Text = "Mania\\" + Keys.Text + "K\\" + "Stage\\StageRight";
            } else
            {
                KeyImage.Text = "";
                NoteImage.Text = "";
                StageLeft.Text = "";
                StageRight.Text = "";
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Skin.SetSkinName("");
            result.Text = "";
            Form frm2 = new Form2();
            frm2.ShowDialog();
        }
    }
}
