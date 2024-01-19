using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : RestartScene
{
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Time.timeScale == 1)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(restartScene);
    }

    public void Quit()
    {
        SceneManager.LoadScene(mainMenuScene);
        Time.timeScale = 1; 
    }
}
