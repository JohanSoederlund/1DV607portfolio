using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahtzee.Controller;

namespace Yahtzee
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game game = new Game();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }
    }
}
