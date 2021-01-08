﻿using Sdl.LanguagePlatform.Core;
using Sdl.ProjectAutomation.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
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

namespace OpusCatTranslationProvider
{
    /// <summary>
    /// Interaction logic for OpusCatOptions.xaml
    /// </summary>
    public partial class OpusCatOptionControl : UserControl, INotifyPropertyChanged, IHasOpusCatOptions
    {


        public OpusCatOptionControl(OpusCatOptionsFormWPF hostForm, OpusCatOptions options, Sdl.LanguagePlatform.Core.LanguagePair[] languagePairs)
        {
            this.DataContext = this;
            
            this.Options = options;
            this.projectLanguagePairs = languagePairs.Select(
                x => $"{x.SourceCulture.TwoLetterISOLanguageName}-{x.TargetCulture.TwoLetterISOLanguageName}").ToList();

            InitializeComponent();
            this.ConnectionControl.LanguagePairs = this.projectLanguagePairs;

            //Null indicates that all properties have changed. Populates the WPF form
            PropertyChanged(this, new PropertyChangedEventArgs(null));

            this.hostForm = hostForm;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private OpusCatOptions options;
        private List<string> projectLanguagePairs;
        private OpusCatOptionsFormWPF hostForm;
        
        public OpusCatOptions Options { get => options; set => options = value; }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.hostForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            this.hostForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void TagBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ConnectionControl.TagBox_SelectionChanged(sender, e);
        }
    }
}