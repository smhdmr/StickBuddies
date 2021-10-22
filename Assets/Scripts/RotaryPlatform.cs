using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotaryPlatform : MonoBehaviour
{

    private void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), 2, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

}
