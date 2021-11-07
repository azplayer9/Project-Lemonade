using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public Button startButton;
    public GameObject mainMenu;
    public GameObject settingsObj;

    // Start is called before the first frame update
    void Start()
    {

        settingsObj = GameObject.Find("SettingsMenu");
        mainMenu = GameObject.Find("MainScreen");

        if (settingsObj) settingsObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && settingsObj.activeSelf)
        {
            HideSettings();
        }
        
    }

    //change scene to sample scene
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

   

    // toggle settings
    public void ShowSettings()
    {
        settingsObj.SetActive(true);
        mainMenu.SetActive(false);
        
    }

    public void HideSettings()
    {
        settingsObj.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
