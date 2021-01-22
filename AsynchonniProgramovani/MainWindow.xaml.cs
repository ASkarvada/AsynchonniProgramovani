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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsynchonniProgramovani
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ThreadPool tp;

        public MainWindow()
        {
            InitializeComponent();

            tp = new ThreadPool();

            condition1.Items.Add("Obsahuje čísla 5,2,1");
            condition1.Items.Add("Obsahuje 2 stejná čísla");

            condition2.Items.Add("Obsahuje čísla 5,2,1");
            condition2.Items.Add("Obsahuje 2 stejná čísla");

            condition3.Items.Add("Obsahuje čísla 5,2,1");
            condition3.Items.Add("Obsahuje 2 stejná čísla");

            condition4.Items.Add("Obsahuje čísla 5,2,1");
            condition4.Items.Add("Obsahuje 2 stejná čísla");
        }

        private async void b1_Click(object sender, RoutedEventArgs e)
        {
            int selected = condition1.SelectedIndex;
            string number;
            b1.IsEnabled = false;
            result1.Text = "Probíhá výpočet...";
            number = await tp.SearchAsync(selected);
            b1.IsEnabled = true;
            result1.Text = number;
        }

        private async void b2_Click(object sender, RoutedEventArgs e)
        {
            int selected = condition2.SelectedIndex;
            string number;
            b2.IsEnabled = false;
            result2.Text = "Probíhá výpočet...";
            number = await tp.SearchAsync(selected);
            b2.IsEnabled = true;
            result2.Text = number;
        }

        private async void b3_Click(object sender, RoutedEventArgs e)
        {
            int selected = condition3.SelectedIndex;
            string number;
            b3.IsEnabled = false;
            result3.Text = "Probíhá výpočet...";
            number = await tp.SearchAsync(selected);
            result3.Text = number;
            b3.IsEnabled = true;
        }

        private async void b4_Click(object sender, RoutedEventArgs e)
        {
            int selected = condition4.SelectedIndex;
            string number;
            b4.IsEnabled = false;
            result4.Text = "Probíhá výpočet...";
            number = await tp.SearchAsync(selected);
            result4.Text = number;
            b4.IsEnabled = true;
        }
    }
}
