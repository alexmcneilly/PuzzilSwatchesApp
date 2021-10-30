using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stroke : MonoBehaviour
{

    private Transform penPoint;
    public Color strokeColor;

    //stroke will track with the transform of our pen point which will allow us to see it. 

    // Start is called before the first frame update
    void Start()
    {
        penPoint = GameObject.FindObjectOfType<Draw>().penPoint;
    }

    // Update is called once per frame
    void Update()
    {

        penPoint = GameObject.FindObjectOfType<Draw>().penPoint;
        GetComponent<Renderer>().material.color = strokeColor;

        if (Draw.drawing)
        {
            //transform of the stroke tracks the transform of the pen point sphere.
            this.transform.position = penPoint.transform.position;
            this.transform.rotation = penPoint.transform.rotation;
        } else
        {
            //disable stroke when we cease drawing
            this.enabled = false;
        }
    }
}
