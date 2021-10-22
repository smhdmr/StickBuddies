using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stick : MonoBehaviour
{    

    //STICK MOVEMENT SEQUENCE
    Sequence stickMovement;
    
    //COLLECT EFFECT
  

    private void OnTriggerEnter(Collider other)
    {
       // Player.Instance.Halo.range = Mathf.Lerp(0, 3.2f, Time.deltaTime * 0.1f);
      //  StartCoroutine(WaitFor());
        stickMovement.Kill();
        GameMaker.Instance.CollectStick();
        Destroy(this.gameObject);
    }

    void Start()
    {
        //STICK ROTATE MOVEMENT
        transform.DORotate(new Vector3(0, 360, 0), 5f, RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear); 
    }

    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(1);
        Player.Instance.Halo.range = Mathf.Lerp(3.2f, 0f, Time.deltaTime * 2);
    }
}
