abstract class MoveableObject()
{
    public float x, y;
    public float xSpeed, ySpeed;
    public float width, height;
    public float gravity;
    public bool canGoOffscreen = false;
    (float x, float y)[] lastPositions = new (float x, float y)[20];
    int positionIndex = 0;
    public bool remove = false;

    //lista för alla objekt som ska hanteras, det är
    public static List<MoveableObject> gameList = new List<MoveableObject>();
    public static float globalGravity = 1;

    //denna funktion gjordes av chatgpt
    public void AddTrailEffects(Color trailColorSet, float rMultiplier, float gMultiPlier, float bMultiplier, float aMultiplier)
    {
        lastPositions[positionIndex] = (x, y);
        positionIndex = (positionIndex + 1) % lastPositions.Length;

        for (int i = 0; i < lastPositions.Length; i++)
        {
            int index = (positionIndex + i) % lastPositions.Length;
            var pos = lastPositions[index];

            float trailTime = (float)(lastPositions.Length - i) / lastPositions.Length;
            Color trailColor = new Color(trailColorSet.R + (int)(rMultiplier * trailTime), trailColorSet.G + (int)(gMultiPlier * trailTime), trailColorSet.B + (int)(bMultiplier * trailTime), trailColorSet.A + (int)(aMultiplier * trailTime));

            Raylib.DrawRectangle((int)pos.x, (int)pos.y, (int)width, (int)width, trailColor);
        }
    }

    //tar bort objekt om de är offscreen
    public void RemoveObject()
    {
        if (canGoOffscreen)
        {
            bool isOffscreen = x + width < 0 || x > Raylib.GetScreenWidth() ||
            y + height < 0 || y > Raylib.GetScreenHeight();

            if (isOffscreen)
            {
                remove = true;
            }
        }
        else
        {
            x = Math.Clamp(x, 0, Raylib.GetScreenWidth() - width);
            y = Math.Clamp(y, width, Raylib.GetScreenHeight() - width);
        }
    }

    //flyttar objekt, denna funktion behövs för alla objekt som rör på sig
    public void MoveObject(float gravity)
    {
        x += xSpeed * Raylib.GetFrameTime();
        y -= ySpeed * Raylib.GetFrameTime();


        if (y <= Raylib.GetScreenHeight() - width)
        {
            ySpeed -= gravity * globalGravity * Raylib.GetFrameTime();
        }
        else
        {
            ySpeed = 0;
        }
        RemoveObject();
    }

    //update funktionen updaterar alla värden varje frame
    abstract public void Update();
    //draw funktionen ritar ut alla rektanglar
    abstract public void Draw();
}
