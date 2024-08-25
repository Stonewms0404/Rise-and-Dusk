using UnityEngine;

public class FriendlyHealer : Friendly
{
    void Update()
    {
        (bool isFriendlyNearby, Friendly f) = CheckFriendliesInRadius();
        if (isFriendlyNearby)
        {
            friendly = f;
            MoveTowardsFriendly();
        }
        if (canAttack)
        {
            agent.SetDestination(transform.position);
            Heal();
        }
        else
            agent.SetDestination(friendly.transform.position);
    }

    void Heal()
    {

    }
}
