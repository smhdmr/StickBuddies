using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), 5, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        GameMaker.Instance.CollectCoin();
    }

}
