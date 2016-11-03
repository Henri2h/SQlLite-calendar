﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseManager
{
    public class ObjectManager
    {
        SQLiteConnection m_dbConnection { get { return Core.AppCore.dCore.m_dbConnection; } }
        static string TableProject { get { return Core.AppCore.dCore.TableProject; } }

        //add data
        public void addDataTable(string tableName, string row, string values)
        {
            try
            {

                string sql_addTable = "insert into " + tableName + " (" + row + ") values (" + values + ")";
                SQLiteCommand command_addTable = new SQLiteCommand(sql_addTable, m_dbConnection);
                command_addTable.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                ex.Source = "db_SQLite.addDataTable";
                ErrorHandeler.ErrorMessage.printOut(ex);

                Core.AppCore.Wi.showMessageBox(ex.Message, "SQLite Error");
            }
        }


        /// <summary>
        /// Convert reader to CalendarObject
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static calendarObject readerToCobj(SQLiteDataReader reader)
        {
            if (reader != null)
            {
                calendarObject obj = new calendarObject();
                obj.name.value = reader[obj.name.valueName].ToString();

                // obj.ID = Convert.ToInt32(reader["_rowid_"].ToString());

                obj.domaine.value = (reader[obj.domaine.valueName].ToString());
                obj.priorite.value = int.Parse(reader[obj.priorite.valueName].ToString());
                obj.description.value = reader[obj.description.valueName].ToString();
                obj.completion.value = int.Parse(reader[obj.completion.valueName].ToString());
                obj.equipe.value = reader[obj.equipe.valueName].ToString();
                obj.startTime.value = DateTime.FromBinary(long.Parse(reader[obj.startTime.valueName].ToString()));
                obj.endTime.value = DateTime.FromBinary(long.Parse(reader[obj.endTime.valueName].ToString()));
                return obj;
            }
            return null;
        }
        public static List<calendarObject> readerToCobjs(SQLiteDataReader reader)
        {
            List<calendarObject> cObjs = new List<calendarObject>();
            while (reader.Read())
            {
                if (reader != null)
                {
                    cObjs.Add(readerToCobj(reader));
                }
            }
            return cObjs;
        }
        public static Project readerToProject(SQLiteDataReader reader)
        {
            if (reader != null)
            {
                Project prj = new Project();
                prj.events = new List<calendarObject>();
                prj.name.value = reader[prj.name.valueName].ToString();
                prj.tableName = TableProject;
                prj.projectTableName = prj.name.value + "Events";
                return prj;
            }

            return null;
        }
        public static List<Project> readerToProjects(SQLiteDataReader reader)
        {
            List<Project> projects = new List<Project>();
            while (reader.Read())
            {
                if (reader != null)
                {
                    projects.Add(readerToProject(reader));
                }
            }
            return projects;
        }

    }
}
