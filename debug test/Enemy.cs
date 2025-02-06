class Enemy : MoveableObject
{
    public float moveSpeed;
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
        MoveObject(2300f);
    }
    public override void Draw()
    {
        Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)width, color);
    }

    public Enemy(int x, int y, float size)
    {
        this.x = x;
        this.y = y;
        this.width = size;
        gameList.Add(this);
        moveSpeed = 500f;
    }
}

