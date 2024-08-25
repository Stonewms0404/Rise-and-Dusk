using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject optionsPanel;
    private void Start()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
    public void ToggleMenu()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        Time.timeScale = pausePanel.activeSelf ? 1.0f : 0.0f;
        optionsPanel.SetActive(false);
    }
    public void ToggleOptions()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }
    public void GotoMainMenu()
    {

    }
}
