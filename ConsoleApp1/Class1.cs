using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalender
{
    internal class Class1
    {
        public void onefour_one()
        {
            //separera alla nummer till stränglista
            var numberPath = @"C:\Users\natal\source\repos\Kalender\Day4num.txt";
            var numInput = File.ReadAllLines(numberPath);
            var splitstring = numInput[0].Split(",");


            var boardPath = @"C:\Users\natal\source\repos\Kalender\Day4board.txt";
            var boardInput = File.ReadAllLines(boardPath);


            //hela listan ska innehålla alla bingospel
            var bigcol = new List<List<List<Object>>>();

            var singleboard = new List<List<Object>>();



            var counter = 0;

            for (var i = 0; i < boardInput.Length; i++)
                //varje bingospel har fem rader

                if (boardInput[i] != "")
                {
                    if (counter < 5)
                    {
                        var singleString = boardInput[i].Split(" ");

                        var singlenumberAndBoolList = new List<object>();

                        foreach (var num in singleString)
                        {
                            if (num != "")
                            {
                                var singleAndBool = new object[] { num, false };
                                singlenumberAndBoolList.Add(singleAndBool);
                            }


                        }
                        

                        singleboard.Add(singlenumberAndBoolList); 
                        counter++;
                    }

                    if (counter == 5)
                    {
                        //lägg till varje bingospel
                        bigcol.Add(singleboard);
                        counter = 0;
                        singleboard = new List<List<object>>();
                    }
                }

            /////////////////////


            //gör stränglistan till int samling


            Console.WriteLine("klar");
            Console.ReadLine();
        }
    }
}
