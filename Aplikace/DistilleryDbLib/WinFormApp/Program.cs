using System;
using System.Windows.Forms;
using WinFormApp.Forms;
using DistilleryLogic;
using WinFormApp.Forms.DialogForms;

namespace WinFormApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Configuration.SetDbConnection(
                DataLayerNetCore.DBType.XmlDatabase,
                @"C:\Users\Vojtěch\Source\Repos\VIS_projekt\Aplikace\DistilleryDbLib\WebApp\DistXml.xml");

            //Configuration.SetDbConnection(
            //    DataLayerNetCore.DBType.SqlServer,
            //    @"data source = dbsys.cs.vsb.cz\STUDENT; initial catalog = mor0146; user id = mor0146; password = Wt0pEzMOWp");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm(loginForm.LoggedUser));
            }
        }
    }
}
