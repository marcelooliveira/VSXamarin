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
        public SQLiteConnection PegarConexao()
        {
            var sqliteFilename = "Agendamento.db3";

            var path = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, 
                sqliteFilename);

            return new SQLite.SQLiteConnection(path);
        }
    }
}