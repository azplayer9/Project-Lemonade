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
    public Animation fade;

    // Start is called before the first frame update
    void Start()
    {
        //settingsObj = GameObject.Find("SettingsMenu");
        mainMenu = GameObject.Find("MainScreen");
        fade = GameObject.Find("Fade").GetComponent<Animation>();

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
        Debug.Log("Start Game");
        SceneManager.LoadScene("SampleScene");
        //Invoke("ChangeScene", 1.0f);
        //fade.Play();
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
