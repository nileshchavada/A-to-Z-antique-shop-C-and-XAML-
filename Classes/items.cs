using System;
using System.ComponentModel;

namespace A_to_Z_Antique_Shop
{
    public class items : INotifyPropertyChanged

    {
        public string ItemName { get; set; }
        public int yearofmade { get; set; }
        public string Category { get; set; }
        public string descreption { get; set; }
        public int price { get; set; }
        private string imagePath_ { get; set; }


        public string imagePath 
        {
            get { return imagePath_; }
                set
            {
                 if (value != imagePath_)
                {
                    imagePath_ = value;
                    OnPropertyChanged(imagePath);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }
    }

    public interface INotifyPropertyChanged
    {
    }
}