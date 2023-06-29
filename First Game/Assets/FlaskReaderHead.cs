using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading;

public class FlaskReaderHead : MonoBehaviour
{  
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

    //class to store a list of recieved data
    [System.Serializable]
    public class PosRotList
    {
        public Position[] botPos;
        public Rotation[] botRot;
    }

    //variable to make update wait until we recieve the info from flask
    public int recieved = 0;

    //keep checking if playerId from FlaskReader recieved
    int loopContinue = 1;

    //for looping inside of update
    int i = 0;

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
            Debug.Log("Received Head");
            botPosRotList = JsonUtility.FromJson<PosRotList>(uwr.downloadHandler.text);
            recieved = 1;
        }
    }

    //to store instance of FlaskReader
    FlaskReader bodyInstance;
    
    void Start()
    {
        FlaskReader body = FindObjectOfType<FlaskReader>();
        bodyInstance = body;        
    }

    void Update()
    {
        if(loopContinue == 1)
        {
            if(bodyInstance.recievedId == 1)
            {
                loopContinue = 0;
                string url = "http://127.0.0.1:5000/head?playerId=" + bodyInstance.playersList.players[0];
                StartCoroutine(GetRequest(url));
            }
        }
        if (recieved == 1 && bodyInstance.goAll == 1)
        {
            if (i< botPosRotList.botPos.Length)
                {   
                    transform.position = new Vector3(botPosRotList.botPos[i].x, botPosRotList.botPos[i].y, botPosRotList.botPos[i].z);
                    transform.rotation = new Quaternion(botPosRotList.botRot[i].x, botPosRotList.botRot[i].y, botPosRotList.botRot[i].z, botPosRotList.botRot[i].w);
                    i++;
                    //delaying the visulization by delay ms to better recognize the movement
                    Thread.Sleep(bodyInstance.delay);
                }
        }
        
    }
}
