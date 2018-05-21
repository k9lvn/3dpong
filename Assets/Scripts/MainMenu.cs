using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject OkButton;
    public Text ButtonOkText;
    public GameObject HelpPopupBackground;
    public Button start, help, exit, ok;


    void Start()
    {
        OkButton.SetActive(false);
        ButtonOkText.enabled = false;
        HelpPopupBackground.SetActive(false);
    
        start.onClick.AddListener(StartGame);
        help.onClick.AddListener(Help);
        exit.onClick.AddListener(ExitGame);
        ok.onClick.AddListener(ClickOK);

    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void ExitGame()
    {
        Application.Quit();
    }

    void Help()
    {
        Debug.Log("HELP");
        OkButton.SetActive(true);
        ButtonOkText.enabled = true;
        HelpPopupBackground.SetActive(true);
    }

    void ClickOK()
    {
        Debug.Log("OK");
        OkButton.SetActive(false);
        ButtonOkText.enabled = false;
        HelpPopupBackground.SetActive(false);
    }
}
