using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Leave_scene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if(collision.gameObject.tag == "MainCharacter")
        {
            Flowchart.BroadcastFungusMessage("Leave_scene");
        }
    }
}
