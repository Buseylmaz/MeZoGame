using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadManager : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject mainButton;
    public GameObject quitButton;
    public int loadInt;

    public GameObject loadText;
    public GameObject fadeOut;
    public GameObject fadeOut_2;

    void Start()
    {
        loadInt = PlayerPrefs.GetInt("AutoSave");
    }

    
    void Update()
    {
        
    }

    public void Restart()
    {
        StartCoroutine(RestartLevel());
    }
    IEnumerator RestartLevel()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        loadText.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(loadInt);
    }

    public void ToMainMenu()
    {
        StartCoroutine(MainMenuBack());
        
    }
    IEnumerator MainMenuBack()
    {
        fadeOut_2.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
