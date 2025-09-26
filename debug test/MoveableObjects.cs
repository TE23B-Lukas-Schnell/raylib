abstract class MoveableObject()
{
    //lista för alla objekt som ska hanteras, det är lista för att den kan öka och minska under runtime
    public static List<MoveableObject> gameList = new List<MoveableObject>();
    public static float globalGravityMultiplier = 1;

    public string objectIdentifier = "";
    public float maxHP;
    public float hp;
    public float damageMultiplier = 1;
    public float x, y;
    public float xSpeed, ySpeed;
    public float width, height;
    public bool canGoOffscreen = false;
    public bool remove = false;
    public bool Grounded() => y >= Raylib.GetScreenHeight() - width;

    public void DisplayHealthBar(float xpos, float ypos, float sizeMultiplier)
    {
        Raylib.DrawRectangle((int)xpos, (int)ypos, (int)(maxHP * sizeMultiplier) + 10, 60, Color.Gray);
        Raylib.DrawRectangle((int)xpos + 5, (int)ypos + 5, (int)(hp * sizeMultiplier), 50, Color.Green);
    }

    public Rectangle GetHitbox() => new Rectangle(x, y, width, height);
    public bool ShowHitboxesSwitch() => Raylib.IsKeyDown(KeyboardKey.W);

    public void ShowHitboxes()//enklare att testa programmet och kan hjälpa senare när hitboxes inte matchar spriten
    {
        if (ShowHitboxesSwitch())
        {
            Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)height, Color.Red);
        }
    }

    //returnar objektet som kollideras med 
    public MoveableObject? CheckCollisions()
    {
        foreach (MoveableObject obj in gameList)
        {
            if (obj != this)
            {
                if (Raylib.CheckCollisionRecs(GetHitbox(), obj.GetHitbox()))
                {
                    return obj;
                    // Console.WriteLine("${obj} asg nazg durbatuluk asg nazg gimbatul asg nazg thrakatuluk av jack");
                }
            }
        }
        return null;
    }

    //objektet hp minskar, tas bort om det är < 0
    public void TakeDamage(float damage, MoveableObject target)
    {
        target.hp -= damage * damageMultiplier;
        if (hp <= 0)
        {
            target.remove = true;
        }
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

    //funktioner relaterade till positions värden

    // förklarar sig själv tycker jag, positionen kan aldrig gå offscreen
    public void LimitMovement()
    {
        x = Math.Clamp(x, 0, Raylib.GetScreenWidth() - width);
        y = Math.Clamp(y, width, Raylib.GetScreenHeight() - width);
    }


    //tar bort objekt om de är offscreen
    public void HandleOffscreen()
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
            LimitMovement();
        }
    }

    //gör så att objektet blir påverkat av gravitation, specifiera i parametern
    public void ApplyGravity(float gravity)
    {
        if (y <= Raylib.GetScreenHeight() - width)
        {
            ySpeed -= gravity * globalGravityMultiplier * Raylib.GetFrameTime();
        }
        else
        {
            ySpeed = 0;
        }
    }

    //flyttar objekt, denna funktion behövs för alla objekt som rör på sig
    public void MoveObject(float gravity)
    {
        x += xSpeed * Raylib.GetFrameTime();
        y -= ySpeed * Raylib.GetFrameTime();

        ApplyGravity(gravity);
        HandleOffscreen();
    }

    /// <summary>
    /// kallas varje frame, ska ändra värden
    /// </summary>
    abstract public void Update();
    /// <summary>
    /// kallas varje frame, ska rita ut till skärmen
    /// </summary>
    abstract public void Draw();
    /// <summary>
    /// kallas när objektet försvinner, är förmodligen onödig
    /// </summary>
    abstract public void Despawn();
}