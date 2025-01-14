
global using Raylib_cs;
global using System;


Raylib.SetTargetFPS(Setup.ChooseFPS());
Setup.SetFullscreen();
Raylib.InitWindow(Setup.windowWidth, Setup.windowHeight, "Game");
if (Setup.fullscreen) Raylib.ToggleFullscreen();


Player player = new Player(800, 450, 69);
Enemy bert = new Enemy(1400,0,158);


while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    if (!Raylib.IsKeyDown(KeyboardKey.W)) Raylib.ClearBackground(Color.RayWhite);
    for (int i = 0; i < MoveableObject.gameList.Count; i++)
    {
        MoveableObject.gameList[i].Update();
        MoveableObject.gameList[i].Draw();
    }


    Raylib.DrawText(Raylib.GetFPS().ToString(), 0, 0, 50, Color.Black);
    Raylib.DrawText($"width: {Raylib.GetScreenWidth()}", 0, 100, 50, Color.Black);
    Raylib.DrawText($"height: {Raylib.GetScreenHeight()}", 0, 150, 50, Color.Black);
    // Raylib.DrawText($"color: {player.trailColor.G}", 0, 200, 50, Color.Black);
    // Raylib.DrawText($"color: {player.trailColor.B}", 0, 250, 50, Color.Black);
    // Raylib.DrawText($"color: {player.trailColor.A}", 0, 300, 50, Color.Black);
    Raylib.EndDrawing();
}






