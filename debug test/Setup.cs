using System;

class Setup
{
    public static int targetFrameRate;
    public static int windowWidth = 1600;
    public static int windowHeight = 900;
    public static bool fullscreen = false;
    public static float universalScaleFactor = 1;

    public static int ChooseFPS()
    {
        Console.WriteLine("How much FPS do you want?");

        while (!int.TryParse(Console.ReadLine(), out targetFrameRate) || targetFrameRate < 1)
        {
            Console.WriteLine("Invalid input, try again");
        }
        return targetFrameRate;
    }

    public static void SetFullscreen()
    {
        Console.WriteLine("Do you want fullscreen? [Y/N] (fullscreen might not work if you have multiple monitors connected)");
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
            windowWidth = Raylib.GetMonitorWidth(0);
            windowHeight = Raylib.GetMonitorHeight(0);
        }
    }

    public static void SetUniversalScaleFactor()
    {
        int baseWidth = 1600;  // Your base resolution width
        int baseHeight = 900; // Your base resolution height

        // Determine actual resolution
        int actualWidth = fullscreen ? Raylib.GetMonitorWidth(0) : windowWidth;
        int actualHeight = fullscreen ? Raylib.GetMonitorHeight(0) : windowHeight;

        // Calculate scale factor
        universalScaleFactor = Math.Min((float)actualWidth / baseWidth, (float)actualHeight / baseHeight);
        Console.WriteLine($"Universal Scale Factor set to: {universalScaleFactor}");
    }
}
