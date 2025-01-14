class PlayerBullet : Bullet
{
    Color color = new Color(255, 0, 0, 255);
    public override void Update()
    {
        gravity = 0;
        xSpeed = 2000;
        MoveObject();
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)x, (int)y, (int)size, (int)size, color);
    }

    public PlayerBullet(float x, float y)
    {
        this.x = x;
        this.y = y;
        this.size = 10;
        gameList.Add(this);
    }
}