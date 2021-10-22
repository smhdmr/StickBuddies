using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraMovement : MonoBehaviour
{

    public static CameraMovement Instance;
    public List<GameObject> CurrentPlayers = new List<GameObject>();
    public Vector3 CameraFollowPoint;
    public Vector3 CameraFollowOffset = new Vector3(6.04f, -56.43f, 90.84f);
    public CinemachineVirtualCamera vcam;

    public GameObject a;

    void Awake(){

        Instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.position = CalculateFollowPoint();
        if(GameMaker.Instance.players[0] != null)
        {
            vcam.m_Follow = GameMaker.Instance.players[0].transform;

        }
    }

    private Vector3 CalculateFollowPoint(){

        float followX = 0f;
        float followY = 0f;
        float followZ = 0f;

        followY = CurrentPlayers[0].transform.position.y;

        for(int i = 0; i < CurrentPlayers.Count; i++){

            followX = CurrentPlayers[i].transform.position.x;
            followZ = CurrentPlayers[i].transform.position.z;            
        }

        followX /= CurrentPlayers.Count;
        followZ /= CurrentPlayers.Count;
        CameraFollowPoint = new Vector3(followX, followY, followZ); 
        CameraFollowPoint += CameraFollowOffset;       


        return CameraFollowPoint;

    }
}
