using UnityEngine;

public class FriendlyTank : Friendly
{
    float timer;
    void Update()
    {
        timer += Time.deltaTime;

        (bool isFriendlyNearby, Enemy f) = FindEnemy();
        if (isFriendlyNearby)
        {
            enemy = f;
            MoveTowardsEnemy();
            return;
        }

        if (canAttack)
        {
            agent.SetDestination(transform.position);
            if (timer >= 1)
            {
                timer = 0;
                Attack();
            }
            
        }
        else
            agent.SetDestination(enemy.transform.position);
    }

    void Attack()
    {
        enemy.TakeDamage(stats.damage);
    }
}
