using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using static JsonReader;

public class JsonReaderRHand : MonoBehaviour
{
    [SerializeField] int delay = 0;
    public TextAsset JsonRHandPos;
    public TextAsset JsonRHandRot;
    

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

    public PositionList botRHandPosLst = new PositionList();
    public RotationList botRHandRotLst = new RotationList();

    // Start is called before the first frame update
    void Start()
    {
        botRHandPosLst = JsonUtility.FromJson<PositionList>(JsonRHandPos.text);
        botRHandRotLst = JsonUtility.FromJson<RotationList>(JsonRHandRot.text);
    }

    // Update is called once per frame
    int i = 0;
    void Update()
    {
        
        if (i< botRHandPosLst.botPos.Length)
        {   
            transform.position = new Vector3(botRHandPosLst.botPos[i].x, botRHandPosLst.botPos[i].y, botRHandPosLst.botPos[i].z);
            transform.rotation = new Quaternion(botRHandRotLst.botRot[i].x, botRHandRotLst.botRot[i].y, botRHandRotLst.botRot[i].z, botRHandRotLst.botRot[i].w);
            i++;
            Thread.Sleep(delay);
        }
            
    }
}
