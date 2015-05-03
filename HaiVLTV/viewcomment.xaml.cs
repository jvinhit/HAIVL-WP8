using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using vservWindowsPhone;
using System.Threading;


namespace HaiVLTV
{
    public partial class viewcomment : PhoneApplicationPage
    {
        VservAdControl VAC;

        public viewcomment()
        {
            InitializeComponent();
            VAC = VservAdControl.Instance;
            this.Loaded += AppView_Loaded; //Event for Showing Ad on Start
            VAC.SetRequestTimeOut(30);
            VAC.VservAdClosed += new EventHandler(VACCallback_OnVservAdClosing);
            VAC.VservAdError += new EventHandler(VACCallback_OnVservAdNetworkError);
            VAC.VservAdNoFill += new EventHandler(VACCallback_OnVservAdNoFill);
            // Setting test mode. Please dont forget to comment below line before going live.
            VAC.SetTestMode(true);
            commentfb.Loaded += commentfb_Loaded;
        }
       
        void VACCallback_OnVservAdClosing(object sender, EventArgs e)
        {
            MessageBox.Show("Quảng Cáo được đóng bởi user", "Interstitial Ad", MessageBoxButton.OK);
        
        }
        void VACCallback_OnVservAdNetworkError(object sender, EventArgs e)
        {
            MessageBox.Show("Lỗi kết nối mạng", "No Data", MessageBoxButton.OK);
        }

        void VACCallback_OnVservAdNoFill(object sender, EventArgs e)
        {
            if (adGrid != null)
                adGrid.Visibility = Visibility.Collapsed;
        }
        private void AppView_Loaded(object sender, RoutedEventArgs e)
        {
            VAC.DisplayAd("4eb4b525"/*Billboard Zone Id*/, adGrid/* Layout over which the Ad will be displayed*/);


        }



   
        private bool _hasChanges = false;

        //private void browser_ScriptNotify_1(object sender, NotifyEventArgs e)
        //{
        //    this._hasChanges = true;
        //}
        private  void commentfb_Loaded(object sender, RoutedEventArgs e)
        {
            var app = App.Current as App;
            string hreffs = app.selectedTruyen.href;
            string s = "https://m.facebook.com/plugins/comments.php?api_key=181604928677768&channel_url=http%3A%2F%2Fstatic.ak.facebook.com%2Fconnect%2Fxd_arbiter%2FbLBBWlYJp_w.js%3Fversion%3D41%23cb%3Df90fe3b64%26domain%3Dhaivl.tv%26origin%3Dhttp%253A%252F%252Fhaivl.tv%252Ff111c4e61c%26relation%3Dparent.parent&href=http%3A%2F%2Fhaivl.tv%2Fvideo%2F" + hreffs + "&amp;locale=en_US&amp;numposts=10&amp;sdk=joey&amp;width=100%";
            commentfb.Navigate(new Uri(s, UriKind.Absolute));
            Thread.Sleep(600);
            thongbao.Visibility = Visibility.Collapsed;

            //var app = App.Current as App;
            //string hreffs = app.selectedTruyen.href;
            ////string s = "https://www.facebook.com/plugins/comments.php?api_key=181604928677768&channel_url=http%3A%2F%2Fstatic.ak.facebook.com%2Fconnect%2Fxd_arbiter%2FbLBBWlYJp_w.js%3Fversion%3D41%23cb%3Df90fe3b64%26domain%3Dhaivl.tv%26origin%3Dhttp%253A%252F%252Fhaivl.tv%252Ff111c4e61c%26relation%3Dparent.parent&href=http%3A%2F%2Fhaivl.tv%2Fvideo%2F" + hreffs + "&amp;locale=en_US&amp;numposts=5&amp;sdk=joey&amp;width=480";
            //string s = "<div><iframe  src=\"https://www.facebook.com/plugins/comments.php?api_key=181604928677768&amp;channel_url=http%3A%2F%2Fstatic.ak.facebook.com%2Fconnect%2Fxd_arbiter%2FbLBBWlYJp_w.js%3Fversion%3D41%23cb%3Dfa83feb34%26domain%3Dhaivl.tv%26origin%3Dhttp%253A%252F%252Fhaivl.tv%252Ff2ff04f084%26relation%3Dparent.parent&amp;href=http%3A%2F%2Fhaivl.tv%2Fvideo%2F"+hreffs+"&amp;locale=en_US&amp;numposts=5&amp;sdk=joey&amp;width=100%\" style=\"border: none; overflow: hidden; height: 2000px;\"></iframe></div>";
            ////commentfb.Navigate(new Uri(s, UriKind.Absolute));
            //commentfb.NavigateToString(s);
            //Thread.Sleep(900);
            //thongbao.Visibility = Visibility.Collapsed;
            
        }
        private void Display_Ad(object sender, RoutedEventArgs e)
        {
            // This Method is called for showing Interstitial Ad
            VAC.DisplayAd("4eb4b525"/*Billboard Zone Id*/, LayoutRoot/* Layout over which the Ad will be displayed*/);
        }
        private void Quit_MenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Release Vserv Ad Control");
            VAC.Release();
            Application.Current.Terminate();
        }
        Stack<Uri> history = new Stack<Uri>();
        Uri current = null; 
        //private void commentfb_Navigated(object sender, NavigationEventArgs e)
        //{
        //    Uri previous = null;
        //    if (history.Count > 0)
        //        previous = history.Peek();

        //    // This assumption is NOT always right. 
        //    // if the page had a forward reference that creates a loop (e.g. A->B->A ), 
        //    // we would not detect it, we assume it is an A -> B -> back () 
        //    if (e.Uri == previous)
        //    {
        //        history.Pop();
        //    }
        //    else
        //    {
        //        if (current != null)
        //            history.Push(current);
        //    }
        //    current = e.Uri; 
        //}
        //protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        //{
        //    base.OnBackKeyPress(e);

          
        //        if (history.Count > 0)
        //        {
        //            Uri destination = history.Peek();
        //            commentfb.Navigate(destination);
        //            // What about using script and going history.back? 
        //            // you can do it, but 
        //            // I rather use that to keep ‘track’ consistently with our stack 
        //            e.Cancel = true;
        //        }
           
        //}
    }
}