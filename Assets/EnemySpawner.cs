using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy[] enemies;
    int wave = 0;

    private void OnEnable()
    {
        DayNightCycle.Cycle += SpawnEnemies;
    }
    private void OnDisable()
    {
        DayNightCycle.Cycle -= SpawnEnemies;
    }

    void SpawnEnemies(bool value)
    {
        if (!value)
        {
            wave++;
            int numOfTroops, numOfHealers, numOfTanks;
            numOfTanks = (wave / 5) * 2;
            numOfTroops = wave * 4;
            numOfHealers = wave;

            for (int i = 0; i < numOfTroops; i++)
            {
                Vector2 offset = (new Vector2(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5, 5f))).normalized * 2;
                Instantiate(enemies[0], offset + (Vector2)transform.position, Quaternion.identity, transform);
            }
            for (int i = 0; i < numOfHealers; i++)
            {
                Vector2 offset = (new Vector2(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5, 5f))).normalized * 2;
                Instantiate(enemies[1], offset + (Vector2)transform.position, Quaternion.identity, transform);
            }
            for (int i = 0; i < numOfTanks; i++)
            {
                Vector2 offset = (new Vector2(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5, 5f))).normalized * 2;
                Instantiate(enemies[2], offset + (Vector2)transform.position, Quaternion.identity, transform);
            }
        }
    }
}
