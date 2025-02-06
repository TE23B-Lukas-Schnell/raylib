class Player : MoveableObject
{
    public float dashDuration = 0;
    public float dashCooldown = 0;
    public float shootCooldown = 0;

    public float moveSpeed = 900f;
    public float jumpForce = 1300f;
    public float setDashDuration = 0.2f;
    public float setDashCooldown = 0.43f;
    public float dashSpeed = 2000f;
    public float fastFallSpeed = 1400f;
    public float setShootCooldown = 0.5f;

    Color color = new Color(12, 0, 235, 255);

    bool grounded()
    {
        return y >= Raylib.GetScreenHeight() - width;
    }

    public void DecreaseCooldowns()
    {
        dashCooldown = MathF.Max(dashCooldown - 1 * Raylib.GetFrameTime(), 0);
        dashDuration = MathF.Max(dashDuration - 1 * Raylib.GetFrameTime(), 0);
        shootCooldown -= Raylib.GetFrameTime();
    }

    

    public override void Update()
    {
        DecreaseCooldowns();

        if (Raylib.IsKeyDown(KeyboardKey.A) || Raylib.IsKeyDown(KeyboardKey.Left))
        {
            xSpeed = -moveSpeed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.D) || Raylib.IsKeyDown(KeyboardKey.Right))
        {
            xSpeed = moveSpeed;
        }
        else xSpeed = 0;

        if (Raylib.IsKeyDown(KeyboardKey.S) && !grounded() || Raylib.IsKeyDown(KeyboardKey.Down) && !grounded())
        {
            ySpeed = -fastFallSpeed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.Space) && grounded() || Raylib.IsKeyDown(KeyboardKey.Z) && grounded())
        {
            ySpeed = jumpForce;
        }
        if (Raylib.IsKeyDown(KeyboardKey.LeftShift) && dashCooldown == 0 || Raylib.IsKeyDown(KeyboardKey.C) && dashCooldown == 0)
        {

            if (Raylib.IsKeyDown(KeyboardKey.A) || Raylib.IsKeyDown(KeyboardKey.Left))
            {
                dashSpeed = -dashSpeed;
                dashDuration = setDashDuration;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.D) || Raylib.IsKeyDown(KeyboardKey.Right))
            {
                dashSpeed = Math.Abs(dashSpeed);
                dashDuration = setDashDuration;
            }
        }

        if (dashDuration > 0)
        {
            xSpeed = dashSpeed;
            ySpeed = 0;
            dashCooldown = setDashCooldown;
        }

        if (Raylib.IsKeyDown(KeyboardKey.X) && shootCooldown <= 0 || Raylib.IsKeyDown(KeyboardKey.L) && shootCooldown <= 0)
        {
            shootCooldown = setShootCooldown;
            new PlayerBullet(x, y, 40, 20);
        }
        MoveObject(2300f);
    }

    public override void Draw()
    {
        if (dashDuration > 0)
        {
            AddTrailEffects(new Color(22, 15, 55, 255), 100, 100, 0, -1);
        }
        else
        {
            AddTrailEffects(new Color(0, 88, 255, 0), 100, 100, 0, 130);
        }
        Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)width, color);
    }


    public Player(int x, int y, float width, float height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        gameList.Add(this);
    }
}
