using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Column : MonoBehaviour
{

    
    private float moveTime = 5f;

    
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveX(8f, moveTime).SetEase(Ease.Linear).SetSpeedBased()
            .OnComplete(() =>
            {
                transform.DOMoveX(0f, moveTime).SetEase(Ease.Linear).SetSpeedBased().SetLoops(-1, LoopType.Yoyo);
            });
    }


}
