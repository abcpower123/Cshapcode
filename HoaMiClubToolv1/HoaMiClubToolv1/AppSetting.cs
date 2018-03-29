using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HoaMiClubToolv1
{
    [Serializable]
    public class AppSetting
    {
        private const string path = "config.bin";
        public Font fontSongName { get; set; }
        public Font fontAuthorSinger { get; set; }
        public Font fontLyric { get; set; }
        public string songseparate { get; set; }
        public char songauthorseparate { get; set; }
        public Font fontmisingLyric { get; set; }
        public int speedGet { get; set; }
        public Color cSongName { get; set; }
        public Color cSongAuthor { get; set; }
        public Color cLyric { get; set; }
        public Color cErrLyric { get; set; }
       

        
        public void SaveSetting()
        {
            FileStream fs = null;
            try
            {
                fs = File.Create(path);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, this);
            }
            catch (Exception)
            {

               
            }
            if (fs!=null)
            {
                fs.Close();
            } 
        }
        public static AppSetting LoadSetting()
        {
            AppSetting setting=null;
            FileStream fs = null;
            try
            {
                fs=File.OpenRead(path);
                BinaryFormatter formatter = new BinaryFormatter();
                 setting= formatter.Deserialize(fs) as AppSetting;
            }
            catch
            {
                setting = getDefault();
            }
            finally
            {
                if (fs!=null)
                {
                    fs.Close();

                }
            }

            return setting;
        }
        public static AppSetting getDefault()
        {

            AppSetting setting = new AppSetting()
            {
                fontSongName = new Font("Times New Roman", 18, FontStyle.Bold),
                fontAuthorSinger = new Font("Times New Roman", 15, FontStyle.Regular),
                fontLyric = new Font("Times New Roman", 14, FontStyle.Regular),
                fontmisingLyric = new Font("Times New Roman", 14, FontStyle.Regular),
                songseparate = "- - - - - - - - - - - - - - - - - - - - - - - - - -",
                songauthorseparate = '-',
                speedGet = 6,
                cSongName = Color.Black,
                cSongAuthor = Color.Black,
                cErrLyric = Color.Red,
                cLyric = Color.Black
            };
            return setting;
        }
    }
}
