using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBlockBehaviour : MonoBehaviour
{
    public Material BallMaterial;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        CheckPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPosition()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Void"))
        {
            this.gameObject.SetActive(false);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag=="Ball")
    //    {
    //        rend.sharedMaterial = BallMaterial;
    //    }
    //}
}
