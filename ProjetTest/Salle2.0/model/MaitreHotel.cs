using System;
using System.Collections.Generic;

namespace Salle2.0.model
{
    public class maitreHotel
    {
        private string _observerState;
        private Client _subject;
        private string _name;

        private static maitreHotel instance = null;
        private static readonly object mylock = new object();

        public maitreHotel(Client subject)
        {
            this._subject = subject;
        }

        public maitreHotel()
        {

        }

        public (int , int) tableLibre(int taille)
        {
            int libreX = 0;
            int libreY = 0;
            Table table = new Table();
            if (table.getLibre(taille))
            {
                List<Table> vide = new List<Table>();
                vide.Add(new Table(1, 2, 4));
                vide.Add(new Table(1, 3, 8));

                // ajouter à chaque entré dans la table vide
                foreach (Table element in vide)
                {
                    if (taille <= 4 && element.place <= 4)
                    {
                        libreX = element.tableX;
                        libreY = element.tableY;
                    }
                    else if (taille <= 8 && taille > 4 && element.place > 4 && element.place <= 8)
                    {
                        libreX = element.tableX;
                        libreY = element.tableY;
                    }
                }
            }
            return (libreX, libreY);
        }

        public static maitreHotel GetInstance()
        {
            lock ((mylock))
            {
                if (instance == null)
                {
                    instance = new maitreHotel();
                }
                return instance;
            }
        }
        
        public void Update()
        {
            _observerState = _subject.SubjectState;
            Console.WriteLine("Le maitre d'hotel à capté des clients. Ils sont {0}", _subject.group);
        }
    }
}