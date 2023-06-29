using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class JsonReaderHead : MonoBehaviour
{
    [SerializeField] int delay = 0;
    public TextAsset JsonHeadPos;
    public TextAsset JsonHeadRot;

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

    public PositionList botHeadPosLst = new PositionList();
    public RotationList botHeadRotLst = new RotationList();

    // Start is called before the first frame update
    void Start()
    {
        botHeadPosLst = JsonUtility.FromJson<PositionList>(JsonHeadPos.text);
        botHeadRotLst = JsonUtility.FromJson<RotationList>(JsonHeadRot.text);
    }

    // Update is called once per frame
    int i = 0;
    void Update()
    {
        
        if (i< botHeadPosLst.botPos.Length)
        {   
            transform.position = new Vector3(botHeadPosLst.botPos[i].x, botHeadPosLst.botPos[i].y, botHeadPosLst.botPos[i].z);
            transform.rotation = new Quaternion(botHeadRotLst.botRot[i].x, botHeadRotLst.botRot[i].y, botHeadRotLst.botRot[i].z, botHeadRotLst.botRot[i].w);
            i++;
            Thread.Sleep(delay);
        }
            
    }
}
