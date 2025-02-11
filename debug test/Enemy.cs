class Enemy : MoveableObject
{
    public float moveSpeed;
    public float gravity = 2300f;
    bool movingLeft = false;
    Color color = new Color(60, 255, 125, 255);

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
        Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)height, color);
        ShowHitboxes();
        Raylib.DrawRectangle(50, 50, (int)hp, 50, Color.Green);
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
}