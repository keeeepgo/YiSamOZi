using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    private Transform camer_trans;
    private Transform my_trans;
	// Use this for initialization
	void Start () {
        camer_trans = Camera.main.GetComponent<Transform>();
        my_trans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (my_trans.position.y < camer_trans.position.y - StaticVar.HEIGHT*1.5)
            GameObject.Destroy(this.gameObject);
	}
}
