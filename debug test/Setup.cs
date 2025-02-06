class Setup
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
            Console.WriteLine("Invalid input, try again");
        }
        return targetFrameRate;
    }
}
