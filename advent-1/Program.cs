using System.IO.Pipelines;

static (int DialPosition, int PointZero) RotateDial(int dial, int currentPosition)
{
    int zero = 0;

    if (dial > 99)
    {
        dial -= 100;
        zero++;
    }
    else if (dial == 0)
    {
        dial = 0;
        zero++;
    }
    else if (dial < 0)
    {
        dial = 100 - Math.Abs(dial);
        if (currentPosition != 0)
            zero++;
    }
    
    return (dial, zero);
}

// Main

const int START_POSITION = 50;

int dial = START_POSITION;
int nbZero, stopZero, currentPosition;
nbZero = stopZero = 0;

string[] rotations = File.ReadAllLines("sequences.txt");
foreach (String rotation in rotations)
{
    String direction = rotation[..1];
    int clicks = Convert.ToInt32(rotation[1..]);
    if (clicks > 99)
    {
        nbZero += clicks/100;
        clicks %= 100;
    }
    currentPosition = dial;
    dial = (direction == "R") ? dial += clicks : dial -= clicks;
    var sequence = RotateDial(dial, currentPosition);
    dial = sequence.DialPosition;
    nbZero += sequence.PointZero;
    if (dial == 0)
        stopZero++;
}

Console.WriteLine($"Dial pointed at zero {nbZero} times and was left pointing at zero {stopZero} times");