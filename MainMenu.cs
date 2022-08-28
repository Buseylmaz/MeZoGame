using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject loadText;

    public GameObject loadButton;
    public int loadInt;

    void Start()
    {

        loadInt = PlayerPrefs.GetInt("AutoSave");//loadInt'i AutoSave değerine eşitleyecek
        if (loadInt > 0)
        {
            loadButton.SetActive(true);
        }
    }
   
    public void NewGameButton()
    {
        StartCoroutine(NewGame());
    }

    IEnumerator NewGame()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        loadText.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(4);//1.sahneye gelmesi yani ana sahne geliyor
    }

    public void LoadGameButton()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        loadText.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(loadInt);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
