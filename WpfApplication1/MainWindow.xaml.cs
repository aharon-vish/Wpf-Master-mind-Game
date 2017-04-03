// כתבתי הסבר קצר ליד כל פונקיציה ,אני יודע שזה ממש מבולגן ועשיתי כאן מעכבר פיל בתוכנית
//מחילה על הכאב ראש (:



using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace MastermindGameAharonVishinsky
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CheckGusses _CheckGusses = new CheckGusses(); //creat class that will handell the first string of gusse
        List<Label> ArrOfLabel = new List<Label>(); // all label that creat in array 
        NumberDrawn GetNumber = new NumberDrawn();//handell whit random number 
        int CountGameEnd = 0;
        int DrawnN = 0;
        int GenralCuonter = 0;
        int counter;
        int RightGuessCuonter = 0;
        bool Flag = false;
        int[] RememberNOGuessing = new int[4];
        int NumberOfTry = 0;
        public MainWindow()
        {

            InitializeComponent();
            ArrOfLabel = canvas.Children.OfType<Label>().ToList();

        }

        private void start_Click(object sender, RoutedEventArgs e) //generate random and non Repeat numbers , put them in label
        {

            foreach (Label label in ArrOfLabel) 
            {
                if (GenralCuonter == 4)
                    break;
                label.Visibility = Visibility.Hidden;
                DrawnN = GetNumber.GivenRandomNumber();
                _CheckGusses.Drow = DrawnN;
                GenralCuonter++;
                label.Content = DrawnN.ToString();
            }
            m.Visibility = Visibility.Visible;
            start.IsEnabled = false;

        }

        private void Window_KeyUp(object sender, KeyEventArgs e) //handell which key the user press
        
          {

            int ascii = KeyInterop.VirtualKeyFromKey(e.Key);
            
            
            if (e.Key == Key.Enter)   // if enter that mean the user press all 4 digit , check gusses
            {
                NumberOfTry++;
                counter = 0;
                int[] rightPlaceGuess = _CheckGusses.CheckDrowVsUser();
                for (int i = 0; i < rightPlaceGuess.Length; i++)
                {
                    if (rightPlaceGuess[i] == 1)
                    {
                        ArrOfLabel[i].Visibility = Visibility.Visible;
                        RightGuessCuonter++;
                    }
                    else
                    {
                        ArrOfLabel[i + 4].Content = "";
                        RememberNOGuessing[counter] = i + 4;
                        Flag = true;                   // trun on the flag and from now we check "on line" user press on key check 
                                                       // if right gusse
                        counter++;
                    }
                }
                counter = 0;
                GenralCuonter = 4;


                while (ArrOfLabel[CountGameEnd + 4].Content.ToString().Length != 0) //how many time the user try to gusse
                {
                    CountGameEnd++;
                }
            }
           
            if (GenralCuonter >= 8 && !(e.Key == Key.Enter))
            {
                MessageBox.Show("NO MORE THANK YOU");              
            }

            else if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                ascii = ascii - 48;
                if (!(Flag))
                {
                    if (ArrOfLabel[GenralCuonter].Content.ToString().Length == 0)
                    {
                        ArrOfLabel[GenralCuonter].Content = ascii.ToString();
                        _CheckGusses.User = ascii;
                    }

                    else
                        _CheckGusses.User = ascii;
                    GenralCuonter++;
                }
                else if (Flag)  //check "on line"
                {
                    NumberOfTry++;
                    int aaa = RememberNOGuessing[counter];
                    string ssss = ArrOfLabel[aaa - 4].Content.ToString();
                
                    if (ssss.Equals(ascii.ToString()))
                    {
                        ArrOfLabel[aaa - 4].Visibility = Visibility.Visible;
                        ArrOfLabel[aaa].Content = ssss;
                        counter++;
                        while (ArrOfLabel[CountGameEnd + 4].Content.ToString().Length != 0) //how many time the user try to gusse
                        {
                            CountGameEnd++;
                        }
                    }
                    else
                        ArrOfLabel[RememberNOGuessing[counter]].Content = "";

                }
            }



            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                ascii = ascii - 96;
                if (!(Flag))
                {
                    if (ArrOfLabel[GenralCuonter].Content.ToString().Length == 0)
                    {
                        ArrOfLabel[GenralCuonter].Content = ascii.ToString();
                        _CheckGusses.User = ascii;
                    }

                    else
                        _CheckGusses.User = ascii;
                    GenralCuonter++;
                }

                else if (Flag)   //check "on line"
                {
                    NumberOfTry++;
                    int aaa = RememberNOGuessing[counter];
                    string ssss = ArrOfLabel[aaa - 4].Content.ToString();

                    if (ssss.Equals(ascii.ToString()))
                    {
                        ArrOfLabel[aaa - 4].Visibility = Visibility.Visible;
                        ArrOfLabel[aaa].Content = ssss;
                        counter++;
                        while (ArrOfLabel[CountGameEnd + 4].Content.ToString().Length != 0)  //how many time the user try to gusse
                        {
                            CountGameEnd++;
                        }
                    }
                    else
                        ArrOfLabel[RememberNOGuessing[counter]].Content = "";

                }

            }
            else if (!(e.Key == Key.Enter))
                MessageBox.Show("WRONG KEY !!!!");

            if (CountGameEnd > 4)   //if more than 4 that means user gusse all number  
            {
                MessageBox.Show("You Guess" + NumberOfTry);
                Close();
            }
            CountGameEnd = 0;
           
        }





    }
}
