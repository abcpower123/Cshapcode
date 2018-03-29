using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Collections;

namespace Nhac
{
    class Program
    {
        static string url_search = "https://www.nhaccuatui.com/tim-kiem/bai-hat?q=";
        static void Main(string[] args)
        {
            Console.Write("Search: ");
            string key = Console.ReadLine();
            string url = url_search + key;
            WebClient client = new WebClient();
            string html = client.DownloadString(url);

            string match = "<li class=\"list_song";
            int pos = 0;

            List<string> list = new List<string>(); int count = 1;
            while (html.IndexOf(match, pos) > 0)
            {
                pos = html.IndexOf(match, pos) + match.Length;
                pos = html.IndexOf("href=", pos) + 6;
                string href = html.Substring(pos, html.IndexOf("\"", pos) - pos);

                pos = html.IndexOf("title=", pos) + 7;
                string title = html.Substring(pos, html.IndexOf("\"", pos) - pos);

                Console.WriteLine(count+". "+title);
                Console.WriteLine(href);
                Console.WriteLine("--------------------");
                list.Add(href);
                count++;
            }
            Console.Write("Download id: ");
            int down = int.Parse(Console.ReadLine()) ;

            string link = list[down - 1];
            Console.WriteLine(link+"\nDownloading....");

            string html_song = client.DownloadString(link);
            pos = html_song.IndexOf("xmlURL") + 10;
            string lastdirect = html_song.Substring(pos, html_song.IndexOf('"', pos)-pos);

            string html_lastdirect = client.DownloadString(lastdirect);
            pos = html_lastdirect.IndexOf("<location>");
            pos = html_lastdirect.IndexOf("CDATA[",pos)+6;
            string link_mp3 = html_lastdirect.Substring(pos,html_lastdirect.IndexOf("]]",pos)-pos);

            Console.WriteLine(link_mp3);
            client.DownloadFile(link_mp3, "Download.mp3");
            Console.WriteLine("Done");
            //Stream s = File.OpenWrite("file.xml");
            //XmlSerializer serialize = new XmlSerializer(typeof(List<string>));
            //serialize.Serialize(s, list);
            //s.Close();
            //Console.WriteLine("xong");


            Console.ReadLine();
        }
    }
}
