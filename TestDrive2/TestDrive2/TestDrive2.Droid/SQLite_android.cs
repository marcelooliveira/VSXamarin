using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using SQLite;
using System.IO;
using AluraNutricao.Droid;
using AluraNutricao.Data;

[assembly: Dependency(typeof(SQLite_android))]
namespace AluraNutricao.Droid
{
    public class SQLite_android : ISQLite
    {
        public SQLite_android()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "Agendamento.db3";

            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}