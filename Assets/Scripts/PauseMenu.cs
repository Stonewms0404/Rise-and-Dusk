using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    
    private void Start()
    {
        pausePanel.SetActive(false);
      
    }
    public void ToggleMenu()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        Time.timeScale = pausePanel.activeSelf ? 1.0f : 0.0f;
   
    }
    public void ToggleOptions()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
    
    }
    public void GotoMainMenu()
    {

    }
}
