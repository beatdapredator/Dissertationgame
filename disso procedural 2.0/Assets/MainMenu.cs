using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("scenes/Main Menu");
    }
    public void ProceduralGame()
    {
        SceneManager.LoadScene("scenes/Procedural");
    }

    public void HandMadeGame()
    {
        SceneManager.LoadScene("scenes/HandMade");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
