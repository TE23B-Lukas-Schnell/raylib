abstract class MoveableObject()
{
    public int x, y;
    public float xSpeed, ySpeed;
    public float gravity; // put zero for no gravity

    public void moveObject()
    {
        y += (int)(gravity * Raylib.GetFrameTime());
        x += (int)(xSpeed * Raylib.GetFrameTime());
        y -= (int)(ySpeed * Raylib.GetFrameTime());
    }

    abstract public void Update();
    abstract public void Draw();
}