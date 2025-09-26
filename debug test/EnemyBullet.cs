class EnemyBullet : Projectile
{
    public float gravity;

    Color color = new Color(255, 0, 0, 255);

    public override void Update()
    {
        OnHit(damage, "player");
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

    public EnemyBullet(float x, float y, float width, float height, float xSpeed, float ySpeed, float gravity)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.xSpeed = xSpeed;
        this.ySpeed = ySpeed;
        this.gravity = gravity;
        gameList.Add(this);
        canGoOffscreen = true;
        damage = 1;
    }
}