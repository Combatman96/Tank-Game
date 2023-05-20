using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> This class handle player Input for player one and two</summary>
public class InputController : MonoBehaviour
{
    Tank tank => GetComponent<Tank>();
    [HideInInspector] public bool Up;
    [HideInInspector] public bool Down;
    [HideInInspector] public bool Left;
    [HideInInspector] public bool Right;
    [HideInInspector] public bool Fire;

    private void Update()
    {
        if(tank.playerID == 1)
        {
            Up = Input.GetKey(KeyCode.UpArrow);
            Down = Input.GetKey(KeyCode.DownArrow);
            Left = Input.GetKey(KeyCode.LeftArrow);
            Right = Input.GetKey(KeyCode.RightArrow);
            Fire = Input.GetKeyDown(KeyCode.RightShift);
        }
        else
        {
            Up = Input.GetKey(KeyCode.W);
            Down = Input.GetKey(KeyCode.S);
            Left = Input.GetKey(KeyCode.A);
            Right = Input.GetKey(KeyCode.D);
            Fire = Input.GetKeyDown(KeyCode.LeftShift);
        }
    }
}
