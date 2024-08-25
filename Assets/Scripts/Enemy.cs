using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    #region Renderer
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    [SerializeField] SpriteRenderer renderer;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    #endregion
    [SerializeField] protected Stats stats;
    [SerializeField] protected NavMeshAgent agent;
    protected Friendly friendly;
    protected Enemy enemy;
    protected bool canAttack;

    void Awake()
    {
        renderer.sprite = stats.texture;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    protected (bool, Friendly) CheckFriendliesInRadius()
    {
        Friendly[] friendlies = GameObject.FindObjectsByType<Friendly>(FindObjectsSortMode.None);
        foreach (Friendly friendly in friendlies)
        {
            if (friendly.isTower) continue;
            float distance = (friendly.transform.position - transform.position).magnitude;
            if (distance <= stats.sightRadius)
                return (true, friendly);
        }
        return (false, null);
    }
    protected (bool, Enemy) CheckEnemiesInRadius()
    {
        Enemy[] friendlies = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach (Enemy friendly in friendlies)
        {
            if (friendly.stats.health <= friendly.stats.health * 0.5f) continue;
            float distance = (friendly.transform.position - transform.position).magnitude;
            if (distance <= stats.sightRadius)
                return (true, friendly);
        }
        return (false, null);
    }

    protected (bool, Friendly) FindTower()
    {
        Friendly[] friendlies = GameObject.FindObjectsByType<Friendly>(FindObjectsSortMode.None);
        foreach (Friendly f in friendlies)
        {
            if (!f.isTower) continue;
            return (true, f);
        }
        return (false, null);
    }

    protected void MoveTowardsFriendly()
    {
        float distance = (friendly.transform.position - transform.position).magnitude;
        canAttack = distance <= stats.attackRadius;
        agent.SetDestination(canAttack ? transform.position : friendly.transform.position);
    }
    protected void MoveTowardsEnemy()
    {
        float distance = (enemy.transform.position - transform.position).magnitude;
        canAttack = distance <= stats.attackRadius;
        agent.SetDestination(canAttack ? transform.position : enemy.transform.position);
    }
}
