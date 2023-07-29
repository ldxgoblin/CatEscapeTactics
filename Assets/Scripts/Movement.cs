using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Transform Player;
    public SwipeControls Controls;

    private bool Lane1 = false;
    private bool Lane2 = true;
    private bool Lane3 = false;

    float horizontalInput;
    float speed = 5;

    private void Start()
    {
        Player = GetComponent<Transform>();
    }
}
