class PlayerBullet : MoveableObject
{
    Color color = new Color(255, 0, 0, 255);

    public override void Update()
    {
        MoveObject(0f);
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)height, color);
    }

    public PlayerBullet(float x, float y, float width, float height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        gameList.Add(this);
        xSpeed = 2000;
        canGoOffscreen = true;
    }
}