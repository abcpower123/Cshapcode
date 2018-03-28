using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HtmlScanDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://news.zing.vn/thoi-su.html";

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);

            string match = "<article";
            int pos = 0;

            List<Article> list = new List<Article>();

            while(html.IndexOf(match, pos) > 0)
            {
                pos = html.IndexOf(match, pos) + match.Length;

                pos = html.IndexOf("href=", pos) + 6;
                int len = html.IndexOf("\"", pos) - pos;
                string href = "https://news.zing.vn" + html.Substring(pos, len);

                pos = html.IndexOf("src=", pos) + 5;
                len = html.IndexOf("\"", pos) - pos;
                string src = html.Substring(pos, len);

                pos = html.IndexOf("title=", pos) + 7;
                string title = html.Substring(pos, html.IndexOf("\"", pos) - pos);

                string subhtml = client.DownloadString(href);
                int begin = subhtml.IndexOf("<p class=\"the-article-summary");
                int end = subhtml.IndexOf("<p class=\"the-article-tags");
                string content = subhtml.Substring(begin, end - begin);

                //scan content
                list.Add(new Article()
                {
                    title = title,
                    href = href,
                    src = src,
                    content = content
                });
            }//while

            //Luu list
            Stream stream = File.Create("list.xml");
            XmlSerializer xml = new XmlSerializer(typeof(List<Article>));
            xml.Serialize(stream, list);
            stream.Close();
            Console.WriteLine("Xong goy!");
            //Console.WriteLine(html);
            Console.ReadLine();
        }
    }
}
