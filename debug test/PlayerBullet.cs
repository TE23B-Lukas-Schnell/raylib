class PlayerBullet : Bullet
{
    public float gravity = 0;
    Color color = new Color(255, 0, 0, 255);

    public override void Update()
    {
        OnHit(damage);
        MoveObject(gravity);
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)height, color);
        ShowHitboxes();
    }
     public override void Despawn()
    {
    
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
        damage = 5;
    }
}