using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class DataFromLyric_Karaoke_Com
    {
        private List<SearchResult> list;
        public string song { get; set; }
        public DataFromLyric_Karaoke_Com(String keyword)
        {
            song = keyword;
            list = new List<SearchResult>();
        }
        public List<SearchResult> Search()
        {
            string url = "http://lyric.tkaraoke.com/s.tim?q=" + song + "&t=2";
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);

            string match = "h4-title-song";
            int pos = 0; int len = 0;

           

            while (html.IndexOf(match, pos) > 0)
            {
                SearchResult searchResult = new SearchResult();
                pos = html.IndexOf(match, pos) + match.Length;
                //getlinktolyric page
                pos = html.IndexOf("href=", pos) + 6;
                len = html.IndexOf("html", pos) + 4 - pos;
                searchResult.href = "http://lyric.tkaraoke.com" + html.Substring(pos, len);
                //GET NAME
                pos = html.IndexOf(">", pos) +1;
                len = html.IndexOf("</a>", pos) - pos;
                searchResult.name = html.Substring(pos, len).Replace("<span class=\"high-light-song-name\">","").Replace("</span>","");
                //get author
                pos = html.IndexOf("p-author", pos) + 8;
                int index = html.IndexOf("p-singer", pos);
                while (pos < index)
                {

                    pos = html.IndexOf("title=", pos) + 6;
                    if ((pos >= index))
                    {
                        pos = index;
                        break;
                    }
                    pos = html.IndexOf(">", pos) + 1;
                    len = html.IndexOf("<", pos) - pos;
                    searchResult.author += html.Substring(pos, len) + ";";
                }

                //get singer

                pos = html.IndexOf("p-singer", pos) + 8;
                index = html.IndexOf("p-lyrics", pos);
                while (pos < index)
                {

                    pos = html.IndexOf("title=", pos) + 6;
                    if ((pos >= index))
                    {
                        pos = index;
                        break;
                    }
                    pos = html.IndexOf(">", pos) + 1;
                    len = html.IndexOf("<", pos) - pos;
                    searchResult.singer += html.Substring(pos, len) + ";";
                }
                list.Add(searchResult);
            }
            return list;
        }

        public string GetLyric(string author, string singer)
        {
            if (list.Count==0)
            {
                Search();
            }
            if (list.Count<=0)
            {
                return "Danh sách rỗng";
            }
            singer = singer.ToLower();
            author = author.ToLower();
            var rs = list.Where(x => x.singer.ToLower().Contains(singer) && x.author.ToLower().Contains(author)).FirstOrDefault();
            if (rs==null)
            {
                rs = list.Where(x => x.singer.ToLower().Contains(singer)).FirstOrDefault();
                if (rs == null)
                {
                    rs = list.Where(x => x.author.ToLower().Contains(author)).FirstOrDefault();
                }
                
            }
            if (rs!=null)
            {
               return GetLyricFromSearchResult(rs);
            }
            else
            {
                return "Danh sách rỗng!";
            }
        }

        private string GetLyricFromSearchResult(SearchResult rs)
        {
            WebClient web = new WebClient();
            web.Encoding = Encoding.UTF8;
            string html = web.DownloadString(rs.href);
            int pos = html.IndexOf("div-content-lyric") + "div-content-lyric".Length + 2;
            int len = html.IndexOf("</div>", pos) - pos;
            return html.Substring(pos, len).Trim().Replace("<br />", System.Environment.NewLine);
        }
    }
}
