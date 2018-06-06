using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Normal_NPC_Say : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        Flowchart.BroadcastFungusMessage(this.gameObject.name);
    }
}
