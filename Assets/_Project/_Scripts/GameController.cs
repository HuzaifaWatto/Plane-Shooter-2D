using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject PasueMenu;
    public GameObject GameOverPanel;
    public GameObject levelCompPanel;

    public Button PauseBtn;
    public Button ResumeBtn;
    public Button QuitBtn;

    public Text waveEnd;


    void Start()
    {
        Time.timeScale = 1f;
        PasueMenu.SetActive(false);   
        GameOverPanel.SetActive(false);
        levelCompPanel.SetActive(false);
        waveEnd.gameObject.SetActive(false);  
    }
    public void PauseGame()
    {
        PasueMenu.SetActive(true);
        PauseBtn.gameObject.SetActive(false);
        Time.timeScale = 0;
    }
    public void REsumeGame()
    {
        PasueMenu.SetActive(false);
        PauseBtn.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        PauseBtn.gameObject.SetActive(false);

    }
    public IEnumerator LevelComplete()
    {
        yield return new WaitForSeconds(2f);
        waveEnd.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        levelCompPanel.SetActive(true);
        Time.timeScale = 0;

    }
    public void Quit()
    {
        Application.Quit();
    }

}
