using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseAndGameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_lifeBar;
    [SerializeField] private GameObject m_habilities;
    [SerializeField] private GameObject m_score;
    [SerializeField] private GameObject m_PauseMenu;
    [SerializeField] private GameObject m_GameOverMenu;

    private PlayerLife m_playerLife;
    private void Start()
    {
        m_playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        m_playerLife.m_OnPlayerDeath += GameOver;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
 
    }
    public void PauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        m_lifeBar.SetActive(false);
        m_habilities.SetActive(false);
        m_score.SetActive(false);
        m_PauseMenu.SetActive(true);
        m_GameOverMenu.SetActive(false);

    }

    public void ResumeGame()
    {
       
        Time.timeScale = 1f;
        m_lifeBar.SetActive(true);
        m_habilities.SetActive(true);
        m_score.SetActive(true);
        m_PauseMenu.SetActive(false);
        m_GameOverMenu.SetActive(false);
    }

    public void RestartGame()
    {
       
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToInitialMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGameInGameOverMenu()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void GameOver(object sender, EventArgs e)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        m_lifeBar.SetActive(false);
        m_habilities.SetActive(false);
        m_score.SetActive(false);
        m_PauseMenu.SetActive(false);
        m_GameOverMenu.SetActive(true);
    }

}
