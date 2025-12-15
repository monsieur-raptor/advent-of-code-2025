// See https://aka.ms/new-console-template for more information

static int getMaxJoltage(List<int> bank, int length, int iterations = 2, int startPosition = 0, int maxJoltage = 0)
{
    for (int counter = iterations; counter > 0; counter--)
    {
        int digit = 9;
        while (digit > 0)
        {
            bool isMaxRating = false;
            for (int i = startPosition; i < length - 1; i++)
            {
                if (bank[i] == digit)
                {
                    maxJoltage += bank[i] * Convert.ToInt32(Math.Pow(10, counter - 1));
                    startPosition = i;
                    bank.RemoveAt(i);
                    isMaxRating = true;
                    break;
                }
            }
            digit--;
            if (isMaxRating)
                break;
        }
    }
    return maxJoltage;
}

// Main
int joltage = 0;
string[] banks= File.ReadAllLines("banks.txt");
foreach (String bank in banks)
{
    List<int> currentBank = new List<int>();
    int length = 0;

    for (int i = 0; i < bank.Length; i++)
    {
        currentBank.Add(bank[i]-'0');
        length++;
    }
    joltage += getMaxJoltage(currentBank, length);
}

Console.WriteLine(joltage);