using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHandler : MonoBehaviour
{

    public HitObjectType hitObjectType;


    //HIT AREA TYPES
    public enum HitObjectType{

        FinishPoint,

        DiePoint

    }
    
        
    //IF PLAYER HITS AN OBSTACLE, KILL THE PLAYER
   /* void OnCollisionEnter(Collision collision){       
        
        
        if(collision.gameObject.tag == "Player"){

                switch(hitObjectType){  

                    case HitObjectType.FinishPoint:
                        Time.timeScale = 0;
                        GameMaker.Instance.StartCoroutine("RestartGameInSec", 1.5f);
                        break;

                    case HitObjectType.DiePoint:
                        Player.Instance.KillPlayer();
                        break;

            }

        }

    }*/

}
