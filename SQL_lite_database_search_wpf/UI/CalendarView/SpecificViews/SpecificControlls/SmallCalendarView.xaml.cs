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

namespace SQL_lite_database_search_wpf.UI.CalendarView.SpecificViews.SpecificControlls
{
    /// <summary>
    /// Interaction logic for SmallCalendarView.xaml
    /// </summary>
    public partial class SmallCalendarView : UserControl
    {
        calendarObject CalendarObject { get; set; }

        public SmallCalendarView(calendarObject cObj, int height = 0)
        {
            InitializeComponent();
            CalendarObject = cObj;

            this.Background = new SolidColorBrush(cObj.color.value);
            this.UITbName.Text = cObj.name.value;

            if (cObj.description.value != "" && cObj.description.value != null)
            {
                this.ToolTip = cObj.description.value;
            }
            if (height != 0) this.Height = height;
        }

        private void UIMenuChangeColor_Click(object sender, RoutedEventArgs e) { UI.UIObjectManager.ChangeCalendarObjectColor(CalendarObject); }
        private void UIMenuChangeItem_Click(object sender, RoutedEventArgs e) { UI.UIObjectManager.ChangeCalendarObject(CalendarObject); }
    }
}
