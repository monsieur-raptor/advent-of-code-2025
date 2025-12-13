// See https://aka.ms/new-console-template for more information
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
string idFile = File.ReadAllText("id.txt");
string[] idList = idFile.Split(',');
var invalidId = new ConcurrentBag<long>();
long invalidSum = 0;
Parallel.ForEach(idList, id =>
{
    string[] currentId = id.Split('-');
    long min = Convert.ToInt64(currentId[0]);
    long max = Convert.ToInt64(currentId[1]);

    for (long i = min; i <= max; i++)
    {
        string number = Convert.ToString(i);
        if (number.Length % 2 == 0)
        {
            string firstHalf = number[.. (number.Length/2)];
            string secondHalf = number[(number.Length/2) ..];

            if(firstHalf == secondHalf)
            {
                invalidId.Add(i);
            }   
        }
    }
});
invalidSum = invalidId.Sum();
Console.WriteLine(invalidSum);