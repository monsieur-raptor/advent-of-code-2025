// See https://aka.ms/new-console-template for more information
static char[,] CreateMatrix(string file)
{
    string[] racks = File.ReadAllLines(file);
    int gridRows = racks.Length;
    int gridCols = racks[0].Length;
    int row = 0;
    char[,] grid = new char[gridRows, gridCols];

    foreach (String rack in racks)
    {
        int col = 0;
        foreach (char character in rack)
        {
            grid[row, col] = character;
            col++;
        }
        row++;
    }

    return grid;
}

static int PaperRollsDetection(char[,] sequence, char[,] sequenceCopy, int x, int y, int width, int height) {
    int count = 0;
    int accessibleRolls = 0;
    for (int checkX = -1; checkX <= 1; checkX++)
    {
        for (int checkY = -1; checkY <= 1; checkY++)
        {
            if(IsInGrid(x + checkX, y + checkY, width, height))
            {
                if (checkX == 0 && checkY == 0)
                continue;

                else if (sequence[x+checkX, y + checkY].Equals('@'))
                count += 1;     
            }
        }
    }
    if (count < 4 && sequence[x,y].Equals('@'))
    {
        accessibleRolls++;
        sequenceCopy[x,y] = 'x';
    }
    return accessibleRolls;           
}

static bool IsInGrid(int x, int y, int width, int height)
{
    return x >= 0
        && x < width
        && y >= 0
        && y < height;
}

char[,] grid = CreateMatrix("racks.txt");
int width = grid.GetLength(0);
int height = grid.GetLength(1);

char[,] gridCopy = new char[width, height];
Array.Copy(grid, gridCopy, grid.Length);

int totalAccessibleRolls = 0;

for (int x = 0; x < width; x++)
{
    for (int y = 0; y < height; y++)
    {
        totalAccessibleRolls += PaperRollsDetection(grid, gridCopy, x, y, width, height);
    }
}

Console.WriteLine(totalAccessibleRolls);