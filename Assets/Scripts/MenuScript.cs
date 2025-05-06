using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject areYouSurePanel;

    private void Start()
    {
        if (!SaveSystem.instance.HasASave())
        {
            continueButton.SetActive(false);
        }

        areYouSurePanel.SetActive(false);
    }

    public void Yes()
    {
        SaveSystem.instance.ResetFile();
        SceneManager.LoadScene(1);
    }

    public void No()
    {
        areYouSurePanel.SetActive(false);
    }

    public void NewGame()
    {
        if (SaveSystem.instance.HasASave())
        {
            areYouSurePanel.SetActive(true);
        }
        else
        {
            SaveSystem.instance.ResetFile();
            SceneManager.LoadScene(1);
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
