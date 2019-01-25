using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    Vector3 zero;
    private float tanViewAngle;

	// Use this for initialization
	void Start () {
        tanViewAngle = Mathf.Tan(transform.rotation.eulerAngles.x * Mathf.PI / 180);
	}
	
	// Update is called once per frame
	void Update () {
        if(player == null)
        {
            return;
        }
        float dist = 10f;
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position - dist / tanViewAngle * Vector3.forward + dist * Vector3.up ,0.5f);
	}
    
}
