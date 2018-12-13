using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projet_Graphique_Salle.Model
{
    class logWrite
    {
        Mutex mutex = new Mutex();

        public logWrite()
        {

        }

        public void Write(string input)
        {
            mutex.WaitOne();
            string date = DateTime.Now.ToString("dd/mm/yy HH:mm");
            string _Path = Environment.CurrentDirectory.Replace(@"\bin\debug", "");
            string path = _Path + @"\log.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine($"{(date)} {input}");
            }
            mutex.ReleaseMutex();
        }
    }
}
