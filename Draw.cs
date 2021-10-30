using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviour
{
    // Start is called before the first frame update

    //this determines whether we are testing in the Editor. Set false when game exported
    public bool mouseLookTesting;
    public GameObject spacePenPoint;
    public GameObject surfacePenPoint;
    public GameObject stroke;
    public Slider[] colorSliders;

    [HideInInspector]
    public Transform penPoint;

    //determines if player is attempting to create a paint stroke
    public static bool drawing = false;





    //up and down rotation
    private float pitch = 0;

    //left and right rotation
    private float yaw = 0;


    private Color sliderColor;
    
    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderColor = new Color(colorSliders[0].value * 5, colorSliders[1].value * 5, colorSliders[2].value * 5);

        if(mouseLookTesting)
        {
            yaw += 2 * Input.GetAxis("Mouse X");
            pitch += 2 * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        }

        if(PenManager.surfaceDraw)
        {
            penPoint = surfacePenPoint.transform;

            spacePenPoint.GetComponent<MeshRenderer>().enabled = false;
            surfacePenPoint.GetComponent<MeshRenderer>().enabled = true;
            surfacePenPoint.GetComponentInChildren<Renderer>().material.color = sliderColor;
        } else
        {
            penPoint = spacePenPoint.transform;

            spacePenPoint.GetComponent<MeshRenderer>().enabled = true;
            surfacePenPoint.GetComponent<MeshRenderer>().enabled = false;
            spacePenPoint.GetComponentInChildren<Renderer>().material.color = sliderColor;
        }

    }

    public void StartStroke()
    {
        GameObject currentStroke;
        //sets drawing to true
        drawing = true;
        //instantiates the Stroke prefab at the position of the pen point
        currentStroke = Instantiate(stroke, spacePenPoint.transform.position, spacePenPoint.transform.rotation) as GameObject;
        currentStroke.GetComponent<Stroke>().strokeColor = sliderColor;
    }

    public void EndStroke()
    {
        drawing = false;
    }
}
