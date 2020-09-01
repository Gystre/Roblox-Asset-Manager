using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Runtime.InteropServices;

namespace Roblox_Asset_Manager_by_Kyle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists("assets"))
            {
                Directory.CreateDirectory("assets");
            }

            if (!Directory.Exists("cache"))
            {
                Directory.CreateDirectory("cache");
            }

            if (!File.Exists("assets/metadata.sqlite"))
            {
                SQLiteConnection.CreateFile("assets/metadata.sqlite");
                SQLiteConnection DBConnection;
                try
                {
                    using (DBConnection = new SQLiteConnection("Data Source=assets/metadata.sqlite;Version=3;"))
                    {
                        DBConnection.Open();
                        SQLiteCommand cmd = new SQLiteCommand("create table if not exists decals(name TEXT NOT NULL, description TEXT NOT NULL DEFAULT '', link TEXT NOT NULL, created DATETIME)", DBConnection);
                        cmd.ExecuteNonQuery();

                        DBConnection.Close();
                    }
                }catch(Exception e)
                {
                    MessageBox.Show(e.Message, "Error (What the heck did you do?!)");
                    Application.Exit();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
