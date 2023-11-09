using Trabajo_Practico_4.Entitys;

namespace Trabajo_Practico_4
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Controlers.Conection.OpenConnection();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            Controlers.Conection.CloseConnection();
        }
    }
}