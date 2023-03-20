﻿using System;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BaseClass.BD = new Entities();
            FrameClass.frame = mainFrame;
            FrameClass.frame.Navigate(new SubscribersList());
            tbHeader.Text = "Абоненты ТНС";
            cbFIOEmployee.ItemsSource = BaseClass.BD.Employees.ToList(); // Заполнение ComboBox сотрудниками
            cbFIOEmployee.SelectedValuePath = "EmployeesID";
            cbFIOEmployee.DisplayMemberPath = "FIO";
            cbFIOEmployee.SelectedIndex = 0;
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            cd.Width = 200;
            spOpen.Visibility = Visibility.Visible;
            spClose.Visibility = Visibility.Collapsed;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            cd.Width = 100;
            spOpen.Visibility = Visibility.Collapsed;
            spClose.Visibility = Visibility.Visible;
        }





        private void cbFIOEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employees employee = BaseClass.BD.Employees.FirstOrDefault(x => x.EmployeeID == cbFIOEmployee.SelectedIndex + 1);
            imUser.ImageSource = new BitmapImage(new Uri("" + employee.Image, UriKind.Relative)); // Аватарка сотрудника
            if (employee != null) // Изменение списка событий
            {
                List<Events> events = BaseClass.BD.Events.Where(x => x.RoleID == employee.RoleID).ToList();
                lvEvents.ItemsSource = events.OrderBy(x => x.EventDate);
            }
            List<AvailableModules> availableModules = BaseClass.BD.AvailableModules.Where(x => x.RoleID == employee.RoleID).ToList(); // Изменение доступных модулей
            imSubscriber.Visibility = Visibility.Collapsed;
            imEquipmentManagement.Visibility = Visibility.Collapsed;
            imAssets.Visibility = Visibility.Collapsed;
            imBilling.Visibility = Visibility.Collapsed;
            imUserSupport.Visibility = Visibility.Collapsed;
            imCRM.Visibility = Visibility.Collapsed;
            lbEquipmentManagement.Visibility = Visibility.Collapsed;
            lbAssets.Visibility = Visibility.Collapsed;
            lbBilling.Visibility = Visibility.Collapsed;
            lbUserSupport.Visibility = Visibility.Collapsed;
            foreach (AvailableModules module in availableModules) // Показ доступных модулей
            {
                switch (module.Modules.ModuleName)
                {
                    case "Абоненты":
                        imSubscriber.Visibility = Visibility.Visible;
                        break;
                    case "CRM":
                        imEquipmentManagement.Visibility = Visibility.Visible;
                        lbEquipmentManagement.Visibility = Visibility.Visible;
                        break;
                    case "Биллинг":
                        imAssets.Visibility = Visibility.Visible;
                        lbAssets.Visibility = Visibility.Visible;
                        break;
                    case "Поддержка пользователей":
                        imBilling.Visibility = Visibility.Visible;
                        lbBilling.Visibility = Visibility.Visible;
                        break;
                    case "Управление оборудованием":
                        imUserSupport.Visibility = Visibility.Visible;
                        lbUserSupport.Visibility = Visibility.Visible;
                        break;
                    case "Активы":
                        imCRM.Visibility = Visibility.Visible;
                        break;
                }
            }
        }

        private void btnUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var scrollViwer = GetScrollViewer(lvEvents) as ScrollViewer;
            if (scrollViwer != null)
            {
                scrollViwer.ScrollToVerticalOffset(scrollViwer.VerticalOffset - 1);
            }
        }

        private void btnDown_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var scrollViwer = GetScrollViewer(lvEvents) as ScrollViewer;
            if (scrollViwer != null)
            {
                scrollViwer.ScrollToVerticalOffset(scrollViwer.VerticalOffset + 1);
            }
        }

        public static DependencyObject GetScrollViewer(DependencyObject o)
        {
            if (o is ScrollViewer)
            { return o; }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++)
            {
                var child = VisualTreeHelper.GetChild(o, i);

                var result = GetScrollViewer(child);
                if (result == null)
                {
                    continue;
                }
                else
                {
                    return result;
                }
            }
            return null;
        }
    }
}
