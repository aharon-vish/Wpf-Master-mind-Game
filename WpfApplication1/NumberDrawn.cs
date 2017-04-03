using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MastermindGameAharonVishinsky
{
    class NumberDrawn
    {
       
        Random Rnd = new Random();
        static int[] number = new int[4];
        static int count = 0;
        public  int GivenRandomNumber()
        {
           
            int NumberRnd = Rnd.Next(0, 10);
           //save the number that have droawon
            for (int i = 0; i < number.Length; i++)
            {  
                if (number[i] ==NumberRnd)
                {
                    NumberRnd = Rnd.Next(0, 10);
                    i = 0;
                }                
            }
            number[count] = NumberRnd;
            count++;
            return NumberRnd;
        }
    }
}
