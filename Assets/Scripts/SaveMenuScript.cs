using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMenuScript : MonoBehaviour
{
    [SerializeField] int saveNumber;
    [SerializeField] GameObject hasSave;
    [SerializeField] TextMeshProUGUI coinCounter;
    [SerializeField] GameObject noSave;

    private void Start()
    {
        UpdateSaveMenu();
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("SaveIndex", saveNumber);
        SceneManager.LoadScene(1);
    }

    public void Delete()
    {
        PlayerPrefs.SetInt("SaveIndex", saveNumber);
        SaveSystem.instance.ResetFile();
        UpdateSaveMenu();
    }

    void UpdateSaveMenu()
    {
        if (SaveSystem.instance.HasASave(saveNumber))
        {
            hasSave.SetActive(true);
            SaveSystem.instance.LoadFile(saveNumber);
            coinCounter.text = SaveSystem.instance.data.playerInfo.score.ToString();
            noSave.SetActive(false);
        }
        else
        {
            hasSave.SetActive(false);
            noSave.SetActive(true);
        }
    }
}
