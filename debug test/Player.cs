class Player : MoveableObject
{

    public float dashDuration = 0;
    public float dashCooldown = 0;
    public float shootCooldown = 0;

    //konstanter
    public float gravity = 2300f;
    public float moveSpeed = 900f;
    public float jumpForce = 1300f;
    public float setDashDuration = 0.2f;
    public float setDashCooldown = 0.43f;
    public float dashSpeed = 2000f;
    public float fastFallSpeed = 1400f;
    public float setShootCooldown = 0.5f;
    Color color = new Color(12, 0, 235, 255);
    public float bulletWidth = 40;
    public float bulletHeight = 20;

    public bool Grounded() => y >= Raylib.GetScreenHeight() - width;

    //keybinds
    public bool LeftKeyPressed() => Raylib.IsKeyDown(KeyboardKey.A) || Raylib.IsKeyDown(KeyboardKey.Left);
    public bool RightKeyPressed() => Raylib.IsKeyDown(KeyboardKey.D) || Raylib.IsKeyDown(KeyboardKey.Right);
    public bool DownKeyPressed() => Raylib.IsKeyDown(KeyboardKey.S) || Raylib.IsKeyDown(KeyboardKey.Down);
    public bool UpKeyPressed() => Raylib.IsKeyDown(KeyboardKey.W) || Raylib.IsKeyDown(KeyboardKey.Up);
    public bool JumpKeyPressed() => Raylib.IsKeyDown(KeyboardKey.Space) || Raylib.IsKeyDown(KeyboardKey.Z);
    public bool DashKeyPressed() => Raylib.IsKeyDown(KeyboardKey.LeftShift) || Raylib.IsKeyDown(KeyboardKey.C);
    public bool ShootKeyPressed() => Raylib.IsKeyDown(KeyboardKey.L) || Raylib.IsKeyDown(KeyboardKey.X);


    //moves the player
    public void MovingLeftAndRight()
    {
        if (LeftKeyPressed())
        {
            xSpeed = -moveSpeed;
        }
        else if (RightKeyPressed())
        {
            xSpeed = moveSpeed;
        }
        else xSpeed = 0;
    }
    //makes the player fastfall
    public void FastFalling()
    {
        if (DownKeyPressed() && !Grounded())
        {
            ySpeed = -fastFallSpeed;
        }
    }
    //makes the player jump
    public void Jumping()
    {
        if (JumpKeyPressed() && Grounded())
        {
            ySpeed = jumpForce;
        }
    }
    //makes the player dash
    public void Dashing()
    {
        if (DashKeyPressed() && dashCooldown == 0)
        {
            if (LeftKeyPressed())
            {
                dashSpeed = -dashSpeed;
                dashDuration = setDashDuration;
            }
            else if (RightKeyPressed())
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
    }

    //makes the player shoot
    public void Shooting()
    {
        if (ShootKeyPressed() && shootCooldown <= 0)
        {
            shootCooldown = setShootCooldown;
            new PlayerBullet(x, y, bulletWidth, bulletHeight);
        }

    }
    public override void Update()
    {
        dashCooldown = MathF.Max(dashCooldown - Raylib.GetFrameTime(), 0);
        dashDuration = MathF.Max(dashDuration - Raylib.GetFrameTime(), 0);
        shootCooldown = MathF.Max(shootCooldown - Raylib.GetFrameTime(), 0);
        
        MovingLeftAndRight();
        FastFalling();
        Jumping();
        Dashing();
        Shooting();

        MoveObject(gravity);
        CheckCollisions();
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
        Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)height, color);
        ShowHitboxes();
    }
    public override void Despawn()
    {
        
    }

    public Player(int x, int y)
    {
        this.x = x;
        this.y = y;
        width = Setup.windowWidth * 0.05f;
        height = Setup.windowWidth * 0.05f;
        gameList.Add(this);
    }
}