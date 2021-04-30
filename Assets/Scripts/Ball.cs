using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject StartPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Under"))
        {
            transform.position = StartPosition.transform.position;
        }
    }
}
