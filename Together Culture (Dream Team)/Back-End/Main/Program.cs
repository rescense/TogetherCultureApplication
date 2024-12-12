using Together_Culture__Dream_Team_.Front_End.Src.Screens;

namespace Together_Culture__Dream_Team_
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //for testing the below form opens first, please uncomment the line bellow, and delete or comment the one with SearchUsersAdmin to view the landingPage upon running the program
            Application.Run(new Log_in());
        }
    }
}