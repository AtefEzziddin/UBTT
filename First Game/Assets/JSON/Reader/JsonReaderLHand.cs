using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class JsonReaderLHand : MonoBehaviour
{
    [SerializeField] int delay = 0;
    public TextAsset JsonLHandPos;
    public TextAsset JsonLHandRot;
    

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

    public PositionList botLHandPosLst = new PositionList();
    public RotationList botLHandRotLst = new RotationList();

    // Start is called before the first frame update
    void Start()
    {
        botLHandPosLst = JsonUtility.FromJson<PositionList>(JsonLHandPos.text);
        botLHandRotLst = JsonUtility.FromJson<RotationList>(JsonLHandRot.text);
    }

    // Update is called once per frame
    int i = 0;
    void Update()
    {
        
        if (i< botLHandPosLst.botPos.Length)
        {   
            transform.position = new Vector3(botLHandPosLst.botPos[i].x, botLHandPosLst.botPos[i].y, botLHandPosLst.botPos[i].z);
            transform.rotation = new Quaternion(botLHandRotLst.botRot[i].x, botLHandRotLst.botRot[i].y, botLHandRotLst.botRot[i].z, botLHandRotLst.botRot[i].w);
            i++;
            Thread.Sleep(delay);
        }
            
    }
}
