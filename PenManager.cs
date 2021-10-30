using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenManager : MonoBehaviour
{
    /*
     * this manager determines the behavior of the AR pen and uses the two public methods to 
     * set the onClick() method for the buttons
     */
    public static bool surfaceDraw = false;

    public void DrawOnSurface()
    {
        surfaceDraw = true;
    }

    public void DrawInSpace()
    {
        surfaceDraw = false;
    }
}
