global using Raylib_cs;
using System;

Console.WriteLine("Hur mycket fps vill du ha?(0 för uncapped)");
int targetFrameRate;

while (!int.TryParse(Console.ReadLine(), out targetFrameRate) || targetFrameRate < 0)
{
    Console.WriteLine("invalid input, try again");
}

Raylib.InitWindow(1600, 900, "raylib");
Raylib.MaximizeWindow();
Raylib.SetTargetFPS(targetFrameRate);

List<MoveableObject> gameList = new List<MoveableObject>();
Player player = new Player(800, 450);
gameList.Add(player);

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.RayWhite);
    for (int i = 0; i < gameList.Count; i++)
    {
        gameList[i].Update();
        gameList[i].Draw();
    }

    Raylib.DrawText(Raylib.GetFPS().ToString(), 0, 0, 50, Color.Black);
    Raylib.EndDrawing();
}