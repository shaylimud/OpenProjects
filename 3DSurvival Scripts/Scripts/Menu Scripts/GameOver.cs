using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Button restartBtn;
    public Button exitBtn;
    public Button mainMenu;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        restartBtn.onClick.AddListener(RestartBtn);
        mainMenu.onClick.AddListener(MainMenu);
        exitBtn.onClick.AddListener(ExitBtn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartBtn()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("TestingScene");
      

    }
    void MainMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("MainMenu");
    }
    void ExitBtn()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Application.Quit();     
    }
}
