using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    [SerializeField] private Player _player;    

    public AudioMixerGroup AudioMixer;

    private void Start()
    {         
        GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt("Music", 1) == 1;
        GetComponentInChildren<Slider>().value = PlayerPrefs.GetFloat("Valume", 1);
        _shop.SetActive(false);
    }
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
    public void ToggleMusic(bool enable)
    {
        if (enable)
        {
            AudioMixer.audioMixer.SetFloat("Music", 0);
        }
        else
        {
            AudioMixer.audioMixer.SetFloat("Music", -80);
        }
        PlayerPrefs.SetInt("Music", enable ? 1 : 0);
    }
    public void ChangeVolume(float volume)
    {
        AudioMixer.audioMixer.SetFloat("Valume", Mathf.Lerp(-80, 0, volume));

        PlayerPrefs.SetFloat("Valume", volume);
    }
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("Valume");
        PlayerPrefs.DeleteKey("Music");
        _player.ResetSavePlayer();
        //equipment.ResetSaveEquipment();
    }
    public void Exit()
    {
        Application.Quit();
    }

}
