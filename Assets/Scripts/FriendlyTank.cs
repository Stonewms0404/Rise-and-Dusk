using UnityEngine;

public class FriendlyTank : Friendly
{
    void Update()
    {
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
            Attack();
        }
        else
            agent.SetDestination(enemy.transform.position);
    }

    void Attack()
    {

    }
}
