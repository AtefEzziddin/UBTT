using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] Quaternion rotation;
    public Vector2 turn;
    void Start(){
        transform.rotation = rotation;
    }

    void Update()
    {
        transform.position = target.position + offset;

        
        
    } 
    void LateUpdate()
    {
        //transform.position = target.position + offset;
    }
    
}
