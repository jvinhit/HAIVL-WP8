using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace HaiVLTV
{
    public partial class xemvideo : PhoneApplicationPage
    {


        string s = "https://www.youtube.com/watch?v=";
        string uri = "";
        string youtubeID = "";
        public xemvideo()
        {
            InitializeComponent();
            //var app = App.Current as App;
            //var title = app.selectedTruyen.Summary;
            //uri = s+ title.ToString();

            //plaasd();

        }
        //private async void plaasd()
        //{
        //    var url = await YouTube.GetVideoUriAsync(uri, YouTubeQuality.Quality480P);
        //    if (url != null)
        //    {
        //        player.Source = url.Uri;
        //        player.Play();
        //    }
        //    else
        //    { }
        //}

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/viewcomment.xaml", UriKind.RelativeOrAbsolute));

        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            var app = App.Current as App;
            youtubeID = app.selectedTruyen.Summary;
            var videoUri = await MyToolkit.Multimedia.YouTube.GetVideoUriAsync(youtubeID, MyToolkit.Multimedia.YouTubeQuality.Quality480P, MyToolkit.Multimedia.YouTubeQuality.Quality720P);
            if (videoUri != null)
                player.Source = videoUri.Uri;
            else
                MessageBox.Show("Lỗi kết nối");

        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            //var app = App.Current as App;
            //string hreffs = app.selectedTruyen.href;
            //string src = "✎ Clip hài Vui Lắm luôn ★★★★★. \n ✎ Đăng bởi ứng dụng HaiVL Pro trên Windows Phone" + "\n" + "✎ " + "http://haivl.tv/video/" + hreffs;
            //ShareStatusTask shareStatusTask = new ShareStatusTask();
            //shareStatusTask.Status = src;
            //shareStatusTask.Show();

            var app = App.Current as App;
            string hreffs = app.selectedTruyen.href;
            string link = "http://haivl.tv/video/" + hreffs;
            ShareLinkTask shareLinkTask = new ShareLinkTask();

            shareLinkTask.Title = "✎ Clip hài Vui Lắm luôn ★★★★★" + " ♛ By HaiVL Pro in Windows Phone";
            shareLinkTask.LinkUri = new Uri(link, UriKind.Absolute);
            shareLinkTask.Message = "Zolo";

            shareLinkTask.Show();
        }

       
      


        //Regex rx;
        //Match match;
        //private void ClientDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        //{
        //    rx = new Regex("(?<=url_encoded_fmt_stream_map=)([^(\\\\)]*)(?=\\\\)", RegexOptions.IgnoreCase);
        //    match = rx.Matches(flashvars);
        //    string video_format = match[0].ToString();

        //    string sep1 = "%2C";
        //    string sep2 = "%26";
        //    string sep3 = "%3D";
        //    string link = "";
        //    string[] videoFormatsGroup = Regex.Split(video_format, sep1);
        //    for (var i = 0; i < videoFormatsGroup.Length; i++)
        //    {
        //        string[] videoFormatsElem = Regex.Split(videoFormatsGroup[i], sep2);
        //        if (videoFormatsElem.Length < 5) continue;
        //        string[] partialResult1 = Regex.Split(videoFormatsElem[0], sep3);
        //        if (partialResult1.Length < 2) continue;
        //        string url = partialResult1[1];
        //        url = HttpUtility.UrlDecode(HttpUtility.UrlDecode(url));
        //        string[] partialResult2 = Regex.Split(videoFormatsElem[4], sep3);
        //        if (partialResult2.Length < 2) continue;
        //        int itag = Convert.ToInt32(partialResult2[1]);
        //        if (itag == 18)
        //        {
        //            link = url;
        //        }
        //    }
        //}
    }
}