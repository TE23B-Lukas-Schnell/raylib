class Enemy : MoveableObject
{
    public float moveSpeed;
    public float gravity = 2300f;

    Color color = new Color(60, 255, 125, 255);

    public void moveCycle(float value, float minValue, float maxValue)
    {
        if (value >= maxValue)
        {
            xSpeed = -Math.Abs(moveSpeed);
        }
        else if (value <= minValue)
        {
            xSpeed = Math.Abs(moveSpeed); 
        }
    }

    public override void Update()
    {
        moveCycle(x, Raylib.GetScreenWidth() * 0.7f, Raylib.GetScreenWidth() - width);
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