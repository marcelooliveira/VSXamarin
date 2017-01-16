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
using SQLite;
using TestDrive.Data;
using System.IO;
using TestDrive2.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_android))]
namespace TestDrive2.Droid
{
    public class SQLite_android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "Agendamento.db3";
            string documentsPath = 
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);

            return new SQLite.SQLiteConnection(path);
        }
    }
}