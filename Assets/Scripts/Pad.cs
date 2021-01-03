using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    public Joystick Joystick;
    float YRotation = 0;
    float XRotation = 0;
    public float RotationSpeed;
    Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        YRotation = Joystick.Vertical;
        XRotation = Joystick.Horizontal;

        transform.Rotate(Vector3.right, YRotation);
        transform.Rotate(Vector3.forward, -XRotation);
    }
}
