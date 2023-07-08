using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Animator settingsMenuAnimator;
    [SerializeField] private float closeDelay;
    
    public const string Volume = "Volume";

    private void Start()
    {
        settingsPanel.SetActive(false);
    }

    public void OpenSettingsMenu()
    {
        if (settingsPanel.activeSelf) return;
        settingsPanel.SetActive(true);
        settingsMenuAnimator.SetTrigger("Open");
    }

    public void CloseSettingsMenu()
    {
        settingsMenuAnimator.SetTrigger("Close");
        Invoke(nameof(CloseSettingsMenuAfterAnimation), closeDelay);;
    }
    
    public void CloseSettingsMenuAfterAnimation()
    {
        settingsPanel.SetActive(false);
    }

    public void OnVolumeChange(float value)
    {
        print($"volume: {value}");
        PlayerPrefs.SetFloat(Volume, value);
        AudioListener.volume = value;
    }
    
}
