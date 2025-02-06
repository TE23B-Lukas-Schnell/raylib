
global using Raylib_cs;
global using System;

Raylib.SetTargetFPS(Setup.ChooseFPS());

Raylib.InitWindow(Setup.windowWidth, Setup.windowHeight, "Game");

Player player = new Player(800, 450, Setup.windowWidth * 0.05f, Setup.windowWidth * 0.05f);
new Enemy(1400, 0,  Setup.windowWidth * 0.11f);

//main loop
while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.White);
    for (int i = 0; i < MoveableObject.gameList.Count; i++)
    {
        MoveableObject.gameList[i].Update();
        MoveableObject.gameList[i].Draw();
    }

    MoveableObject.gameList.RemoveAll(obj => obj.remove == true);

    for (int i = 0; i < MoveableObject.gameList.Count; i++)
    {
        Console.WriteLine(MoveableObject.gameList[i]);
    }

    Raylib.DrawText(Raylib.GetFPS().ToString(), 0, 0, 25, Color.Black);
    Raylib.EndDrawing();
}

