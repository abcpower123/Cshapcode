using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace HoaMiClubToolv1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
        }

        private AppSetting setting;
        private Thread Search=null;  
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            
                setting = AppSetting.LoadSetting();
            
            if (btnStart.BackColor==Color.Green)    //start
            {
                //check validate
                if (txtInput.Text.Equals(""))
                {
                    MessageBox.Show("Danh sách bài hát input rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtOutput.Enabled = false;
                lstErr.Items.Clear();
                txtOutput.ResetText();
                btnStart.Text = "Dừng lại";
                btnStart.BackColor = Color.Red;
                Search = new Thread(new ThreadStart(t_Search));
                Search.Start();
                lstErr.Enabled = false;
                btnSetting.Enabled = false;
                mntSetting.Enabled = false;
            }
            else                                    //stop
            {
                mntSetting.Enabled = true;
                btnStart.Text = "Bắt đầu";
                prgBar.Value = 0;
                txtPrg.Text = "0%";
                btnStart.BackColor = Color.Green;
                Search.Abort();
                lstErr.Enabled = true;
                txtOutput.Enabled = true;
                btnSetting.Enabled = true;
            }
        }
        private delegate void dlgT_Search();
        private void t_Search()
        {
            var listSong = GetListSong();
            int c = 0;
            this.BeginInvoke(new dlgT_Search(() =>
            {
                txtstt.Text = "Đã lấy được 0/" + listSong.Count + " bài hát"; txtOu.Text = txtstt.Text;
                prgBar.Maximum = listSong.Count;
                prgBar.Minimum = 0;
                txtPrg.Text = "0%";

            }));


            foreach (var item in listSong)
            {
                var q = item.Split(setting.songauthorseparate);
                string songname = q.FirstOrDefault().Trim();
                string authorsinger = q.LastOrDefault().Trim();
                DataFromLyric_Karaoke_Com kara = new DataFromLyric_Karaoke_Com(songname);
                var searchresult = kara.GetSearchResult(authorsinger, authorsinger);
                string rs = kara.GetLyric(searchresult);

                this.BeginInvoke(new dlgT_Search(() =>
                {
                    txtOutput.SelectionFont = setting.fontSongName;
                    txtOutput.SelectionColor = setting.cSongName;
                    txtOutput.SelectedText = songname+ "\r\n";
                    txtOutput.SelectionFont = setting.fontAuthorSinger;
                    txtOutput.SelectionColor = setting.cSongAuthor;
                    if (searchresult!=null)
                    {
                        if ( !string.IsNullOrEmpty(searchresult.author))
                        {
                            txtOutput.SelectedText = "Nhạc sĩ: " + searchresult.author+"\r\n";
                        }
                        txtOutput.SelectionFont = setting.fontAuthorSinger;
                        txtOutput.SelectionColor = setting.cSongAuthor;
                        if (!string.IsNullOrEmpty(searchresult.singer))
                        {
                            txtOutput.SelectedText = "Ca sĩ: " + searchresult.singer + "\r\n";
                        }

                    }
                    txtOutput.SelectedText = "\r\n";
                    txtOutput.SelectionFont = setting.fontLyric;
                    txtOutput.SelectionColor = setting.cLyric;
                    if (rs.Equals("Không tìm thấy")||rs[0]=='1')
                    {
                        if (rs[0]=='1')
                        {
                            rs.Remove(0, 1);
                        }
                        txtOutput.SelectionColor = setting.cErrLyric;
                        txtOutput.SelectionFont = setting.fontmisingLyric;
                        var listviewitem=lstErr.Items.Add(item);
                        listviewitem.SubItems.Add((txtOutput.TextLength - 1).ToString());
                        txtOutput.SelectedText = rs+"\r\n";

                    }
                    else
                    {

                        txtOutput.SelectedText = rs + "\r\n";
                        c++; txtstt.Text = "Đã lấy được " + c + "/" + listSong.Count + " bài hát";
                        txtOu.Text = txtstt.Text;
                        prgBar.Value += 1;
                        txtPrg.Text = ((float)c / listSong.Count * 100).ToString("n2") + "%";
                    }
                    txtOutput.SelectedText = setting.songseparate + "\r\n";
                }));
                Thread.Sleep(setting.speedGet*1000);
            }
            MessageBox.Show("Lấy lời bài hát hoàn tất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.BeginInvoke(new dlgT_Search(() => { lstErr.Enabled = true;
                txtOutput.Enabled = true;
                btnStart.Text = "Bắt đầu";
                btnStart.BackColor = Color.Green;
                btnSetting.Enabled = true;
                prgBar.Value = 0;
                txtPrg.Text = "Hoàn thành";
                mntSetting.Enabled = true;
            }));
            
            if (lstErr.Items.Count!=0)
            {
                MessageBox.Show("Có 1 số bài hát không thể lấy lời hoặc có thể lấy lời không chính xác!\r\n Hãy chọn các bài hát đó trong danh sách bài hát lỗi và thực hiện lấy lời bằng tay\r\n", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            groupBox2.Location = new Point(panel1.Location.X + panel1.Size.Width + 10,groupBox2.Location.Y) ;
            groupBox2.Width= this.Size.Width - groupBox2.Location.X -30;

            groupBox1.Width = this.Size.Width - groupBox2.Width - 60 - panel1.Width;
        }
        private List<String> GetListSong()
        {
            string inp = txtInput.Text;
            var list =inp.Split('\n');
            return list.ToList();
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            //check validate
            if (txtInput.Text.Equals(""))
            {
                MessageBox.Show("Danh sách bài hát input rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var x = GetListSong();
            x.Sort();
            txtInput.Text = "";
            foreach (var item in x)
            {
                txtInput.Text += item + "\r\n";
            }
        }

        private void btnCoppy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtOutput.Rtf,TextDataFormat.Rtf);
            MessageBox.Show("Coppy hoàn tất! Hãy vào Word và dán nó ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lstErr_Click(object sender, EventArgs e)
        {
            int index = int.Parse(lstErr.SelectedItems[0].SubItems[1].Text)+1;
            txtOutput.Focus();
            txtOutput.Select(index, "Không tìm thấy".Length);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmSetting f = new frmSetting();
            f.ShowDialog();
        }

        private void mntSetting_Click(object sender, EventArgs e)
        {
            btnSetting.PerformClick();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            string about = "Tool lấy lời bài hát tự động dựa vào nguồn dữ liệu trên trang 'lyric.tkaraoke.com'.\r\n Được phát triển bởi Đặng Thanh Hào - Họa Mi club . Mọi ý kiến báo lỗi/ đóng góp xây dựng xin liên hệ:\r\n Đặng Thanh Hào- SDT: 0165 766 6161\r\nMail: aszqsc@gmail.com. FB: fb.com/aszqsc.";
            MessageBox.Show(about, "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string help = "1. Nhập danh sách các bài hát cần lấy lời ở ô input, Mỗi bài hát có phần tên bài hát và phần nhạc sĩ, ca sĩ phân biệt nhau bằng dấu - , \r\n Mỗi dấu enter xuống dòng là 1 bài hát.\r\n2.Nhấn nút bắt đầu và đi uống tách cafe đợi tool lấy dữ liệu về :D.\r\n3. Sau khi có kết quả, có 1 số bài hát nghi ngờ lấy lời sai hoặc không thể lấy lời được vui lòng tự lấy lời bằng tay, và click vào danh sách lỗi để thay thế lời bị sai\r\n4.Sau cùng có thể nhấn nút coppy all sau đó paste qua word(chỉ qua word) để tiện chỉnh sửa. \r\nLưu ý: App sẽ lấy dữ liệu từ trang lyric.tkaraoke.com nên cần đảm bảo internet để app hoạt động!";
            MessageBox.Show(help, "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
