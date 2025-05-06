using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMenu : MonoBehaviour
{
    [SerializeField] private float mVolume;

    [SerializeField] private Slider mSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            mVolume = PlayerPrefs.GetFloat("Volume");
            mSlider.value = mVolume;
        }
    }


    public void ChangeVolume(float newVolume)
    {
        mVolume = newVolume;
        PlayerPrefs.SetFloat("Volume", mVolume);
    }
}
