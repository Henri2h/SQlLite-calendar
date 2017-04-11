﻿using SQL_lite_database_search_wpf.Core;
using SQL_lite_database_search_wpf.Core.DatabaseManager.ObjectsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.UI.CalendarView.SpecificViews
{
    public class TimeSelectionEvents
    {

        public static List<DayElement> GetDayElements(DateTime startDate, CalendarViewCore.CalendarViewMethods selectionMethod)
        {
            List<DayElement> dElem = new List<DayElement>();
            if (selectionMethod == CalendarViewCore.CalendarViewMethods.month)
            {
                startDate = startDate.AddDays(1 - startDate.Day);

                while(startDate.DayOfWeek != DayOfWeek.Monday)
                {
                    startDate = startDate.AddDays(-1);
                }

                for (int i = 0; i < 35; i++)
                {
                    DateTime dt = startDate.AddDays(i);

                    DayElement d = new DayElement();
                    d.dateTime = dt;
                    d.name = dt.Day.ToString() + " " + dt.DayOfWeek.ToString();
                    d.cobjs = new List<calendarObject>();
                    dElem.Add(d);
                }

            }
            else if (selectionMethod == CalendarViewCore.CalendarViewMethods.week)
            {
                int dayPos = 0;
                string dayW = startDate.DayOfWeek.ToString();
                string[] daysName = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
                if (daysName.Contains(dayW))
                {
                    for (int i = 0; i < daysName.Length; i++)
                    {
                        if (dayW == daysName[i]) { dayPos = i; }
                    }
                }


                for (int i = 0; i < daysName.Length; i++)
                {
                    DayElement day = new DayElement();
                    day.name = daysName[i];
                    day.dateTime = startDate.AddDays(i - dayPos);
                    day.cobjs = new List<calendarObject>();
                    dElem.Add(day);
                }
            }

            List<calendarObject> cObjs = AppCore.dCore.calendarObjectManager.listAllCalendarObjectsBySelection(Core.AppCore.mainProjectTableName, CalendarObjectManager.selectionType.isDateUsed);

            foreach (calendarObject cObj in cObjs)
            {
                for (int i = 0; i < dElem.Count; i++)
                {
                    if (Date.isDateBetween(cObj, dElem[i].dateTime))
                    {
                        dElem[i].cobjs.Add(cObj);
                    }
                    else { dElem[i].cobjs.Add(null); }
                }
            }

            return dElem;
        }


    }
}