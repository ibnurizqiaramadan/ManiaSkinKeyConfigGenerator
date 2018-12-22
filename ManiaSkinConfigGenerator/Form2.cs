using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ManiaSkinConfigGenerator
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        static string output = "SkinOutput\\";
        static string path = AppDomain.CurrentDomain.BaseDirectory + output;
        Form1 formm1 = (Form1)Application.OpenForms[new Form1().Name];

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string path_ = AppDomain.CurrentDomain.BaseDirectory + "SkinOutput\\" + textBox1.Text;
                if (!Directory.Exists(path_))
                {
                    Skin.SetSkinName(textBox1.Text);
                    formm1.load_();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nama Skin sudah ada !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                    textBox1.SelectAll();
                }
            } else
            {
                textBox1.Focus();
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Skin.GetSkinName() == "")
            {
                if (MessageBox.Show("Apakah Anda yakin ingin menutup ?", "Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AcceptButton = button1;
            loadlistskin();
        }

        void loadlistskin()
        {
            try
            {
                listBox1.Items.Clear();
                folderBrowserDialog1.SelectedPath = path;
                string[] folder = Directory.GetDirectories(folderBrowserDialog1.SelectedPath).Select(Path.GetFileName).ToArray();
                foreach (string list in folder)
                {
                    listBox1.Items.Add(list);
                }
            } catch (Exception ex)
            {
                // error
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AcceptButton = button2;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            AcceptButton = button1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Skin.SetSkinName(listBox1.SelectedItem.ToString());
                formm1.load_();
                this.Hide();
            } catch (Exception ex)
            {
                // error
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string namefolder = listBox1.SelectedItem.ToString();
                if (MessageBox.Show("Apakah Anda yakin ingin menghapus Skin ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Directory.Delete(path + namefolder, true);
                    loadlistskin();
                }
            } catch (Exception ex)
            {
                // error
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", path);
        }

        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            
        }
    }
}
