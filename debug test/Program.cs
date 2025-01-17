
global using Raylib_cs;
global using System;


Raylib.SetTargetFPS(Setup.ChooseFPS());
Setup.SetFullscreen();
Raylib.InitWindow(Setup.windowWidth, Setup.windowHeight, "Game");
if (Setup.fullscreen) Raylib.ToggleFullscreen();

Setup.SetUniversalScaleFactor();

Player player = new Player(800, 450, Setup.windowWidth * 0.03f, Setup.windowWidth * 0.03f);
new Enemy(1400, 0, 158);


while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    if (!Raylib.IsKeyDown(KeyboardKey.W)) Raylib.ClearBackground(Color.RayWhite);
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

    Raylib.DrawText(Raylib.GetFPS().ToString(), 0, 0, 50, Color.Black);
    Raylib.DrawText($"width: {Raylib.GetScreenWidth()}", 0, 100, 50, Color.Black);
    Raylib.DrawText($"height: {Raylib.GetScreenHeight()}", 0, 150, 50, Color.Black);
    Raylib.DrawText($"ShootCooldown: {player.shootCooldown}", 0, 200, 50, Color.Black);
    Raylib.DrawText($"width: {player.width}", 0, 250, 50, Color.Black);
    Raylib.DrawText($"height: {player.height}", 0, 300, 50, Color.Black);
    Raylib.EndDrawing();
}






