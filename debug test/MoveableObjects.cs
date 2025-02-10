abstract class MoveableObject()
{
    //lista för alla objekt som ska hanteras, det är lista för att den kan öka och minska under runtime
    public static List<MoveableObject> gameList = new List<MoveableObject>();
    public static float globalGravityMultiplier = 1;

    public float x, y;
    public float xSpeed, ySpeed;
    public float width, height;
    public bool canGoOffscreen = false;
    public bool remove = false;

    public string collisionType = "";
    public Rectangle GetHitbox() => new Rectangle(x, y, width, height);
    public bool ShowHitboxesSwitch() => Raylib.IsKeyDown(KeyboardKey.W);
    public void ShowHitboxes()
    {
        if (ShowHitboxesSwitch())
        {
            Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)width, Color.Red);
        }
    }

    public string CheckCollisions()
    {
        foreach (MoveableObject obj in gameList)
        {
            if (obj != this) // Avoid self-collision
            {
                if (Raylib.CheckCollisionRecs(this.GetHitbox(), obj.GetHitbox()))
                {
                    return obj.collisionType;
                    // Console.WriteLine("${obj} asg nazg durbatuluk asg nazg gimbatul asg nazg thrakatuluk");
                }
            }
        }
        return "";
    }

    (float x, float y)[] lastPositions = new (float x, float y)[20];
    int positionIndex = 0;

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
            ySpeed -= gravity * globalGravityMultiplier * Raylib.GetFrameTime();
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