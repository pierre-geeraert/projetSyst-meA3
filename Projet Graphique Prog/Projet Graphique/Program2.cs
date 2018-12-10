using System;

namespace Projet_Graphique
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program2
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game2 = new VueCuisine())
                game2.Run();
        }
    }
}
