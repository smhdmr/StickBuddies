using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
    public float playerSpeed = 12f;

    //GAME STATUS
    public bool isGameStarted = false;
    public bool isGrounded = false;
    public bool isDead = false;
    public bool isJumping = false;
    public bool isStickJumping = false;
    public bool isStartJumping = false;
    public bool isPlayerFinish = false;


    //POSITION VALUES
    private float startPosx, actualPosx, startPosy, actualPosy;
    private float posValue = 35f;
    public float startYposition;
    Vector3 poleStartScale;
    

    //SET ANİMATOR
    public Animator animator;
    AnimatorClipInfo[] animationClip;

    //IS FIRST LOOP CYCLE
    public bool isFirstTime = true;

    //SETS GAMEOBJECTS
    public GameObject Pole;
    public Light Halo;


    void Awake(){

        //SET INSTANCE
        Instance = this;
        
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        startYposition = gameObject.transform.position.y;
        poleStartScale = Pole.transform.localScale;
        
    }


    void Update()
    {
        //Sets Players Speed

        if (Mathf.Abs(actualPosy - startPosy) > 100 && Mathf.Abs(actualPosy - startPosy) < 250)
        {
            playerSpeed = 12 + (actualPosy - startPosy) / 60;

        }

        if (isGameStarted && !isDead && !isPlayerFinish && !isStickJumping)
        {
            transform.position += Vector3.forward * playerSpeed * Time.deltaTime;

        }



        //Sets Players Direction

        if (Input.GetMouseButtonDown(0))
        {
            startPosx = Input.mousePosition.x;
            startPosy = Input.mousePosition.y;

        }

        direction = (actualPosx - startPosx) / posValue;

        if (direction < -8f)
        {
            direction = -8;
        }

        else if (direction > 8f)
        {
            direction = 8;
        }

        if (Input.GetMouseButton(0))
        {

            isGameStarted = true;
            actualPosx = Input.mousePosition.x;
            actualPosy = Input.mousePosition.y;


            if (GameMaker.Instance.isTouchWallLeft == false && direction < 0 && !isDead && isPlayerFinish == false)
            {
                transform.Translate(direction * 1.4f * Time.deltaTime, 0, 0);
            }

            if (GameMaker.Instance.isTouchWallRight == false && direction > 0 && !isDead && isPlayerFinish == false)
            {
                transform.Translate(direction * 1.4f * Time.deltaTime, 0, 0);
            }

        }

        //Sets Jump Power

        if (GameMaker.Instance.collectedStickCount != 0)
        {

            jumpPower = Random.Range((GameMaker.Instance.collectedStickCount * jumpPowerRatio) - 1, (GameMaker.Instance.collectedStickCount * jumpPowerRatio) + 1);
        }
        else
        {

            jumpPower = Random.Range(jumpPowerRatio - 1f, jumpPowerRatio + 1f);
        }

        //Sets Jump Animations

        if (isGameStarted && isGrounded && !isStartJumping)
        {
            animator.SetBool("isBigJumping", false);
            isJumping = false;
        }
        if (isGameStarted && isGrounded && isJumping)
        {
            animator.SetBool("isJumping", false);
            isJumping = false;
        }

        //Sets Players Jumping

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(WaitForIsjumping());

            if (isGrounded && !isDead && !isPlayerFinish)
            {

                isStartJumping = true;

                if (jumpPower < 6)
                {
                    animator.SetBool("isJumping", true);
                    isJumping = true;
                    rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
                }
                else
                {
                  
                    animator.SetBool("isBigJumping", true);
                    isStickJumping = true;
                    isJumping = true;
            
                }

                isGrounded = false;
            }

            playerSpeed = 12;
            startPosy = 0;
            actualPosy = 0;
        }

        //Sets Pole Scale

        Pole.transform.localScale = Vector3.Slerp(Pole.transform.localScale, new Vector3(poleStartScale.x, poleStartScale.y * (GameMaker.Instance.collectedStickCount + 1)/2, poleStartScale.z), Time.deltaTime * 6);

        //Sets Running Animation

      
        if (isGameStarted && isGrounded && !isStickJumping)
        {
            animator.SetBool("isRunning", true);
        }

        if (isJumping || isStickJumping || !isGrounded )
        {
            animator.SetBool("isRunning", false);
        }

        //Check Is Player Dead

        if (isDead)
        {
            rb.isKinematic = true;
        }

        //Sets Falling Animation

        if (gameObject.transform.position.y < startYposition-1)
        {
            animator.SetBool("isFalling", true);
            StartCoroutine(WaitForDie());
        }

        if (isGameStarted && isFirstTime)
        {
            GameMaker.Instance.HideUI();
            isFirstTime = false;
        }

    }


    public void KillPlayer()
    {
        animator.SetBool("isDead", true);
        isDead = true;
        GameMaker.Instance.players.Remove(this.gameObject);

        StartCoroutine(WaitForDie());
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            KillPlayer();

        }
        if (collision.gameObject.tag == "wallL")
        {
          //  StartCoroutine(WaitFor(0));
            GameMaker.Instance.isTouchWallLeft = true;
        }
        if (collision.gameObject.tag == "wallR")
        {
          //  StartCoroutine(WaitFor(1));
            GameMaker.Instance.isTouchWallRight = true;
        }
        if (collision.gameObject.tag == "Finish")
        {
            StartCoroutine(WaitFor(0, 0.7f));
       
        }
       /* if (collision.gameObject.tag == "zemin")
        {
            animator.SetBool("isJumping", false);
        }*/
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "zemin")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "zemin")
        {
            isGrounded = false;
        }

        if (collision.gameObject.tag == "wallL")
        {
            GameMaker.Instance.isTouchWallLeft = false;
        }

        if (collision.gameObject.tag == "wallR")
        {
            GameMaker.Instance.isTouchWallRight = false;
        }
    }

    IEnumerator WaitFor(int i,float sec)
    {
        yield return new WaitForSeconds(sec);

        if (i == 0)
        {
            isPlayerFinish = true;
            animator.SetBool("isFinish", true);
        }

        if (i == 2)
        {
            if (isGrounded && !isDead && !isPlayerFinish)
            {
                if(jumpPower > 6)
                {
                    rb.AddForce(new Vector3(0, jumpPower, 6), ForceMode.Impulse);
                    isStartJumping = false;
                    isStickJumping = false;
                }
                else
                {

                }
            }
        }
    }
    IEnumerator WaitForDie()
    {
        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }

    IEnumerator WaitForIsjumping()
    {
        yield return new WaitForSeconds(0.2f);

        isJumping = true;

        StartCoroutine(WaitFor(2, 0.7f)); 
    }
}
