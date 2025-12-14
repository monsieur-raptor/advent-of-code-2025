// See https://aka.ms/new-console-template for more information

static int getMaxJoltage(List<int> bank, int length, int maxJoltage, int iterations = 2, int startPosition = 0)
{
    while (iterations > 0)
    {
        int digit = 9;
        while (digit > 0)
        {
            bool maxFound = false;
            for (int i = startPosition; i < length - 1; i++)
            {
                Console.WriteLine($"{digit} : {bank[i]} - {iterations}");
                if (bank[i] == digit)
                {
                    maxJoltage += bank[i] * Convert.ToInt32(Math.Pow(10, iterations - 1));
                    startPosition = i;
                    bank.RemoveAt(i);
                    maxFound = true;
                    break;
                }
            }
            digit--;
            if (maxFound)
                break;
        }
        iterations--;
    }
    return maxJoltage;
}

// Main
int joltage = 0;
string[] banks= File.ReadAllLines("bank.txt");
foreach (String bank in banks)
{
    List<int> currentBank = new List<int>();
    int maxJoltage = 0;
    int length = 0;

    for (int i = 0; i < bank.Length; i++)
    {
        currentBank.Add(bank[i]-'0');
        length++;
    }
    joltage += getMaxJoltage(currentBank, length, maxJoltage);
}

Console.WriteLine(joltage);