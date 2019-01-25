using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Dart : NetworkBehaviour
{
    [SyncVar]
    private Vector3 direction = Vector3.zero;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(direction * 0.8f, ForceMode.VelocityChange);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (!collision.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public void setDir(Vector3 dir) {
        direction = dir; 
    }
}
