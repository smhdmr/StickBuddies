using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
   // [SerializeField] GameObject visibleOnGameCanvas;
   // [SerializeField] GameObject notVisibleOnGameCanvas;


    public void OnPauseButtonClick()
    {
        //visibleOnGameCanvas.SetActive(false);
        //notVisibleOnGameCanvas.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnResumeButtonClick()
    {
        //visibleOnGameCanvas.SetActive(true);
        //notVisibleOnGameCanvas.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnRestartButtonClick()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;

    }


}