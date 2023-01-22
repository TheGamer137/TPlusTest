Console.WriteLine("Нажмите 1, чтобы указать путь к файлу или нажмите 2, чтобы ввести в ручную массив");
if (Convert.ToInt32(Console.ReadLine()) == 1)
{
    Console.WriteLine("Укажите путь к файлу");
    FindClosestNumberToDig(GetArrayFromFile());
}
else
{
    Console.WriteLine("Введите числа через пробел");
    FindClosestNumberToDig(WriteArrayManually());
}


int[]? GetArrayFromFile()
{
    string pathToFile = Console.ReadLine();
    if (!string.IsNullOrEmpty(pathToFile))
    {
        if (Directory.Exists(pathToFile))
        {
            try
            {
                int[]? arr = File.ReadAllText(pathToFile).
                    Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).
                    Select(x => int.Parse(x)).ToArray();
                return arr;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        Console.WriteLine("Путь указан не верно");
        GetArrayFromFile();
    }
    else
    {
        Console.WriteLine("Путь к файлу не может быть пуст");
        GetArrayFromFile();
    }
    return null;
}

int[]? WriteArrayManually()
{
    try
    {
        int[]? arr = Console.ReadLine()?.Split().Select(int.Parse).ToArray();
        return arr;
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception.Message);
    }
    return null;
}

void FindClosestNumberToDig(int[]? arr)
{
    Console.Write("Введите dig ");
    int dig = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("dig=" + dig);
    for (int plus = 0; plus < int.MaxValue; plus++)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                for (int k = j + 1; k < arr.Length; k++)
                {
                    var sum = arr[i] + arr[j] + arr[k];
                    if (sum == dig)
                    {
                        Console.WriteLine(sum + "  Самое близкое к dig");
                        Console.WriteLine(arr[i] + "+" + arr[j] + "+" + arr[k]);
                        return;
                    }

                    if (sum + plus == dig)
                    {
                        Console.WriteLine(sum + "  Самое близкое к dig");
                        Console.WriteLine(arr[i] + "+" + arr[j] + "+" + arr[k]);
                        return;
                    }

                    if (sum - plus == dig)
                    {
                        Console.WriteLine(sum + "  Самое близкое к dig");
                        Console.WriteLine(arr[i] + "+" + arr[j] + "+" + arr[k]);
                        return;
                    }
                }
            }
        }
    }
}