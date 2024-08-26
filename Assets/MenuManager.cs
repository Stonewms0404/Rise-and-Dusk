using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] string mainLevel;
    [SerializeField] GameObject howToPlay;
    [SerializeField] GameObject mainMenu;

    void Start()
    {
        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene(mainLevel);
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
