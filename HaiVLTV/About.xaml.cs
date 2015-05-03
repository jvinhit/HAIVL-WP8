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
using Microsoft.Phone.Info;
using Microsoft.Phone.Tasks;
using System.IO.IsolatedStorage;

namespace HaiVLTV
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
            string s = App.Getversion().ToString();
            txtAppVersion.Text += " " + s;
            txtCright.Text = AppResources.copy;
            txtNoiDung1.Text = AppResources.noidung1;
            txtFeedBack.Text = AppResources.noidung2;
            txtReview.Text = AppResources.noidung3;
        }
        private void Feedback()
        {
            var asm = System.Reflection.Assembly.GetCallingAssembly();
            var parts = asm.FullName.Split(',');
            var version = parts[1].Split('=')[1];
            string s = PhoneNameResolver.Resolve(DeviceStatus.DeviceManufacturer, DeviceStatus.DeviceName).FullCanonicalName.ToString();

            //string body = string.Format("->[Your feedback here]-<{0}---------------------------------{0}Device: {1}{0} Manufacturer: {2}{0}OS Version: {3}{0}App Version: {4}{0}---------------------------------{0}{5}",Environment.NewLine,DeviceStatus.DeviceName, DeviceStatus.DeviceManufacturer, Environment.OSVersion.Version.ToString(), version, "Send from my Windows Phone");
            string body = string.Format("->[Your feedback here]-<{0}---------------------------------{0}Device: {1}{0}OS Windows: {2}{0}App Version: {3}{0}---------------------------------{0}{4}", Environment.NewLine, s, Environment.OSVersion.Version.ToString(), version, "Send from my Windows Phone");
            var email = new EmailComposeTask();
            email.To = AppResources.FeedbackTo;
            email.Subject = AppResources.FeedbackSubject;
            email.Body = body;
            email.Show();
        }
        private void thongbao()
        {
            var askforReview = (bool)IsolatedStorageSettings.ApplicationSettings["askforreview"];
            if (askforReview)
            {
                IsolatedStorageSettings.ApplicationSettings["askforreview"] = false;
                IAsyncResult result = Microsoft.Xna.Framework.GamerServices.Guide.BeginShowMessageBox(AppResources.RatingTitle, AppResources.RatingMessage1, new string[] { AppResources.RatingYes, AppResources.RatingNo }, 0, Microsoft.Xna.Framework.GamerServices.MessageBoxIcon.Alert, null, null);
                result.AsyncWaitHandle.WaitOne();
                int? choice = Microsoft.Xna.Framework.GamerServices.Guide.EndShowMessageBox(result);
                if (choice.HasValue)
                {
                    if (choice.Value == 0)
                    {
                        var marketPlaceTask = new MarketplaceReviewTask();
                        marketPlaceTask.Show();
                    }
                    else
                        if (choice.Value == 1)
                        {
                            IAsyncResult result1 = Microsoft.Xna.Framework.GamerServices.Guide.BeginShowMessageBox(AppResources.FeedbackTitle, AppResources.FeedbackMessage1, new string[] { AppResources.FeedbackYes, AppResources.FeedbackNo }, 0, Microsoft.Xna.Framework.GamerServices.MessageBoxIcon.Alert, null, null);
                            result1.AsyncWaitHandle.WaitOne();
                            int? choice1 = Microsoft.Xna.Framework.GamerServices.Guide.EndShowMessageBox(result1);
                            if (choice.HasValue)
                            {
                                {
                                    if (choice1.Value == 0)
                                        Feedback();
                                }
                            }
                        }
                }
            }
        }
        private void btnReview_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings.ApplicationSettings["askforreview"] = true;
            thongbao();
        }

        private void btnFeedback_Click(object sender, RoutedEventArgs e)
        {
            Feedback();
        }
    }
}