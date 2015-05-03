using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiVLTV
{
    public class Data : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string ti;

        public string Title
        {
            get
            { return ti; }
            set
            {
                ti = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Title"));
                }
            }
        }

        string cover;

        public string Imgsrc
        {
            get { return cover; }
            set
            {
                cover = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Imgsrc"));
                }
            }
        }
        private string summa;

        public string Summary
        {
            get { return summa; }
            set
            {
                summa = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Summary"));
                }
            }
        }

        private string view;

        public string View
        {
            get { return view; }
            set { view = value; }
        }
        private string contenthtml;

        public string ContentHTML
        {
            get { return contenthtml; }
            set { contenthtml = value; }
        }

        private string comments;

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }



        public string href { get; set; }


    }
}
