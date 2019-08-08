using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchLocation
{
    public int touchId;
    public Vector2 beginTouch, endTouch;

    public touchLocation(int newTouchId, Vector2 beginTouch)
    {
        touchId = newTouchId;
        this.beginTouch = beginTouch;
    }
}