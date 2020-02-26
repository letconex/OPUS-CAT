﻿using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpusMTService
{
    /// <summary>
    /// Interaction logic for ListBoxWithControls.xaml
    /// </summary>
    public partial class ListBoxWithControls : UserControl
    {

        public ListBoxWithControls()
        {
            InitializeComponent();
            this.DataContextChanged += dataContextChanged;
        }

        private void dataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }
        
        
        private void btnAddOnlineModel_Click(object sender, RoutedEventArgs e)
        {
            OnlineModelSelection onlineSelection = new OnlineModelSelection();
            onlineSelection.DataContext = this.DataContext;
            onlineSelection.Show();
        }

        private void btnAddZipModel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".zip"; // Default file extension
            dlg.Filter = "Zip files (.zip)|*.zip"; // Filter files by extension

            // Show open file dialog box
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                
            }
        }

        private void btnDeleteModel_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void LbTodoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}