abstract class Bullet : MoveableObject
{
    public float damage; 

    // when you collide with an enemy
    public void OnHit(float damage)
    {
        MoveableObject target = CheckCollisions();
        if (target is Enemy)
        {
            target.TakeDamage(damage, target);
            remove = true;
        }
    }

}



