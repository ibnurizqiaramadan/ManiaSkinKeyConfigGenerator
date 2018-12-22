using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManiaSkinConfigGenerator
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            AcceptButton = btn_ok;
            GetImage(Skin.GetKeyImage(), keyimage, pickeyimage);
            GetImage(Skin.GetKeyImageD(), keyimaged, pickeyimaged);
            GetImage(Skin.GetNoteImage(), noteimage, picnoteimage);
            GetImage(Skin.GetNoteImageH(), noteimageh, picnoteimageh);
            GetImage(Skin.GetNoteImageT(), noteimaget, picnoteimaget);
            GetImage(Skin.GetNoteImageL(), noteimagel, picnoteimagel);
            GetImage(Skin.GetStageLeft(), stageleft, picstageleft);
            GetImage(Skin.GetStageRight(), stageright, picstageright);
            btn_ok.Focus();
        }

        void GetImage(string image, TextBox text, PictureBox pic)
        {
            try
            {
                text.Text = image;
                Bitmap bm = new Bitmap(image);
                pic.Image = bm;
            } catch (Exception ex)
            {
                // kalau error
            }
        }

        void SetImage(TextBox text, PictureBox pic)
        {
            openFileDialog1.Filter = "PNG Files(*.PNG)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                text.Text = openFileDialog1.FileName;
                Bitmap bm = new Bitmap(text.Text);
                pic.Image = bm;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetImage(keyimage, pickeyimage);
            Skin.SetKeyImage(openFileDialog1.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetImage(keyimaged, pickeyimaged);
            Skin.SetKeyImageD(openFileDialog1.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetImage(noteimage, picnoteimage);
            Skin.SetNoteImage(openFileDialog1.FileName);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetImage(noteimageh, picnoteimageh);
            Skin.SetNoteImageH(openFileDialog1.FileName);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetImage(noteimaget, picnoteimaget);
            Skin.SetNoteImageT(openFileDialog1.FileName);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetImage(noteimagel, picnoteimagel);
            Skin.SetNoteImagL(openFileDialog1.FileName);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SetImage(stageleft, picstageleft);
            Skin.SetStageLeft(openFileDialog1.FileName);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SetImage(stageright, picstageright);
            Skin.SetStageRight(openFileDialog1.FileName);
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
