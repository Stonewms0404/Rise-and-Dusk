using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject panel;

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

    public void ToggleShop(bool value)
    {
        panel.SetActive(value);
    }
}
