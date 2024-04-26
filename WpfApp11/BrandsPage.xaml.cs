using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp11.CarsShowroommDataSetTableAdapters;

namespace WpfApp11
{
    public partial class BrandsPage : Page
    {
            BrandsTableAdapter brands = new BrandsTableAdapter();
            public BrandsPage()
            {
                InitializeComponent();
                BD_Brands.ItemsSource = brands.GetData();
            }

            private void add_Click(object sender, RoutedEventArgs e)
            {
                brands.InsertQuery1(text1.Text);
                BD_Brands.ItemsSource = brands.GetData();
            }

            private void edit_Click(object sender, RoutedEventArgs e)
            {
                object id = (BD_Brands.SelectedItem as DataRowView).Row[0];
                brands.UpdateQuery(text1.Text, Convert.ToInt32(id));
                BD_Brands.ItemsSource = brands.GetData();
            }

            private void delete_Click(object sender, RoutedEventArgs e)
            {
                object id = (BD_Brands.SelectedItem as DataRowView).Row[0];
                brands.DeleteQuery(Convert.ToInt32(id));
                BD_Brands.ItemsSource = brands.GetData();
            }

            private void BD_Brands_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (BD_Brands.SelectedItem != null)
                {
                    DataRowView row = BD_Brands.SelectedItem as DataRowView;
                    if (row != null)
                    {
                        text1.Text = row.Row["BrandName"].ToString();
                    }
                }
            }
        }
    }