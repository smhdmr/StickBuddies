using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //INSTANCE
    public static Player Instance;

    //PLAYER RIGIDBODY
    private Rigidbody rb;

    //JUMP POWER VARIABLE
    private float jumpPower = 4f;

    //JUMP POWER - STICK COUNT RATIO
    private float jumpPowerRatio = 4f;

    //DIRECTION VALUE
    private float direction = 0f;

    //PLAYER SPEED
    private float playerSpeed = 12f;

    //GAME STATUS
    public bool isGameStarted = false;
    public bool isGrounded = false;

    //POSITION VALUES
    private float startPosx, actualPosx, startPosy, actualPosy;
    private float posValue = 35f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
//        transform.position = Vector3.MoveTowards(transform.position,GameMaker.Instance.players[0].transform.position,Player.Instance.playerSpeed);
       // Debug.Log(GameMaker.Instance.players[0]); 

       /* if (GameMaker.Instance.collectedStickCount != 0)
        {

            jumpPower = Random.Range((GameMaker.Instance.collectedStickCount * jumpPowerRatio) - 1, (GameMaker.Instance.collectedStickCount * jumpPowerRatio) + 1);

        }
        else
        {

            jumpPower = Random.Range(jumpPowerRatio - 1, jumpPowerRatio + 1);
        }

        if (Input.GetMouseButton(0))
        {

            isGameStarted = true;
            actualPosx = Input.mousePosition.x;
            actualPosy = Input.mousePosition.y;
            transform.Translate(direction * Time.deltaTime, 0, 0);

        }



        if (Input.GetMouseButtonDown(0))
        {
            startPosx = Input.mousePosition.x;
            startPosy = Input.mousePosition.y;

        }


        if (Input.GetMouseButtonUp(0))
        {
            if (isGrounded)
            {

                rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
                isGrounded = false;
                //GameMaker.Instance.ResetCollectedStickCount();

            }

            playerSpeed = 12;
            startPosy = 0;
            actualPosy = 0;

        }

        //Set players speeed
       if (Mathf.Abs(actualPosy - startPosy) > 100 && Mathf.Abs(actualPosy - startPosy) < 250)
        {
            playerSpeed = 12 + (actualPosy - startPosy) / 80;

        }

        //Set player direction
        direction = (actualPosx - startPosx) / posValue;

        if (direction < -8)
        {
            direction = -8;
        }

        else if (direction > 8)
        {
            direction = 8;
        }

        if (isGameStarted)
        {
          
            transform.position += Vector3.forward * playerSpeed * Time.deltaTime;
          
        }*/



    }






}


