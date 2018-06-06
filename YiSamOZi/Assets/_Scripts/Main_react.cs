using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Main_react : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("adasd");
        GameObject col_gameobject = collision.gameObject;
        if(col_gameobject.tag == "Task")
        {
            Flowchart.BroadcastFungusMessage(col_gameobject.name);
            Destroy(col_gameobject);
        }
    }

}
