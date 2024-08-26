using System;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] FriendlyTower[] towers;
    [SerializeField] Wallet wallet;
    private GameObject buildingArea;
    [SerializeField] Stats[] statsList;
    public void BuyTower(int value)
    {
        if (wallet.Transaction(statsList[value].damage))
        {
            Instantiate(towers[value], buildingArea.transform.position, Quaternion.identity);
            Debug.Log(buildingArea.name);
            Destroy(buildingArea);
            ToggleShop(false, null);
        }
    }

    private void Start()
    {
        panel.SetActive(false);
    }

    private void OnEnable()
    {
        BuildingArea.ToggleShop += ToggleShop;
    }
    private void OnDisable()
    {
        BuildingArea.ToggleShop -= ToggleShop;
    }

    public void ToggleShop(bool value, GameObject gObj)
    {
        buildingArea = gObj;
        panel.SetActive(value);
    }
}
