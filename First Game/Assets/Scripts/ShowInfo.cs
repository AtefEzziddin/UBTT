using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour
{   
    public string textValue;
    public Text textElement;

    // Start is called before the first frame update
    void Start()
    {   
        textElement.text = textValue;
    }

    // Update is called once per frame
    void Update()
    {
        textElement.text = transform.position.ToString();
    }
}
