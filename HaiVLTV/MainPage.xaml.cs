using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using HaiVLTV.Resources;
using System.Net.Http;
using HtmlAgilityPack;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Threading;

namespace HaiVLTV
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Data member
        string urls = "http://haivl.tv/";
        ObservableCollection<Data> datas = new ObservableCollection<Data>();
        string updateurls = "http://haivl.tv/new/";
        string urlshot = "http://haivl.tv/hot/";
        private int i = 1;
        private int so = 1;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            loadtdata();
        }

        #region loaddata khi vua khoi tao
        // Ham loaddata khi vua vao chuong trinh
        private async void loadtdata()
        {
            datas.Clear();
            string htmlPage = "";
            using (var client = new HttpClient())
            {
                htmlPage = await client.GetStringAsync(urls);
            }
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlPage);
            //foreach (var div in htmlDocument.DocumentNode.SelectNodes("//div[starts-with(@class, 'item')]"))
            //('//div[@id[starts-with(.,"post_message")]]')
            string s = ".//div[starts-with(@class,'videoList')]//div[@class='videoListItem']";
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(s);
            foreach (var div in nodes)
            {
                Data newdata = new Data();
                newdata.Imgsrc = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']//img").Attributes["src"].Value;
                //newdata.Title = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']//img").Attributes["alt"].Value;
                newdata.Title = div.SelectSingleNode(".//h2//a").InnerText.Trim();
                newdata.href = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']").GetAttributeValue("data-id", String.Empty).ToString();
                newdata.Summary = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']").GetAttributeValue("data-youtubeid", String.Empty).ToString();
                newdata.View = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='views']").InnerText.Trim();
                newdata.Comments = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='comments']").InnerText.Trim();
                newdata.ContentHTML = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='views']").InnerText.Trim();
                //newdata.Summary = div.SelectSingleNode("//div[@class='item-content']//span").InnerText.Trim();
                datas.Add(newdata);
            }

            
            lstScanweb.ItemsSource = datas;
            fuckyouvideo.Visibility = Visibility.Visible;
            fuckyou.Visibility = Visibility.Collapsed;
        }
        #endregion
        #region selectionschanged listbox item
        // selectionchaged listbox
        private void lstScanweb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var app = App.Current as App;
            //app.selectedTruyen = (Data)lstScanweb.SelectedItem;
            //this.NavigationService.Navigate(new Uri("/dsChuong.xaml", UriKind.Relative));
        }
        #endregion
        #region LoadData Them clip
        private async void dauma_Click(object sender, EventArgs e)
        {
            i++;
            urls = updateurls + i;
            string htmlPage = "";
            using (var client = new HttpClient())
            {
                htmlPage = await client.GetStringAsync(urls);
            }
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlPage);
            //foreach (var div in htmlDocument.DocumentNode.SelectNodes("//div[starts-with(@class, 'item')]"))
            //('//div[@id[starts-with(.,"post_message")]]')
            string s = ".//div[starts-with(@class,'videoList')]//div[@class='videoListItem']";
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(s);
            foreach (var div in nodes)
            {
                Data newdatan = new Data();
                newdatan.Imgsrc = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']//img").Attributes["src"].Value;
                //newdata.Title = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']//img").Attributes["alt"].Value;
                newdatan.Title = div.SelectSingleNode(".//h2//a").InnerText.Trim();
                newdatan.href = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']").GetAttributeValue("data-id", String.Empty).ToString();
                newdatan.Summary = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']").GetAttributeValue("data-youtubeid", String.Empty).ToString();
                newdatan.View = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='views']").InnerText.Trim();
                newdatan.Comments = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='comments']").InnerText.Trim();
                newdatan.ContentHTML = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='views']").InnerText.Trim();
                datas.Add(newdatan);
            }
            lstScanweb.ItemsSource = datas;
            //if (lstScanweb.Items.Count > 0)
            //{
            //    var lastItem = lstScanweb.Items[lstScanweb.Items.Count - 1];
            //    lstScanweb.UpdateLayout();
            //    lstScanweb.ScrollIntoView(lastItem);
            //}
            lstScanweb.UpdateLayout();
            lstScanweb.ScrollIntoView(lstScanweb.Items[lstScanweb.Items.Count - 8]);
            fuckyouvideo.Visibility = Visibility.Visible;
            fuckyou.Visibility = Visibility.Collapsed;
        }
        #endregion
        #region cliphot
        private async void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            datas.Clear();
            string htmlPage = "";
            using (var client = new HttpClient())
            {
                htmlPage = await client.GetStringAsync(urlshot);
            }
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlPage);
            //foreach (var div in htmlDocument.DocumentNode.SelectNodes("//div[starts-with(@class, 'item')]"))
            //('//div[@id[starts-with(.,"post_message")]]')
            string s = ".//div[starts-with(@class,'videoList')]//div[@class='videoListItem']";
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(s);
            foreach (var div in nodes)
            {
                Data newdatan = new Data();
                newdatan.Imgsrc = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']//img").Attributes["src"].Value;
                //newdata.Title = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']//img").Attributes["alt"].Value;
                newdatan.Title = div.SelectSingleNode(".//h2//a").InnerText.Trim();
                newdatan.href = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']").GetAttributeValue("data-id", String.Empty).ToString();
                newdatan.Summary = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']").GetAttributeValue("data-youtubeid", String.Empty).ToString();
                newdatan.View = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='views']").InnerText.Trim();
                newdatan.Comments = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='comments']").InnerText.Trim();
                newdatan.ContentHTML = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='views']").InnerText.Trim();
                datas.Add(newdatan);
            }
            lstScanweb.ItemsSource = datas;
            fuckyou.Visibility = Visibility.Visible;
            fuckyouvideo.Visibility = Visibility.Collapsed;
        }
        #endregion
        #region Tap Image play navigation sang trang xem video
        private void Image_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var app = App.Current as App;
            app.selectedTruyen = (Data)lstScanweb.SelectedItem;
            this.NavigationService.Navigate(new Uri("/xemvideo.xaml", UriKind.Relative));
        }
        #endregion


        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.RelativeOrAbsolute));
        }

        private async void loadhot_Click(object sender, RoutedEventArgs e)
        {

            so++;
            string sss = urlshot + so;
            string htmlPage = "";
            using (var client = new HttpClient())
            {
                htmlPage = await client.GetStringAsync(sss);
            }
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlPage);
            //foreach (var div in htmlDocument.DocumentNode.SelectNodes("//div[starts-with(@class, 'item')]"))
            //('//div[@id[starts-with(.,"post_message")]]')
            string s = ".//div[starts-with(@class,'videoList')]//div[@class='videoListItem']";
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(s);
            foreach (var div in nodes)
            {
                Data newdatan = new Data();
                newdatan.Imgsrc = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']//img").Attributes["src"].Value;
                //newdata.Title = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']//img").Attributes["alt"].Value;
                newdatan.Title = div.SelectSingleNode(".//h2//a").InnerText.Trim();
                newdatan.href = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']").GetAttributeValue("data-id", String.Empty).ToString();
                newdatan.Summary = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']").GetAttributeValue("data-youtubeid", String.Empty).ToString();
                newdatan.View = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='views']").InnerText.Trim();
                newdatan.Comments = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='comments']").InnerText.Trim();
                newdatan.ContentHTML = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='views']").InnerText.Trim();
                datas.Add(newdatan);
            }
            lstScanweb.ItemsSource = datas;
            lstScanweb.UpdateLayout();
            lstScanweb.ScrollIntoView(lstScanweb.Items[lstScanweb.Items.Count - 8]);

        }

        private async void loadvideo_Click(object sender, RoutedEventArgs e)
        {

            i++;
            urls = updateurls + i;
            string htmlPage = "";
            using (var client = new HttpClient())
            {
                htmlPage = await client.GetStringAsync(urls);
            }
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlPage);
            //foreach (var div in htmlDocument.DocumentNode.SelectNodes("//div[starts-with(@class, 'item')]"))
            //('//div[@id[starts-with(.,"post_message")]]')
            string s = ".//div[starts-with(@class,'videoList')]//div[@class='videoListItem']";
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes(s);
            foreach (var div in nodes)
            {
                Data newdatan = new Data();
                newdatan.Imgsrc = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']//img").Attributes["src"].Value;
                //newdata.Title = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']//img").Attributes["alt"].Value;
                newdatan.Title = div.SelectSingleNode(".//h2//a").InnerText.Trim();
                newdatan.href = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']").GetAttributeValue("data-id", String.Empty).ToString();
                newdatan.Summary = div.SelectSingleNode(".//div[@class='thumb']//a[@class='play']").GetAttributeValue("data-youtubeid", String.Empty).ToString();
                newdatan.View = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='views']").InnerText.Trim();
                newdatan.Comments = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='comments']").InnerText.Trim();
                newdatan.ContentHTML = div.SelectSingleNode(".//div[@class='stats']//div[@class='numbers']//span[@class='views']").InnerText.Trim();
                datas.Add(newdatan);
            }
            lstScanweb.ItemsSource = datas;
            lstScanweb.UpdateLayout();
            lstScanweb.ScrollIntoView(lstScanweb.Items[lstScanweb.Items.Count - 8]);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void btnReFresh_Click(object sender, EventArgs e)
        {
            loadtdata();
        }

        private void xxx_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var app = App.Current as App;
            app.selectedTruyen = (Data)lstScanweb.SelectedItem;
            NavigationService.Navigate(new Uri("/viewcomment.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}