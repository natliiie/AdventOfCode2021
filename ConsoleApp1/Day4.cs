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
    public List<Board> myboardList = new(); //egen lista

    public void createboardlist()
    {
        var boardPath = @"C:\Users\natal\source\repos\Kalender\Day4board.txt";
        var boardInput = File.ReadAllLines(boardPath);

        var myrow = new Row();
        var myboard = new Board();


        //skapa nummerobjektet
        for (var i = 0; i < boardInput.Length; i++)
            if (boardInput[i] != "")
            {
                var rowsStrings = boardInput[i].Split(" ");

                //kolla på alla nummer i inputen
                foreach (var num in rowsStrings)
                    if (num != "")
                    {
                        if (myrow.numbers.Count < 5) // fem nummer på varje rad
                        {
                            var newnumber = new Number
                                {num = int.Parse(num), isdrawed = false}; //lägg till en bool för varje siffra
                            myrow.numbers.Add(newnumber); //lägger till ett nummer i nummersamlingen
                        }

                        if (myrow.numbers.Count == 5) // raden är komplett
                        {
                            myboard.rows.Add(myrow); // lägger till den skapade raden i en radlista
                            myrow = new Row(); // töm objektet för att skapa en ny senare
                        }

                        if (myboard.rows.Count == 5) // alla vågräta rader är skapade
                        {
                            //skapa lodräta rader
                            for (var j = 0; j < 5; j++) // ska bli fem lodräta rader totalt 
                            {
                                for (var k = 0; k < 5; k++) myrow.numbers.Add(myboard.rows[k].numbers[j]);
                                myboard.rows.Add(myrow);
                                myrow = new Row();
                            }

                            myboardList.Add(myboard); // 10 rader skapade. komptett board läggs till i lista
                            myboard = new Board(); // töm för att skapa ett nytt board senare
                        }
                    }
            }

        Console.WriteLine("lista klar");
    }

    public void draw()
    {
        createboardlist();

        var numberPath = @"C:\Users\natal\source\repos\Kalender\Day4num.txt";
        var numInput = File.ReadAllLines(numberPath);
        var splitstring = numInput[0].Split(",");

        var winningrow = new Row();
        var winningboard = new Board();
        var unmarkedsum = 0;
        var numberwhenbingo = 0;

        //dra ett nummer i taget
        for (var i = 0; i < splitstring.Length; i++)
        {
            var num = int.Parse(splitstring[i]); //siffran som dragits i int

            for (var j = 0; j < myboardList.Count; j++) //gå igenom alla boards i listan
                foreach (var row in myboardList[j].rows) //kolla på alla rader i boardet
                {
                    var matchedBingoNumbers =
                        row.numbers.FindAll(e => e.num == num); //alla nummer i boardraden som matchar bingonumret
                    if (matchedBingoNumbers.Count != 0)
                        foreach (var n in matchedBingoNumbers)
                            n.isdrawed = true;
                }

            //kolla bingo
            for (var k = 0; k < myboardList.Count; k++)
                foreach (var row in myboardList[k].rows) //kolla alla enskilda rader
                {
                    var truecount = 0; //räknare för alla som är true på raden

                    foreach (var number in row.numbers)
                        if (number.isdrawed)
                            truecount++;

                    if (truecount == 5) // BINGO
                    {
                        //sätter vinnarvärden
                        winningrow = row;
                        winningboard = myboardList[k];
                        numberwhenbingo = num;

                        //egenkontroll för konsollen
                        Console.WriteLine("bingo! rownumbers: ");
                        foreach (var number in winningrow.numbers)
                            Console.WriteLine($"{number.num} {number.isdrawed} \n");

                        //räkna alla omarkerade

                        var numlist = new List<int>();

                        foreach (var r in winningboard.rows)
                        foreach (var n in r.numbers)
                            if (!n.isdrawed)
                                numlist.Add(n.num);

                        //ta bort dubletter av siffror
                        var newnumlist = numlist.Distinct().ToList();
                        unmarkedsum = newnumlist.Sum();

                        //output för kontroll och resultat
                        Console.WriteLine("Summa av alla omarkerade är: " + unmarkedsum);

                        Console.WriteLine("siffran när bingo är: " + numberwhenbingo);

                        Console.WriteLine(
                            $"summan av alla omarkerade({unmarkedsum}) gånger ({numberwhenbingo}) är: {unmarkedsum * numberwhenbingo} ");

                        Console.ReadLine();
                    }
                }
        }
    }
}