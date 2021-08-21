using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    public AudioMixerGroup _audioMixer;

    //private void Awake()
    //{
    //    GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt("EnableAudio", 1) == 1;
    //    GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt("EnableMusic", 1) == 1;
    //    GetComponentInChildren<Slider>().value = PlayerPrefs.GetFloat("AudioValume", 1);
    //}
   
    public void Open()
    {
        _shop.SetActive(true);
        Time.timeScale = 0;
    }

    public void Close()
    {
        _shop.SetActive(false);
        Time.timeScale = 1;
    }

    public void ToggleOpen()
    {
        if (_shop.activeSelf)
            Close();
        else
            Open();
    }

    public void ToggleAudio(bool enable)
    {
        if (enable)
        {
            _audioMixer.audioMixer.SetFloat("Valume", 0);
        }
        else
        {
            _audioMixer.audioMixer.SetFloat("Valume", -80);
        }

        //PlayerPrefs.SetInt("EnableAudio", enable ? 1 : 0);
    }

    public void ToggleMusic(bool enable)
    {
        if (enable)
        {
            _audioMixer.audioMixer.SetFloat("Music", 0);
        }
        else
        {
            _audioMixer.audioMixer.SetFloat("Music", -80);
        }

        //PlayerPrefs.SetInt("EnableMusic", enable ? 1 : 0);
    }

    public void ChangeVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat("Valume", Mathf.Lerp(-80, 0, volume));

        //PlayerPrefs.SetFloat("AudioValume", volume);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
