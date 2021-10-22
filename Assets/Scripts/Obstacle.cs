using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Obstacle : MonoBehaviour
{
    public ObstacleType obstacleType;
    
    [Range(0, 20)]public float obstacleValue;
    

    //OBSTACLE TYPES
    public enum ObstacleType
    {
        RotarySaw,
        Guillotine,
        PunchMachine,
        Hammer,
        Fan
    }
    

    //OBSTACLE MOVEMENTS
    void Start()
    {
        //ROTARY SAW
        if (obstacleType == ObstacleType.RotarySaw){        
            transform.DOMoveX(gameObject.transform.position.x + 8.91f, 0.8f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);            
            transform.DORotate(new Vector3(0, 0, transform.rotation.z + 360), obstacleValue, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);        
        }

        //HAMMER
        else if (obstacleType == ObstacleType.Hammer){
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DORotate(new Vector3(0, 0, -70), obstacleValue, RotateMode.Fast).SetEase(Ease.OutBounce))
                .Append(transform.DORotate(new Vector3(0, 0, 0), obstacleValue, RotateMode.Fast).SetEase(Ease.InSine)).SetLoops(-1);
            sequence.Play();          
        }

        //GUILLOTINE
        else if (obstacleType == ObstacleType.Guillotine)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOMoveY(gameObject.transform.position.y-10, 0.1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear))
                .Append(transform.DOMoveY(gameObject.transform.position.y, 1.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear)).SetLoops(-1);
            sequence.Play();
        }

        //PUNCH MACHINE
        else if (obstacleType == ObstacleType.PunchMachine)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOMoveX( gameObject.transform.position.x+5, 0.1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear))
                .Append(transform.DOMoveX(gameObject.transform.position.x, 1.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear)).SetLoops(-1);
            sequence.Play();            
        }
        else if(obstacleType == ObstacleType.Fan)
        {
            transform.DORotate(new Vector3(360, 90, 90), 4, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        }

    }
      

}
