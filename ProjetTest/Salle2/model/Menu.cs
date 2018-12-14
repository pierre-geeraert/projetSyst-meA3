using System.Collections.Generic;

namespace Salle2.model
{
    public class Menu
    {
        baseDataSet bdd = new baseDataSet();
        string connectionString = baseDataSet.GetConnectionString();

        public Client Client
        {
            get => default(Client);
            set
            {
            }
        }

        public List<(int Prix, string Name)> starter()
        {
            var starter = new List<(int Prix, string Name)>
            {
                (5, "oeuf cocote"),
                (10, "salade de chevre chaud"),
                (4, "salade de betrave"),
                (3, "oeuf mimosa au thon"),
                (9, "tartine au chevre et noix")
            };

            return starter;
        }

        public List<(int Prix, string Name)> dish()
        {
            var dish = new List<(int Prix, string Name)>
            {
                (15, "blanc de poulet à la crème et au miel"),
                (15, "croque-monsieur"),
                (24, "steack tartare"),
                (18, "burger"),
                (10, "salade ceasar au poulet")
            };

            return dish;
        }

        public List<(int Prix, string Name)> dessert()
        {
            var dessert = new List<(int Prix, string Name)>
            {
                (5, "crepe"),
                (5, "gauffre"),
                (4, "mousse au chocolat"),
                (4, "gateau au chocolat"),
                (6, "verrine à la poire")
            };

            return dessert;
        }
    }
}