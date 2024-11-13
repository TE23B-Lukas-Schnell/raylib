class Player : MoveableObject
{
    float moveSpeed = 1000f;
    float jumpForce = 18f;
    float radius = 69.69f;
    

    public override void Update()
    {
        gravity = 5;
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            xSpeed = -moveSpeed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            xSpeed = moveSpeed;
        }
        else xSpeed = 0;
        if (Raylib.IsKeyDown(KeyboardKey.Space))
        {
            ySpeed = jumpForce;
        }
        moveObject();
    }

    public override void Draw()
    {
        Raylib.DrawCircle(x, y, radius, Color.DarkGreen);
    }


    public Player(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

}