using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppATester.Models
{
   public class Calcul
    {
        public int Addition (int a, int b)
        {
            for (int i = 1; i <= a; i++)
            {
                b = b + 1; //
            }

            return b; //(somme de a et b == b + 1 a fois)
        }
    }
}
