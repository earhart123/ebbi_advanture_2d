using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour {

    GameObject GameController;
    AudioSource audioSource;

    // Use this for initialization
    void Awake () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        GameObject.Find("GameController").SendMessage("IncreaseScore");
    }
}
