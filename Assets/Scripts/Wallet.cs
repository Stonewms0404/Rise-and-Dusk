using Mono.Cecil.Cil;
using System.Transactions;
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
