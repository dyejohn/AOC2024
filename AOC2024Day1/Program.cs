// See https://aka.ms/new-console-template for more information

// read input file

// order the lists

// step and measure

List<int> firstList = new List<int> ();
List<int> secondList = new List<int> ();

using (var reader = new StreamReader("../../../../data/AOC2024Day1/input.txt"))
{
    var content = reader.ReadToEnd().Split("\r\n").Select(a => a.Split(' ').Where(a => !string.IsNullOrWhiteSpace(a))).ToArray();
    foreach (var item in content)
    {
        firstList.Add(int.Parse(item.First()));
        secondList.Add(int.Parse(item.Last()));
        if(item.Count() > 2)
        {
            throw new Exception("invalid data");
        }
    }
    firstList.Sort();
    secondList.Sort();

    // part 1 answer

    // recombine the lists.
    if(firstList.Count() != secondList.Count())
    {
        throw new Exception("lists don't match");
    }

    int differential = 0;
    for(int i=0; i<firstList.Count(); i++)
    {
        var delta = secondList[i] - firstList[i];

        differential += Math.Abs(delta);
    }

    Console.WriteLine(differential);

    // part 2 answer.

    // for each number in the second list, calculate the frequency
    // then multiply the frequency of the number in the second list by the number in the first list...

    Dictionary<int, int> frequencies = new Dictionary<int, int>();
    foreach(int item in secondList)
    {
        // only add the ones that exist in firstlist
        if (firstList.Contains(item))
        {
            if (!frequencies.Keys.Contains(item))
            {
                frequencies.Add(item, secondList.Where(x => x == item).Count());
            }
        }
    }

    int simscore = 0;
    foreach(var (key,item) in frequencies)
    {
        simscore += key * item;
    }

    Console.WriteLine(simscore);
}

    


