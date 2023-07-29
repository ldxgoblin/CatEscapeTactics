using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControls : MonoBehaviour
{
    public float horizontalSpeed = 5;
    float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 horizontalMove = transform.right * horizontalInput * horizontalSpeed * Time.deltaTime;

        gameObject.transform.position += horizontalMove;
    }
}
