abstract class Boss : MoveableObject
{
    public float hitPoints;
    public float damageMultiplier;
    public float moveSpeed;


    abstract public void MoveCycle();
    abstract public void Attack1();
    abstract public void Attack2();
    abstract public void Attack3();
    abstract public void Attack4();


}


class Enemy : Boss
{
    Color color = new Color(255, 60, 35, 255);
    public override void MoveCycle()
    {
        if (x < Setup.windowWidth)
        {
            xSpeed = moveSpeed;
        }
        if(x > Setup.windowWidth){
            xSpeed = -moveSpeed;
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
        Raylib.DrawRectangle((int)x, (int)y, (int)size, (int)size, color);
    }


    public Enemy(int x, int y, float size)
    {
        this.x = x;
        this.y = y;
        this.size = size;
        gameList.Add(this);
    }
}





