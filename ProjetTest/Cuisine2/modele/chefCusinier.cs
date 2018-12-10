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
            Thread.Sleep(time);
            return time;
        }
    }
}