class Enemy : MoveableObject
{
    public float moveSpeed;
    public float gravity = 2300f;

    Color color = new Color(60, 255, 125, 255);

    public void båtSlashKött(float positionValue, float minValue, float maxValue)
    {
        bool movingToMax = false;
        if (positionValue >= maxValue)
        {
            movingToMax = false;
        }
        if (positionValue <= minValue)
        {
            movingToMax = true;
        }

        
        if (movingToMax)
        {
            xSpeed = moveSpeed;
        }
        if (!movingToMax)
        {
            xSpeed = -moveSpeed;
        }
    }

    public override void Update()
    {
        // moveInADirection(x, Raylib.GetScreenWidth() * 0.7f, Raylib.GetScreenWidth());
        // moveInADirection(x, 1000, Setup.windowWidth);

        båtSlashKött(x, Raylib.GetScreenWidth() * 0.7f, Raylib.GetScreenWidth());
        MoveObject(gravity);
    }
    public override void Draw()
    {
        Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)height, color);
        ShowHitboxes();
        Raylib.DrawRectangle(50, 50, (int)hp, 50, Color.Green);
    }
    public override void Despawn()
    {

    }

    public Enemy(int x, int y)
    {
        this.x = x;
        this.y = y;
        width = Setup.windowWidth * 0.11f;
        height = Setup.windowWidth * 0.11f;
        gameList.Add(this);
        moveSpeed = 500f;
        hp = 600;
    }

    public void moveInADirection(float positionValue, float minPositionValue, float maxPositionValue)
    {
        bool movingToMax = true;
        if (positionValue < maxPositionValue && !movingToMax)
        {
            xSpeed = -moveSpeed;
        }
        if (x >= Raylib.GetScreenWidth() - width)
        {
            movingToMax = false;
            xSpeed = -moveSpeed;
        }
        if (x < minPositionValue)
        {
            movingToMax = true;
        }
    }

}