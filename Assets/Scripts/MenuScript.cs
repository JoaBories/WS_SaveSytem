using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    [SerializeField] GameObject continueButton;

    private void Start()
    {
        if (!SaveSystem.instance.HasASave())
        {
            continueButton.SetActive(false);
        }
    }

    public void NewGame()
    {
        SaveSystem.instance.ResetFile();
        SceneManager.LoadScene(1);
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
