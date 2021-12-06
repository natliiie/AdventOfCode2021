using System;
using System.IO;
using System.Linq;

namespace Kalender;

internal class Class1
{
    public void one()
    {
        var path = @"C:\Users\natal\source\repos\Kalender\Day1.txt";


        var input = File.ReadAllLines(path);
        var numberinput = input.Select(int.Parse).ToArray();

        var count = 0;

        for (var i = 0; i < numberinput.Length - 1; i++)
        {
            var first = numberinput[i];
            var second = numberinput[i + 1];


            if (second > first) count++;
        }

        Console.WriteLine(count);

        Console.ReadLine();
    }

    public void one_one()
    {
        var path = @"C:\Users\natal\source\repos\Kalender\Day1.txt";


        var input = File.ReadAllLines(path);
        var numberinput = input.Select(int.Parse).ToArray();

        var count = 0;

        var firstsum = 0;
        var secondsum = 0;

        for (var i = 0; i < numberinput.Length - 3; i++)
        {
            var first = numberinput[i];
            var second = numberinput[i + 1];
            var third = numberinput[i + 2];
            var fourth = numberinput[i + 3];

            firstsum = first + second + third;
            secondsum = second + third + fourth;


            if (secondsum > firstsum) count++;
        }

        Console.WriteLine(count);

        Console.ReadLine();
    }

    public void two_one()
    {
        var path = @"C:\Users\natal\source\repos\Kalender\Day2.txt";

        var input = File.ReadAllLines(path);

        var horizontal = 0;
        var dept = 0;

        foreach (var commandlist in input)
        {
            var command = commandlist.Split(" ");

            if (command[0] == "forward") horizontal += int.Parse(command[1]);

            if (command[0] == "down") dept += int.Parse(command[1]);

            if (command[0] == "up") dept -= int.Parse(command[1]);
        }

        Console.WriteLine(horizontal * dept);
    }

    public void two_two()
    {
        var path = @"C:\Users\natal\source\repos\Kalender\Day2.txt";

        var input = File.ReadAllLines(path);

        var horizontal = 0;
        var dept = 0;
        var aim = 0;

        foreach (var commandlist in input)
        {
            var command = commandlist.Split(" ");

            if (command[0] == "forward")
            {
                horizontal += int.Parse(command[1]);
                dept += int.Parse(command[1]) * aim;
            }

            if (command[0] == "down") aim += int.Parse(command[1]);

            if (command[0] == "up") aim -= int.Parse(command[1]);
        }

        Console.WriteLine(horizontal * dept);
    }

    public void three_one()
    {
        var path = @"C:\Users\natal\source\repos\Kalender\Day4.txt";

        var bitStringList = File.ReadAllLines(path);

        var epsilion = "";
        var gamma = "";


        for (var i = 0; i < bitStringList[0].Length; i++)
        {
            var zerocount = 0;
            var onecount = 0;

            //kolla varje index i strängen
            foreach (var bitstring in bitStringList)
            {
                var numberarray = bitstring.Select(n => n - '0').ToArray();
                if (numberarray[i] == 0) zerocount++;
                if (numberarray[i] == 1) onecount++;

            }

            //addera till g eller e.
            if (zerocount > onecount)
            {
                epsilion = epsilion.Insert(epsilion.Length, "0");
                gamma = gamma.Insert(gamma.Length, "1");
            }


            if (zerocount < onecount)
            {
                epsilion = epsilion.Insert(epsilion.Length, "1");
                gamma = gamma.Insert(gamma.Length, "0");
            }
        }

        //gör om till decimaltal e och g
        var epsilonDecimalvalue = Convert.ToInt32(epsilion, 2);
        var gammaDecimalvalue = Convert.ToInt32(gamma, 2);

        //gångra e med g
        var powerconsumption = epsilonDecimalvalue * gammaDecimalvalue;
        Console.WriteLine(powerconsumption);
    }
}