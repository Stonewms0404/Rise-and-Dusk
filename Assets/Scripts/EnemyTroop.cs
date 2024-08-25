using System;
using UnityEngine;

public class EnemyTroop : Enemy
{
    void Update()
    {
        (bool isFriendlyNearby, Friendly f) = CheckFriendliesInRadius();
        if (isFriendlyNearby)
        {
            friendly = f;
            MoveTowardsFriendly();
        }
        (isFriendlyNearby, f) = FindTower();
        if (isFriendlyNearby)
        {
            friendly = f;
            MoveTowardsFriendly();
        }
        if (canAttack)
        {
            agent.SetDestination(transform.position);
            Attack();
        }
        else
            agent.SetDestination(friendly.transform.position);
    }

    void Attack()
    {

    }
}
