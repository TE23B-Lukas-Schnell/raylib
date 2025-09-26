global using Raylib_cs;
global using System;

Setup.LoadSave();

Setup.WriteDictionary(Setup.highscores);

Raylib.SetTargetFPS(Setup.ChooseFPS());
Setup.Intructions();

Raylib.InitWindow(Setup.windowWidth, Setup.windowHeight, "Game");

new Player(800, 450);
new Enemy((int)(Raylib.GetScreenWidth() * 0.5f), 0);

//main loop
while (!Raylib.WindowShouldClose())
{
    Console.Clear(); 
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.White);
    for (int i = 0; i < MoveableObject.gameList.Count; i++)
    {
        MoveableObject.gameList[i].Update(); //först uppdatera alla värden
        MoveableObject.gameList[i].Draw(); // sen ritar man ut allt till skärmen

        if (MoveableObject.gameList[i].remove == true)
        {
            MoveableObject.gameList[i].Despawn();
        }
    }

    //denna rad skrevs av mikael 
    MoveableObject.gameList.RemoveAll(obj => obj.remove == true);

    for (int i = 0; i < MoveableObject.gameList.Count; i++)
    {
        Console.WriteLine(MoveableObject.gameList[i]); // gör det enklare att debugga
    }

    Raylib.DrawText(Raylib.GetFPS().ToString(), 0, 0, 30, Color.Black);


    Raylib.EndDrawing();
}