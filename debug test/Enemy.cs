class Enemy : MoveableObject
{
    public float moveSpeed;
    public float gravity = 2300f;
    
    bool movingUp = false;
    Color color = new Color(60, 255, 125, 255);

    public void moveInADirection()
    {
        bool moving = false;
        if (x < Raylib.GetScreenWidth() && !moving)
        {
            xSpeed = moveSpeed;
        }
        if (x == Raylib.GetScreenWidth() - width)
        {
            moving = true;
            xSpeed = -moveSpeed;
        }
        if (x < Raylib.GetScreenWidth() * 0.7)
        {
            moving = false;
        }
    }

    public override void Update()
    {

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
}