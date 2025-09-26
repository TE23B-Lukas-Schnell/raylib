abstract class Projectile : MoveableObject
{
    public float damage;
    public bool piercing = false;

    // when you collide with an enemy, check whether 
    public void OnHit(float damage, string objectIdentifier)
    {
        MoveableObject? target = CheckCollisions();
        if (target != null)
        {
            if (target.objectIdentifier == objectIdentifier)
            {
                target.TakeDamage(damage, target);
                if (!piercing)
                {
                    remove = true;
                }
            }

        }
    }
}