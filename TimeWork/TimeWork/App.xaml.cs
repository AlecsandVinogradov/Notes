using System;
using System.IO;
using TimeWork.Data;
using Xamarin.Forms;

namespace TimeWork
{
    public partial class App : Application
    {
        static NotesDb notesDb;

        public static NotesDb NotesDb
        {
            get
            {
                if (notesDb == null)
                {
                    notesDb = new NotesDb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NotesDatabase.db3"));
                }
                return notesDb;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
