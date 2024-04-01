using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInput : MonoBehaviour
{
    private const string Restart = "Restart";
    private const string Pause = "Pause";

    [SerializeField] private GameObject _pauseCanvas;
    private GameObject _currentPauseCanvas;
    private bool _isPaused = false;

    private void Update()
    {
        RestartLevel();
        PauseInput();
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        Destroy(_currentPauseCanvas);
        _isPaused = false;
    }

    public void ContinueGameForButton()
    {
        MenuInput menuInput = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MenuInput>();
        menuInput.ContinueGame();
    }

    private void RestartLevel()
    {
        if(Input.GetButtonDown(Restart)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void PauseInput()
    {
        if(Input.GetButtonDown(Pause))
        {
            PauseOrContineuGame();
        }
    }

    private void PauseOrContineuGame()
    {   
        if (_isPaused)
        {
            ContinueGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        _currentPauseCanvas = Instantiate(_pauseCanvas);
        _isPaused = true;
    }
}
