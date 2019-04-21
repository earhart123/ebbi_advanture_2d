using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour {

    GameObject gameController;
    EbbiController Ebbi;
    bool isDead;

	// Use this for initialization
	void Start () {
        //Ebbi = GameObject.Find("ebbi");
		//gameController = GameObject.FindWithTag("obstacle");
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true;
        Debug.Log("clash");
        GameObject.Find("ebbi").SendMessage("IsDead");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
