using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndQuit : MonoBehaviour
{
    public void OnSaveAndQuit()
    {
        SaveSystem.instance.Save();
        SceneManager.LoadScene(0);
    }
}
