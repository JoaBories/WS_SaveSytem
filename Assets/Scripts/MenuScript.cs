using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject threeSavePanel;

    private void Start()
    {
        threeSavePanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayButton()
    {
        threeSavePanel.SetActive(true);
    }

    public void CloseThreeSave()
    {
        threeSavePanel.SetActive(false);
    }
}
