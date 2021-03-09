using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Win32;

namespace A_to_Z_Antique_Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //  List<items> items;


        public MainWindow()
        {
             InitializeComponent();
             

        }

        DoubleAnimation da = new DoubleAnimation(20, TimeSpan.FromSeconds(1.5));
        private void Grd_Menu_MouseEnter(object sender, MouseEventArgs e)
        {
            da.To = 150;
            Grd_Menu.BeginAnimation(Grid.WidthProperty, da);
        }

        private void Grd_Menu_MouseLeave(object sender, MouseEventArgs e)
        {
            da.To = 20;
            Grd_Menu.BeginAnimation(Grid.WidthProperty, da);
        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            {
                // items = (List<items>)CreateitemsData(20);
                // App._items = CreateitemsData(20);
                Lbx_Items.ItemsSource = App._items;
            }
        }

      //  private ObservableCollection<items> CreateitemsData(int cnt)
       // {
         //   {
           //     var lst = new ObservableCollection<items>();
             //   for (int i = 0; i < cnt; i++)
               // {
               //     lst.Add(new items { ItemName = $"add item {i}", yearofmade = 2018, Category = $"Select Category {i}", descreption = $"write descreption {i}", price = 0 });
                //}
                //return lst;
           // }
       // }

        private void Tbx_Filter_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (App._items == null) return;
            var filter = (sender as TextBox).Text.ToLower();
            // var filter1 = (sender as TextBox).Text.ToLower();
            var result = from s in App._items where  s.yearofmade.ToString().Contains(filter) select s;
            // orderby s.ItemName.ToLower().Contains(filter)select s;
            var result1 = from s in App._items where s.ItemName.ToLower().Contains(filter) select s;
            Lbx_Items.ItemsSource = result;
            Lbx_Items.ItemsSource = result1;

        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            

            var itm = new items { ItemName = "Add Item Name", yearofmade = 2000, Category="Select Category",descreption="Write descreption",price=0, imagePath = "/Images/ADD image.png" };
            App._items.Add(itm);
            Lbx_Items.ScrollIntoView(itm);
            Lbx_Items.SelectedItem = itm;

        }

        private void Btn_del_Click(object sender, RoutedEventArgs e)
        {
            var itm = Lbx_Items.SelectedItem as items;
            if (itm == null)
            {
                MessageBox.Show("please select item first to be deleted ", "Hint");
                return;
        
            }
            App._items.Remove(itm);
        }


       

        

        private void btn_Bill_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window1();
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Collapsed;
        }


      

        private void Lbx_items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Img_profile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.PNG; *.JPG;*.JPEG)|*.PNG; *.JPG;*.JPEG";
            var result = dlg.ShowDialog();
            if (result == true)
                (Lbx_Items.SelectedItem as items).imagePath = dlg.FileName;

        }
    }
}
