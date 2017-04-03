using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MastermindGameAharonVishinsky
{
    class CheckGusses
    {
    public int iDrow = 0;
    public int iUser = 0;
   

    int[] rightPlace = new int[4];
     int[] NumberFromUser=new int [4];
     int [] NumberFromDrow=new int [4];

     public int Drow
	{
        get { return Drow; }
        set { NumberFromDrow[iDrow++] = value; }
	}

   
     public int User
     {
         get { return User; }
         set { NumberFromUser[iUser++] = value; }
     }

     public  int [] CheckDrowVsUser()
     {
         for (int i = 0; i < NumberFromDrow.Length; i++)
         {
             if (NumberFromDrow[i] == NumberFromUser[i] || rightPlace[i] == 1)
                 rightPlace[i] = 1;
             else
             rightPlace[i] = 0;
         }
         if (iUser == 4)
             iUser = 0;
         return rightPlace;
     }
    }
}
