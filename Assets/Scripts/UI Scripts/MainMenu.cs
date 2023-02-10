using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string newGameScene;
    [SerializeField] AudioClip inGameMusic;

    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameScene);
        AudioManager.instance.PlayMusic(1);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
