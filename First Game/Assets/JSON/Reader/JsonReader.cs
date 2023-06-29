using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class JsonReader : MonoBehaviour
{
    //correct the position of the torso in refrence to the head position
    [SerializeField] float yAxisCorrection = 1.56281f;
    [SerializeField] int delay = 0;
    
    //here the json file will be dragged/added to the script of the avatar in unity.
    public TextAsset JsonBodyPos;
    public TextAsset JsonBodyRot;
    

    //class to represent the data of the json file
    [System.Serializable]
    public class Position
    {
        public float x;
        public float y;
        public float z;
    }

    //class to represent the data of the json file
    [System.Serializable]
    public class Rotation
    {
        public float x;
        public float y;
        public float z;
        public float w;
    }

    //classes to store a list of Positions/Rotations
    [System.Serializable]
    public class PositionList
    {
        public Position[] botPos;
    }

    [System.Serializable]
    public class RotationList
    {
        public Rotation[] botRot;
    }

    public PositionList botBodyPosLst = new PositionList();
    public RotationList botBodyRotLst = new RotationList();

    // Start is called before the first frame update
    void Start()
    {
        botBodyPosLst = JsonUtility.FromJson<PositionList>(JsonBodyPos.text);
        botBodyRotLst = JsonUtility.FromJson<RotationList>(JsonBodyRot.text);
    }

    // Update is called once per frame
    int i = 0;
    void Update()
    {
        
        if (i< botBodyPosLst.botPos.Length)
        {   
            transform.position = new Vector3(botBodyPosLst.botPos[i].x, botBodyPosLst.botPos[i].y+yAxisCorrection, botBodyPosLst.botPos[i].z);
            transform.rotation = new Quaternion(botBodyRotLst.botRot[i].x, botBodyRotLst.botRot[i].y, botBodyRotLst.botRot[i].z, botBodyRotLst.botRot[i].w);
            i++;
            //delaying the visulization by x ms to better recognize the movement
            Thread.Sleep(delay);
        }
            
    }
}
