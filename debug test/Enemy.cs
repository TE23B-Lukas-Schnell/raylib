class Enemy : Boss
{
    bool movingLeft = false;
    Color color = new Color(255, 60, 35, 255);
    
    public override void MoveCycle()
    {
        moveSpeed = 500f;
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

    }
    public override void Attack1()
    {


    }
    public override void Attack2()
    {


    }
    public override void Attack3()
    {


    }
    public override void Attack4()
    {


    }


    public override void Update()
    {
        gravity = 2300f;
        MoveCycle();
        MoveObject();
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
    }
}

