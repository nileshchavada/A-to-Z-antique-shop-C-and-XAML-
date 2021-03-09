
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace A_to_Z_Antique_Shop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        public static ObservableCollection<items> _items;
        public static ObservableCollection<Bill>_bill;


        public static bool _updateFile = true;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
           _bill = Bill_Storage.ReadXml<ObservableCollection<Bill>>("Bill.xml");
            if (_bill == null)
                _bill = new ObservableCollection<Bill>();
            _items = items_Storage.ReadXml<ObservableCollection<items>>("items.xml");
            if (_items == null)
            {
                var toDo = MessageBox.Show("File not found or corrupted. \n\nDo you want to generate some data?\nPlease click\n\n 'Yes' to generate test data;\n 'No' to start from scratch\n 'Cancel' to exit the application", "Warning",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel);


                switch (toDo)
                {
                    case MessageBoxResult.Yes:
                        _items = MyMethods.GenerateItems();
                        break;
                    case MessageBoxResult.No:
                        _items = new ObservableCollection<items>();
                        break;
                    default:
                        _updateFile = false;
                        App.Current.Shutdown();
                        break;
                }
            }
            //  _items = new ObservableCollection<items>();
             
        }


        private void Application_Exit(object sender, ExitEventArgs e)
        {
            items_Storage.WriteXml(_items, "items.xml");

            
           Bill_Storage.WriteXml(_bill, "Bill.xml");
        }

       

       
    }
}


