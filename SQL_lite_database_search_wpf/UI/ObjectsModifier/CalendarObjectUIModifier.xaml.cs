﻿using FirstFloor.ModernUI.Windows.Controls;
using SQL_lite_database_search_wpf.Core;
using System;
using System.Windows;

namespace SQL_lite_database_search_wpf.UI
{
    /// <summary>
    /// Interaction logic for Add_Project.xaml
    /// </summary>
    public partial class Add_Project : ModernWindow
    {
        public string parentTable { get { return UICalendarInformation.ParentTable; } set { UICalendarInformation.ParentTable = value; } }

        public Add_Project()
        {
            InitializeComponent();
        }
        public calendarObject CalendarObject { get { return UICalendarInformation.CalendarObject; } }

        public Add_Project(calendarObject cObj)
        {
            InitializeComponent();
            UICalendarInformation.CalendarObject = cObj;
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
