using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace A_to_Z_Antique_Shop
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        

        public Window1()
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
            Lbx_Customer.ItemsSource = App._bill;
        }

      
            private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            try
                {
                    this.IsEnabled = false;
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(print, "Print Invoice");
                    }
                }
                finally
                {
                    this.IsEnabled = true;
                }


            }

        private void Tbx_Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (App._bill == null) return;
            var filter = (sender as TextBox).Text.ToLower();
            var result = from s in App._bill where s.CustomerName.ToLower().Contains(filter) select s;
            Lbx_Customer.ItemsSource = result;
           

        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {

            var cst = new Bill { CustomerName = "Write Customer Name", Phone = "000000000", ItemName = "Write item Name", price = "0", Date = DateTime.Parse($"01-1-2020") };
            App._bill.Add(cst);
            Lbx_Customer.ScrollIntoView(cst);
            Lbx_Customer.SelectedItem = cst;
        }

        private void Lbx_Customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ShowParent()
        {
            Owner.Visibility = Visibility.Visible;

        }
        private void Window_Closed(object sender, EventArgs e)
        {
            ShowParent();
        }
    }
    }

        

 