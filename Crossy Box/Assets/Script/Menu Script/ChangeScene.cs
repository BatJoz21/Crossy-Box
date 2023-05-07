using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private GameObject optionMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void Option()
    {
        optionMenu.SetActive(true);
    }

    public void ExitOption()
    {
        optionMenu.SetActive(false);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
