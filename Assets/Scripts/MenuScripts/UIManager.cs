using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public int gameSceneToLoad;

    public GameObject secondaryCanvas;
    public GameObject buttonsCanvas;
    public GameObject buttonBack;
    public GameObject credits;
    public GameObject options;

    


    // Start is called before the first frame update
    void Start()
    {
        secondaryCanvas.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneToLoad);
    }

    public void DisplayCredits()
    {
        secondaryCanvas.SetActive(true);
        buttonsCanvas.SetActive(false);
        options.SetActive(false);
        credits.SetActive(true);
        buttonBack.SetActive(true);
    }

    public void DisplayOptions()
    {
        secondaryCanvas.SetActive(true);
        buttonsCanvas.SetActive(false);
        options.SetActive(true);
        credits.SetActive(false);
        buttonBack.SetActive(true);
    }

   

    public void BackToMenu()
    {
        secondaryCanvas.SetActive(false);
        buttonsCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
