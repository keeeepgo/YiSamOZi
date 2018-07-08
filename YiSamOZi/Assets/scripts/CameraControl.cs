using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public Transform player_trans;

    private Transform m_trans;
	// Use this for initialization
	void Start () {
        m_trans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(player_trans.position.y - m_trans.position.y);
        m_trans.position += new Vector3(0,player_trans.gameObject.GetComponent<PlayerController>().speed*Time.deltaTime);
	}
}
