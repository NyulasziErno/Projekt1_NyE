using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CheckBox> feladatok = new List<CheckBox>();
        List<CheckBox> toroltek = new List<CheckBox>();

        public MainWindow()
        {
            InitializeComponent();
            feladatokListaja.ItemsSource = feladatok;
            toroltekListaja.ItemsSource = toroltek;
        }

        private void uj_hozzadasa_Click(object sender, RoutedEventArgs e)
        {
            if (szovegBevitel.Text !="")
            {
                CheckBox uj = new CheckBox();
                uj.Content = szovegBevitel.Text;
                uj.Checked += new RoutedEventHandler(CheckBox_Checked);
                uj.Unchecked += new RoutedEventHandler(CheckBox_Unchecked);
                feladatok.Add(uj);
                feladatokListaja.Items.Refresh();


            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox aktualis = (CheckBox)sender;
            aktualis.FontStyle = FontStyles.Italic;
            aktualis.Foreground = Brushes.Gray;
        }

        private void torles_Click(object sender, RoutedEventArgs e)
        {
            CheckBox kijelolt = (CheckBox)feladatokListaja.SelectedItem;
            toroltek.Add(kijelolt);
            feladatok.Remove(kijelolt);
            feladatokListaja.Items.Refresh();
            toroltekListaja.Items.Refresh();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox aktualis = (CheckBox)sender;
            aktualis.FontStyle = FontStyles.Normal;
            aktualis.Foreground = Brushes.Black;
        }

        private void listakModositasa_Click(object sender, RoutedEventArgs e)
        {

            CheckBox modosit = (CheckBox)feladatokListaja.SelectedItem;
            modosit.Content = szovegBevitel.Text;
            feladatokListaja.Items.Refresh();
        }

        private void visszaallit_Click(object sender, RoutedEventArgs e)
        {
            CheckBox vissza = (CheckBox)toroltekListaja.SelectedItem;
            feladatok.Add(vissza);
            toroltek.Remove(vissza);
            feladatokListaja.Items.Refresh();
            toroltekListaja.Items.Refresh();

        }

        private void veglegesTorles_Click(object sender, RoutedEventArgs e)
        {
            CheckBox kijelolt = (CheckBox)feladatokListaja.SelectedItem;
            toroltek.Remove(kijelolt);
            CheckBox vegleges = (CheckBox)toroltekListaja.SelectedItem;
            toroltek.Remove(vegleges);
           
            toroltekListaja.Items.Refresh();
        


        }
    }
}
