using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] int startAmount;
    [SerializeField] TextMeshProUGUI text;
    public int balance { get; private set; }

    void Start()
    {
        Transaction(startAmount);
    }
    private void OnEnable()
    {
        Enemy.EnemyDeath += GetLoot;
    }
    private void OnDisable()
    {
        Enemy.EnemyDeath -= GetLoot;
    }

    void GetLoot(int value)
    {
        Transaction(value);
    }

    public bool Transaction(int value)
    {
        balance += value;
        if (balance < 0)
        {
            balance += value;
            return false;
        }
        else
        {
            text.text = balance + "";
            return true;
        }
    }
}
