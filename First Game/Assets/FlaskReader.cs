using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading;

public class FlaskReader : MonoBehaviour
{
    [SerializeField] float yAxisCorrection = 1.56281f;
    [SerializeField] public int delay = 10;
    
    //classes to represent the data of the text file
    [System.Serializable]
    public class Position
    {
        public float x;
        public float y;
        public float z;
    }

    [System.Serializable]
    public class Rotation
    {
        public float x;
        public float y;
        public float z;
        public float w;
    }

    //class to store a list of data gathered
    [System.Serializable]
    public class PosRotList
    {
        public Position[] botPos;
        public Rotation[] botRot;
    }

    //class to represent array of players
    [System.Serializable]
    public class PlayersList
    {
        public string[] players;
    }

    //when all data recieved for all parts, will become 1 and allow other parts to run
    public int goAll = 0;

    //variables to make update wait until we recieve the info from flask
    int recieved = 0;
    public int recievedId = 0;

    //will stay checking if playersId has been recieved
    int loopContinue = 1;

    //for looping inside of update
    int i = 0;

    public PlayersList playersList = new PlayersList();
    public PosRotList botPosRotList = new PosRotList();

    //Getting data from flask as an instance of PosRotList class
    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received Body");
            botPosRotList = JsonUtility.FromJson<PosRotList>(uwr.downloadHandler.text);
            recieved = 1;
        }
    }

    //Getting Id from flask
    IEnumerator GetRequestId(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            playersList = JsonUtility.FromJson<PlayersList>(uwr.downloadHandler.text);
            Debug.Log("Received Id: " + playersList.players[0]);
            recievedId = 1;
        }
    }
    
    //To save instances of the other parts
    FlaskReaderHead headInstance;
    FlaskReaderRHand rHandInstance;
    FlaskReaderLHand lHandInstance;


    void Start()
    {
        StartCoroutine(GetRequestId("http://127.0.0.1:5000/selectPlayers?"));
        
        FlaskReaderHead head = FindObjectOfType<FlaskReaderHead>();
        headInstance = head;
        FlaskReaderRHand rHand = FindObjectOfType<FlaskReaderRHand>();
        rHandInstance = rHand;
        FlaskReaderLHand lHand = FindObjectOfType<FlaskReaderLHand>(); 
        lHandInstance = lHand; 
    }

    void Update()
    {
        if(loopContinue == 1)
        {
            if(recievedId == 1)
            {
                loopContinue = 0;
                string url = "http://127.0.0.1:5000/body?playerId=" + playersList.players[0];
                StartCoroutine(GetRequest(url));
            }
        }
        if(headInstance.recieved == 1 && rHandInstance.recieved == 1 && lHandInstance.recieved==1 && recieved == 1)
        {
            goAll = 1;
        }
        if (goAll == 1)
        {
            if (i< botPosRotList.botPos.Length)
                {   
                    transform.position = new Vector3(botPosRotList.botPos[i].x, botPosRotList.botPos[i].y+yAxisCorrection, botPosRotList.botPos[i].z);
                    transform.rotation = new Quaternion(botPosRotList.botRot[i].x, botPosRotList.botRot[i].y, botPosRotList.botRot[i].z, botPosRotList.botRot[i].w);
                    i++;
                    //delaying the visulization by delay ms to better recognize the movement
                    Thread.Sleep(delay);
                }
        }
        
    }
}
