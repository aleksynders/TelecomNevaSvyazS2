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

namespace TelecomNevaSvyazS2
{
    /// <summary>
    /// Логика взаимодействия для SubscribersList.xaml
    /// </summary>
    /// 
    
    public partial class SubscribersList : Page
    {
        bool b;
        public SubscribersList()
        {
            InitializeComponent();
            b = true;
            dgSubscribers.ItemsSource = BaseClass.BD.Subscribers.ToList();
            List<Raions> raions = BaseClass.BD.Raions.ToList(); // Заполнение районов
            cbFilterRaion.Items.Add("Все районы");
            foreach (Raions raion in raions)
            {
                cbFilterRaion.Items.Add(raion.RaionName);
            }
            cbFilterRaion.SelectedIndex = 0;
            cbFilterStreet.IsEnabled = false;
            cbFiltNomerHouse.IsEnabled = false;
        }

        private void tbSearchSurname_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void cbFilterRaion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
