class Enemy : MoveableObject
{
    public float moveSpeed;
    public float gravity = 2300f;
    bool movingLeft = false;
    Color color = new Color(255, 60, 35, 255);

    public override void Update()
    {
        if (x < Raylib.GetScreenWidth() && !movingLeft)
        {
            xSpeed = moveSpeed;
        }
        if (x == Raylib.GetScreenWidth() - width)
        {
            movingLeft = true;
            xSpeed = -moveSpeed;
        }
        if (x < Raylib.GetScreenWidth() * 0.7)
        {
            movingLeft = false;
        }
        MoveObject(gravity);
    }
    public override void Draw()
    {
        Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)width, color);
    }

    public Enemy(int x, int y)
    {
        this.x = x;
        this.y = y;
        width = Setup.windowWidth * 0.11f;
        gameList.Add(this);
        moveSpeed = 500f;
    }
}

