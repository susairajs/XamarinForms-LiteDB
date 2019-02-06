using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinLiteDB
{
    public partial class App : Application
    {
        static LiteDBHelper db;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        

        public static LiteDBHelper LiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new LiteDBHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamarinLiteDB.db"));
                }
                return db;
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
