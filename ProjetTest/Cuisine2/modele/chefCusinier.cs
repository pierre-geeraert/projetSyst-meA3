using System.Threading;

namespace Cuisine2
{
    public class chefCusinier
    {
        public chefCusinier()
        {

        }

        public int tempsPlat(string actuel)
        {
            int time = 50;
            return time;
        }

        public void cuisiner(string plat)
        {
            Thread.Sleep(tempsPlat(plat));
        }
    }
}