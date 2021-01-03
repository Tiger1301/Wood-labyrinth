using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public bool IsFlat = true;
    private Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilt = Input.acceleration;
        if(IsFlat==true)
        {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }
        RB.AddForce(tilt*5);
    }
}
