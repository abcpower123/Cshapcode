using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoaMiClubToolv1
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }
        private AppSetting setting = null;
        private void txtSperateAuthor_KeyDown(object sender, KeyEventArgs e)
        {
            txtSeparateAuthor.Clear();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            setting = AppSetting.LoadSetting();
            update();
        }

        private void frmSetting_Shown(object sender, EventArgs e)
        {
            
        }
        private string showfont(Font font)
        {
            return font.Name + " - " + font.Size + " - " + font.Style.ToString();
        }
        private void update()
        {
            txtSeparateAuthor.Text = setting.songauthorseparate.ToString();
            txtSeparate.Text = setting.songseparate.ToString();
            comboBox1.SelectedItem = setting.speedGet.ToString();
            lbFontSong.Text = showfont(setting.fontSongName);
            lbFontAuthor.Text = showfont(setting.fontAuthorSinger);
            lbFontLyric.Text = showfont(setting.fontLyric);
            lbfontErr.Text = showfont(setting.fontmisingLyric);
            colorAuthor.BackColor = setting.cSongAuthor;
            colorSong.BackColor = setting.cSongName;
            colorLyric.BackColor = setting.cLyric;
            colorErr.BackColor = setting.cErrLyric;
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSeparateAuthor.Text))
            {
                MessageBox.Show("Không được để trống ô kí tự để phân biệt tên bài hát và tên tác giả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            setting.songauthorseparate = txtSeparateAuthor.Text[0];
            setting.songseparate = txtSeparate.Text;
            try
            {
                setting.speedGet = int.Parse(comboBox1.SelectedItem.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Tốc độ lấy bài phải là 1 số nguyên dương(giây)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            setting.SaveSetting();
            
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            
            setting = AppSetting.getDefault();
            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = fontDialog1.ShowDialog();
            if (x==DialogResult.OK)
            {
                setting.fontSongName = fontDialog1.Font;
                lbFontSong.Text = showfont(fontDialog1.Font);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog()==DialogResult.OK)
            {
                setting.cSongName = colorDialog1.Color;
                colorSong.BackColor = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var x = fontDialog1.ShowDialog();
            if (x == DialogResult.OK)
            {
                setting.fontAuthorSinger = fontDialog1.Font;
                lbFontAuthor.Text = showfont(fontDialog1.Font);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                setting.cSongAuthor = colorDialog1.Color;
                colorAuthor.BackColor = colorDialog1.Color;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var x = fontDialog1.ShowDialog();
            if (x == DialogResult.OK)
            {
                setting.fontLyric = fontDialog1.Font;
                lbFontLyric.Text = showfont(fontDialog1.Font);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                setting.cLyric = colorDialog1.Color;
                colorLyric.BackColor = colorDialog1.Color;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var x = fontDialog1.ShowDialog();
            if (x == DialogResult.OK)
            {
                setting.fontmisingLyric = fontDialog1.Font;
                lbfontErr.Text = showfont(fontDialog1.Font);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                setting.cErrLyric = colorDialog1.Color;
                colorErr.BackColor = colorDialog1.Color;
            }
        }
    }

}


