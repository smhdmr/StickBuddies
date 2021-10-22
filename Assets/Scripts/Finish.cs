using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Finish")
        {
            DOTween.KillAll();
            //SoundManager.Instance.SetGameMusic(false);
            //SoundManager.Instance.PlaySoundEffect(SoundManager.SoundType.LevelFinishSound);   
            
            Scene currentScene = SceneManager.GetActiveScene();                      

            if(currentScene.buildIndex == 0)
            {
                SceneManager.LoadScene(1);

            }
            else
            {
                SceneManager.LoadScene(0);

            }
        }
    }
}
