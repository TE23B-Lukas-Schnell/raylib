abstract class MoveableObject()
{
    public float x, y;
    public float xSpeed, ySpeed;
    public float width, height;
    public float gravity; // put zero for no gravity
    public static float globalGravity = 1;
    public bool canGoOffscreen = false;
    public static List<MoveableObject> gameList = new List<MoveableObject>();
    public static List<MoveableObject> removeList = new List<MoveableObject>();

    public bool remove = false;

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
            Color trailColor = new Color(trailColorSet.R + (int)(rMultiplier * trailTime), trailColorSet.G + (int)(gMultiPlier * trailTime), trailColorSet.B + (int)(bMultiplier * trailTime), trailColorSet.A + (int)(aMultiplier * trailTime));

            Raylib.DrawRectangle((int)pos.x, (int)pos.y, (int)width, (int)width, trailColor);
        }
    }

    public void MoveObject()
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

        if (!canGoOffscreen)
        {
            x = Math.Clamp(x, 0, Raylib.GetScreenWidth() - width);
            y = Math.Clamp(y, width, Raylib.GetScreenHeight() - width);
        }

        if (canGoOffscreen)
        {
            bool isOffscreen = x + width < 0 || x > Raylib.GetScreenWidth() ||
            y + height < 0 || y > Raylib.GetScreenHeight();

            if (isOffscreen)
            {
                remove = true;
            }
        }
    }
    abstract public void Update();
    abstract public void Draw();
}
