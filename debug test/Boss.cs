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

