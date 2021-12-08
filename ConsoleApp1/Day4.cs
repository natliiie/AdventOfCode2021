namespace Kalender;

public class Number
{
    public int num { get; set; }
    public bool isdrawed { get; set; }
}

public class Row
{
    public Row()
    {
        numbers = new List<Number>();
    }

    public List<Number> numbers { get; set; }
}

public class Board
{
    public Board()
    {
        rows = new List<Row>();
    }

    public List<Row> rows { get; set; }
}

public class Day4
{
    public void twofour_one()
    {
        //separera alla nummer till stränglista
        var numberPath = @"C:\Users\natal\source\repos\Kalender\Day4num.txt";
        var numInput = File.ReadAllLines(numberPath);
        var splitstring = numInput[0].Split(",");

        var boardPath = @"C:\Users\natal\source\repos\Kalender\Day4board.txt";
        var boardInput = File.ReadAllLines(boardPath);

        var myrow = new Row();
        var myboard = new Board();
        var myboardList = new List<Board>(); //egen lista
        
        //skapa nummerobjektet
        for (var i = 0; i < boardInput.Length; i++)
            if (boardInput[i] != "")
            {
                var rowsStrings = boardInput[i].Split(" ");

                foreach (var num in rowsStrings)
                    if (num != "")
                    {
                        if (myrow.numbers.Count < 5)
                        {
                            var newnumber = new Number {num = int.Parse(num), isdrawed = false};
                            myrow.numbers.Add(newnumber); //lägger till ett nummer i nummersamlingen
                        }

                        if (myrow.numbers.Count == 5)
                        {
                            myboard.rows.Add(myrow);
                            myrow = new Row();
                        }

                        if (myboard.rows.Count == 5)
                        {
                            myboardList.Add(myboard);
                            myboard = new Board();
                        }
                    }
            }


        /////////////////////
        ///
        /// dragningen.


        Console.WriteLine("klar");
        Console.ReadLine();
    }
}