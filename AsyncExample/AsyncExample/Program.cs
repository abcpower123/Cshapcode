using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncExample
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileAsync(new Uri("https://c1-sd-vdc.nixcdn.com/NhacCuaTui955/NamAy-DucPhuc-5305026.mp3?st=cqoa6cQrrNHec-v7uZc9CA&e=1515678975&t=1515592575475"), "a.mp3");
            Console.WriteLine("Start Download");
            Console.ReadLine();
        }

        private static void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Download compelete");
        }

        private static void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("Downloaded "+e.ProgressPercentage+"%");
        }

    }
}
