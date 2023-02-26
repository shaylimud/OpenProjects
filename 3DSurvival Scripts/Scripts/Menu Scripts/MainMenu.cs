using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{   
    //Buttons//
    public Button startBtn;
    public Button settingsBtn;
    public Button instructionBtn;
    public Button exitBtn;
    public Button settingBackBtn;
    public Button instructionBackButton;
    //Screens//
    public GameObject mainMenuScreen;
    public GameObject settingsScreen;
    public GameObject instructionScreen;
    //Audios//
    public AudioMixer maimMixer;
    public AudioSource camAudioSrc;
    public AudioClip buttonClick;

    



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        startBtn.onClick.AddListener(StartBtn);
        settingsBtn.onClick.AddListener(SettingsBtn);
        instructionBtn.onClick.AddListener(InstructionBtn);
        exitBtn.onClick.AddListener(ExitBtn);
        settingBackBtn.onClick.AddListener(BackBtn);
        instructionBackButton.onClick.AddListener(BackBtn);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartBtn()
    {
        camAudioSrc.PlayOneShot(buttonClick);
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("TestingScene");
        /*SceneManager.LoadScene(SceneManager.GetSceneByName("TestingScene").buildIndex);*/
    }
    void SettingsBtn()
    {
        camAudioSrc.PlayOneShot(buttonClick);
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(true);
        instructionScreen.SetActive(false);
    }
    void InstructionBtn()
    {
        camAudioSrc.PlayOneShot(buttonClick);
        mainMenuScreen.SetActive(false);
        instructionScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
    void ExitBtn()
    {
        camAudioSrc.PlayOneShot(buttonClick);
        Application.Quit();
    }
    void BackBtn()
    {
        camAudioSrc.PlayOneShot(buttonClick);
        mainMenuScreen.SetActive(true);
        settingsScreen.SetActive(false);
        instructionScreen.SetActive(false);
        ;
    }
    public void AudioMixer(float volume)
    {
        maimMixer.SetFloat("Volume", volume);
    }
    
}
