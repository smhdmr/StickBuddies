using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;


public class GameMaker : MonoBehaviour
{
    public GameObject sceneTag;

    //INSTANCE
    public static GameMaker Instance;    

    //UI TEXT AREAS 
    public TextMeshProUGUI stickText, coinText;

    //HIDE WHEN GAME STARTS
    public GameObject HidingPanel;    

    //POINTS
    public int collectedStickCount = 0;
    public int coinCount = 0;

    //PLAYER LİST 
    public List<GameObject> players = new List<GameObject>();
    public List<Transform> spawns = new List<Transform>();
    public Transform Player1Pos;

    public GameObject PlayerPrefab;
    Quaternion rotation = new Quaternion(0,0,0,1);

    //SPAWNS
    public Transform Spawn1;
    public Transform Spawn2;
    public Transform Spawn3;
    public Transform Spawn4;
    public Transform Spawn5;
    public Transform Spawn6;
    public Transform Spawn7;
    public Transform Spawn8;

    int PlayersCount = 3;

    //İS PLAYER TOUCHING WALL
    public bool isTouchWallLeft = false;
    public bool isTouchWallRight = false;
    public bool isFinished = false;
    public bool Win = false;


    void Awake(){

        //SET INSTANCE
        Instance = this;

    }


    // Start is called before the first frame update
    void Start()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;        

        if(sceneTag.tag == "Bonus")
        {
            PlayersCount = 1;
        }

        PlayerPrefs.SetInt("level", 0);

        spawns.Add(Spawn1);
        spawns.Add(Spawn2);
        spawns.Add(Spawn3);
        spawns.Add(Spawn4);
        spawns.Add(Spawn5);
        spawns.Add(Spawn6);
        spawns.Add(Spawn7);
        spawns.Add(Spawn8);


        for(int i = 0; i < PlayersCount; i++)
        {
            players.Add(Instantiate(PlayerPrefab, spawns[i].transform.position, rotation) as GameObject);
        }        

        CameraMovement.Instance.CurrentPlayers = players;
        
        //SET FIRST STICK TEXT
        stickText.text = "0";



               
    }


    // Update is called once per frame
    void Update()
    {
        //Finish the game if no players have left
        if (players.Count == 0)
        {
            StartCoroutine("RestartGameInSec", 1f);
        }

        //Resets the sticks after jumping
        if (Input.GetMouseButtonUp(0) )
        {
            StartCoroutine("WaitForJump");
        }
        if (players[0].GetComponent<Player>().isPlayerFinish)
        {
            isFinished = true;
            StartCoroutine(NextLevel());
        }
    }


    //RESETS COLLECTED STICK COUNT
    public void ResetCollectedStickCount(){
        
        collectedStickCount = 0;
        stickText.text = "0";

    }


    //COLLECTS A STICK
    public void CollectStick() {

        //INCREASE THE VALUE and CHANGE THE TEXT
        collectedStickCount++;
        stickText.text = collectedStickCount.ToString();
        UIManager.Instance.CloseTutorialPopUp(UIManager.TutorialType.Stick);
        //SoundManager.Instance.PlaySoundEffect(SoundManager.SoundType.CoinSound);
    }

    public void CollectCoin(){

        //INCREASE THE VALUE and CHANGE THE TEXT
        coinCount++;        
        coinText.text =  coinCount.ToString();
        //SoundManager.Instance.PlaySound(SoundManager.Instance.SoundName[SoundManager.SoundType.CoinSound]);
        //SoundManager.Instance.PlaySoundEffect(SoundManager.SoundType.CoinSound);
    }

    public void HideUI(){

        HidingPanel.SetActive(false);
    }

    public void ShowUI(){

        HidingPanel.SetActive(true);

    }


    public void RestartGame(){

        DOTween.KillAll();
        SceneManager.LoadScene(1);

    }


    //RESTARTS GAME IN GIVEN SECONDS
    public IEnumerator RestartGameInSec(int sec){

        Win = false;
        
        yield return new WaitForSeconds(sec);
        DOTween.KillAll();
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        

    }

    public IEnumerator NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        Win = true;        

        yield return new WaitForSeconds(3);

        if(currentScene == 4)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentScene + 1);
        }

    }

    public IEnumerator WaitForJump()
    {
        yield return new WaitForSeconds(2f);
        ResetCollectedStickCount();
    }
    
    
    public IEnumerator CheckForMovement()
    {
        while (true)
        {
            Player1Pos = players[0].transform;

            if (Player1Pos.position.x > 1f || Player1Pos.position.x < -1f)
            {
                UIManager.Instance.CloseTutorialPopUp(UIManager.TutorialType.Movement);
                StopCoroutine("CheckForMovement");
            }

            yield return 0.2f;
        }        
        
    }    
    
}
