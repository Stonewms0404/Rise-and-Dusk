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
            int alloc = wave;
            Debug.Log(alloc);
            int numOfTroops, numOfHealers, numOfTanks;
            numOfTanks = (alloc / 5) * 2;
            alloc /= numOfTanks == 0 ? 1 : numOfTanks * 2;
            Debug.Log(alloc);
            numOfTroops = alloc * 3;
            numOfHealers = alloc;

            for (int i = 0; i < numOfTroops; i++)
                Instantiate(enemies[0], transform);
            for (int i = 0; i < numOfHealers; i++)
                Instantiate(enemies[1], transform);
            for (int i = 0; i < numOfTanks; i++)
                Instantiate(enemies[2], transform);
        }
    }
}
