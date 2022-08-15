using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject gameCanvas;
    public GameObject pauseCanvas;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        gameCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game...");
        Application.Quit();
    }

    public void Resume()
    {
        Debug.Log("Resuming...");
        Time.timeScale = 1f;
        gameIsPaused = false;
        pauseCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }

    public void QuitToMenu()
    {
        Debug.Log("Quit to menu...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
