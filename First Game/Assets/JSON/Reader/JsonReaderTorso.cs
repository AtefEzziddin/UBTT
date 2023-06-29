using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class JsonReaderTorso : MonoBehaviour
{
    //correct the position of the torso in refrence to the head position
    [SerializeField] float yAxis = 1.56281f;
    [SerializeField] int delay = 10;
    public TextAsset JsonTorsoPos;
    public TextAsset JsonTorsoRot;
    

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

    public PositionList botTorsoPosLst = new PositionList();
    public RotationList botTorsoRotLst = new RotationList();

    // Start is called before the first frame update
    void Start()
    {
        botTorsoPosLst = JsonUtility.FromJson<PositionList>(JsonTorsoPos.text);
        botTorsoRotLst = JsonUtility.FromJson<RotationList>(JsonTorsoRot.text);
    }

    // Update is called once per frame
    int i = 0;
    void Update()
    {
        
        if (i< botTorsoPosLst.botPos.Length)
        {   
            transform.position = new Vector3(botTorsoPosLst.botPos[i].x, botTorsoPosLst.botPos[i].y+yAxis, botTorsoPosLst.botPos[i].z);
            transform.rotation = new Quaternion(botTorsoRotLst.botRot[i].x, botTorsoRotLst.botRot[i].y, botTorsoRotLst.botRot[i].z, botTorsoRotLst.botRot[i].w);
            i++;
            Thread.Sleep(delay);
        }
            
    }
}
