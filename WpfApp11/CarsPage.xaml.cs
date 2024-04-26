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
    public partial class CarsPage : Page
    {
        CarTableAdapter car = new CarTableAdapter();
    public CarsPage()
    {
        InitializeComponent();
            BD_Car.ItemsSource = car.GetData();
    }

    private void add_Click(object sender, RoutedEventArgs e)
    {
        try
        {
                car.InsertQuery(Convert.ToInt32(text1.Text), Convert.ToInt32(text2.Text), text3.Text, Convert.ToInt32(text3.Text));
                BD_Car.ItemsSource = car.GetData();
        }
        catch
        {
            MessageBox.Show("Не существует машины с таким брендом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            object id = (BD_Car.SelectedItem as DataRowView).Row[0];
            car.UpdateQuery(Convert.ToInt32(text1.Text), Convert.ToInt32(text2.Text), text3.Text, 0, Convert.ToInt32(id));
            BD_Car.ItemsSource = car.GetData();
        }


        private void delete_Click(object sender, RoutedEventArgs e)
    {
        object id = (BD_Car.SelectedItem as DataRowView).Row[0]; 
            car.DeleteQuery(Convert.ToInt32(id));
            BD_Car.ItemsSource = car.GetData();
    }

    private void BD_Vehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (BD_Car.SelectedItem != null)
        {
            DataRowView row = BD_Car.SelectedItem as DataRowView;
            if (row != null)
            {
                text1.Text = row.Row["Brand_ID"].ToString();
                text2.Text = row.Row["Years"].ToString();
                text3.Text = row.Row["Price"].ToString();
            }
        }
    }
}
}