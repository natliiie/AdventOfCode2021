namespace Kalender;

internal class Day4
{
    public void four_one()
    {
        //separera alla nummer till stränglista
        var numberPath = @"C:\Users\natal\source\repos\Kalender\Day4num.txt";
        var numInput = File.ReadAllLines(numberPath);
        var splitstring = numInput[0].Split(",");


        var boardPath = @"C:\Users\natal\source\repos\Kalender\Day4board.txt";
        var boardInput = File.ReadAllLines(boardPath);


        //hela listan ska innehålla alla bingospel
        var bigcol = new List<List<List<object>>>();

        var singleboard = new List<List<object>>();


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
                        if (num != "")
                        {
                            var singleAndBool = new object[] {num, false};
                            singlenumberAndBoolList.Add(singleAndBool);
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

        //följande tanke, kan va helt galet.
        //loopa varje nummer och hitta numret i samlingen sätt bool till true. 
        // kolla om alla är true/false... bingo?


        Console.WriteLine("klar");
        Console.ReadLine();
    }
}