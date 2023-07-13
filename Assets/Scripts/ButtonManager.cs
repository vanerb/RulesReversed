using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
   public void Jugar()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Opciones()
    {
        SceneManager.LoadScene("Opciones");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void HowTo()
    {
        SceneManager.LoadScene("HowTo");
    }
}
