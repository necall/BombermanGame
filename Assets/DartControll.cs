using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DartControll : MonoBehaviour {
    public float coldTime = 2f;
    private float timer = 0f;
    private bool isStartTimer;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (isStartTimer)
        {
            timer += Time.deltaTime;
        }
        if (timer > coldTime)
        {
            timer = 0f;
            GetComponent<Button>().interactable = true;
        }
	}

    public void OnClick()
    {
        Debug.Log("Click Dart");
        isStartTimer = true;
        GetComponent<Button>().interactable = false;

    }
}
