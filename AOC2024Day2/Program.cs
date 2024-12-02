

using System.Numerics;

using (var reader = new StreamReader("../../../../data/AOC2024Day2/input.txt"))
{
    var validReportCount = 0;
    while(!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        var elements = line.Split(" ").Select(x => int.Parse(x.Trim())).ToList();

        // trend will match on the first element every time but that's fine.
        var differential = elements[1] - elements[0];
        bool validReport = true;

        var trend = 0;
        if (differential == 0)
        {
            validReport = false;
        }
        else
        {
            trend = (differential) / Math.Abs(differential);
        }
       
        for(int i = 1; i < elements.Count; i++)
        {
            differential = elements[i] - elements[i - 1];
            if (differential == 0 || Math.Abs(differential) > 3)
            {
                validReport = false;
                break;
            }
            var newTrend = (differential) / Math.Abs(differential);
            if (newTrend != trend)
            {
                validReport = false;
                break;
            }
        }
        if (validReport)
        {
            validReportCount++;
        }

    }

    Console.WriteLine(validReportCount);

}