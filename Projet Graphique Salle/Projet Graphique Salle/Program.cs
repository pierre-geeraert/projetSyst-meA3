using System;

namespace Projet_Graphique_Salle
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new SalleVue())
                game.Run();
        }
    }
}
