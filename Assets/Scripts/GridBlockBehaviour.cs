using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBlockBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CheckPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPosition()
    {
        //if(transform.position.x==6.75 && transform.position.z==5.25)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == 6.75 && transform.position.z == 3.75)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == -5.25 && transform.position.z == 5.25)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == -0.75 && transform.position.z == 5.25)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == 3.75 && transform.position.z == 3.75)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == -5.25 && transform.position.z == 0.75)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == -5.25 && transform.position.z == -2.25)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == -5.25 && transform.position.z == -6.75)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == -0.75 && transform.position.z == -6.75)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == 2.25 && transform.position.z == -6.75)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == 5.25 && transform.position.z == -6.75)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == 5.25 && transform.position.z == -3.75)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == 5.25 && transform.position.z == 0.75)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == 2.25 && transform.position.z == -3.75)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == -0.75 && transform.position.z == -3.75)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else if (transform.position.x == 2.25 && transform.position.z == -0.75)
        //{
        //    this.gameObject.SetActive(false);
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Void"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
