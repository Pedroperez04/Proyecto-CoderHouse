using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneButtons : MonoBehaviour
{

    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void GoToInitialMenuButton()
    {
        SceneManager.LoadScene(0);
    }



    public void FinalSceneQuitButton()
    {
        Debug.Log("Salio del Juego");
        Application.Quit();
    }
}
