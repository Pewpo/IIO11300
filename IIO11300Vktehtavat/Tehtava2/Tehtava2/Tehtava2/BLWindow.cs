using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tehtava2
{
  public  class BLWindow
    {
        Random rand = new Random();
        //Make rows player selected
        public string[] Lotto(string Game, int rows)
        {

            string[] hojon = new string[1]; ;
            string[] AllRows = new string[rows];
            //FINNIS LOTTERY
            if (Game == "Suomi")
            {
                int help;
                int[] SuomiArray = new int[7];
                for (int a = 0; a < rows; a++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        help = rand.Next(1, 39);
                        if (SuomiArray.Contains(help))
                        {
                            i--;
                        }
                        else
                        {
                            SuomiArray[i] = help;
                        }
                    }
                    AllRows[a] = "First row : "+ string.Join(", ", SuomiArray.Select(v => v.ToString())) + "\n Next Row:";
                   
                }
                return AllRows;

            }
            //VIKING LOTTO
            else if (Game == "Viking Lotto")
            {
                int help;
                int[] VikingArray = new int[6];
                for (int a = 0; a < rows; a++)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        help = rand.Next(1, 48);
                        if (VikingArray.Contains(help))
                        {
                            i--;
                        }
                        else
                        {
                            VikingArray[i] = help;
                        }
                    }
                    AllRows[a] = "First row : " + string.Join(", ", VikingArray.Select(v => v.ToString())) + "\n Next Row:";

                }
                return AllRows;

            }
            //EUROJACKPOT
            else if (Game == "Eurojackpot")
            {
                int help2;
                int help;
                int[] EuroArray = new int[5];
                int[] PlusArray = new int[2];
                for (int a = 0; a < rows; a++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        help = rand.Next(1, 50);
                        if (EuroArray.Contains(help))
                        {
                            i--;
                        }
                        else
                        {
                            EuroArray[i] = help;
                        }

                    }
                    //plus numbers
                    for (int i = 0; i < 2; i++)
                    {
                        help2 = rand.Next(1, 8);
                        if (PlusArray.Contains(help2))
                        {
                            i--;
                        }
                        else
                        {
                            PlusArray[i] = help2;
                        }
                    }


                    AllRows[a] = "First row : " + string.Join(", ", EuroArray.Select(v => v.ToString())) + " Plus numbers : " + string.Join(", ", PlusArray.Select(v => v.ToString())) + "\n Next row: ";
                }

                return AllRows;
            }
            else
            {
                return hojon;

            }

        }
        //drawing function
        public string drawGame(string game, int num) {
            string[] lotto;
            string Game = game;
            if( game == "Suomi")
            {
              lotto =  Lotto(Game,num);
            
               
              
                return "Suomi Numbers :" + string.Join(", ", lotto.Select(v => v.ToString()));
            }
           else if (game == "Viking Lotto") {
                lotto = Lotto(Game, num);
                return "Viking Lotto Numbers : " + string.Join(", ", lotto.Select(v => v.ToString())); ;
            }
           else if (game == "Eurojackpot")
            {
                lotto = Lotto(Game, num);
                return "Eurojackpot Numbers : " + string.Join(", ", lotto.Select(v => v.ToString())); ;
            }
            else 
            {
              
                return  "Select game and rows first";
            }
        }

    }
}
