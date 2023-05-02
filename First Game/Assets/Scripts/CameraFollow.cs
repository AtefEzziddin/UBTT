using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] Quaternion rotation;
    /* [SerializeField] Quaternion rightRotation;
    [SerializeField] Vector3 rightOffset;
    [SerializeField] Quaternion leftRotation;
    [SerializeField] Vector3 leftOffset;
    [SerializeField] Quaternion upRotation;
    [SerializeField] Vector3 upOffset;
    [SerializeField] Quaternion downRotation;
    [SerializeField] Vector3 downOffset; */
    void Start(){
        transform.rotation = rotation;
    }

    /* void Update(){
        if(Input.GetKey("left shift") && Input.GetKey("right")){
            transform.rotation = rightRotation;
            transform.position = target.position + rightOffset;
        }

        if(Input.GetKey("left shift") && Input.GetKey("left")){
            transform.rotation = leftRotation;
            transform.position = target.position + leftOffset;
        }

        if(Input.GetKey("left shift") && Input.GetKey("up")){
            transform.rotation = upRotation;
            transform.position = target.position + upOffset;
        }

        if(Input.GetKey("left shift") && Input.GetKey("down")){
            transform.rotation = downRotation;
            transform.position = target.position + downOffset;
        }
    } */
    void LateUpdate(){
        transform.position = target.position + offset;
    }
    
}
