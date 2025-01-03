class SystemVariables()
{
    public static int targetFrameRate;
    public static int windowWidth = 1600;
    public static int windowHeight = 900;
    public static bool fullscreen = false;

    public static int ChooseFPS()
    {
        Console.WriteLine("How much FPS do you want?");

        while (!int.TryParse(Console.ReadLine(), out targetFrameRate) || targetFrameRate < 1)
        {
            Console.WriteLine("invalid input, try again");
        }
        return targetFrameRate;
    }
    public static void SetFullscreen()
    {
        Console.WriteLine("Do you want fullscreen? [Y/N]");
        string answer;
        while (true)
        {
            answer = Console.ReadLine().ToLower();
            if (answer == "y" || answer == "n")
                break;
            Console.WriteLine("Invalid input, try again");
        }

        if (answer == "y")
        {
            fullscreen = true;
        }
    }

}

