using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

abstract class MoveableObject()
{
    public float x, y;
    public float xSpeed, ySpeed;
    public float size;
    public float gravity; // put zero for no gravity
    public static float globalGravity = 1;
    public bool canGoOffscreen = false;
    public static List<MoveableObject> gameList = new List<MoveableObject>();

    (float x, float y)[] lastPositions = new (float x, float y)[20];
    int positionIndex = 0;

    public void AddTrailEffects(Color trailColorSet, float rMultiplier, float gMultiPlier, float bMultiplier, float aMultiplier)
    {
        lastPositions[positionIndex] = (x, y);
        positionIndex = (positionIndex + 1) % lastPositions.Length;

        for (int i = 0; i < lastPositions.Length; i++)
        {
            int index = (positionIndex + i) % lastPositions.Length;
            var pos = lastPositions[index];

            float trailTime = (float)(lastPositions.Length - i) / lastPositions.Length;
            Color trailColor = new Color(Math.Min(255, trailColorSet.R + (int)(rMultiplier * trailTime)), Math.Min(255, trailColorSet.G + (int)(gMultiPlier * trailTime)), Math.Min(255, trailColorSet.B + (int)(bMultiplier * trailTime)), Math.Min(255, trailColorSet.A + (int)(aMultiplier * trailTime)));
            
            Raylib.DrawRectangle((int)pos.x, (int)pos.y, (int)size, (int)size, trailColor);
        }
    }
    

    public void MoveObject()
    {
        x += xSpeed * Raylib.GetFrameTime();
        y -= ySpeed * Raylib.GetFrameTime();

        if (y <= SystemVariables.windowHeight - size)
        {
            ySpeed -= gravity * globalGravity * Raylib.GetFrameTime();
        }
        else
        {
            ySpeed = 0;
        }

        if (!canGoOffscreen)
        {
            x = Math.Clamp(x, 0, SystemVariables.windowWidth - size);
            y = Math.Clamp(y, size, SystemVariables.windowHeight - size);
        }
    }

    abstract public void Update();
    abstract public void Draw();
}