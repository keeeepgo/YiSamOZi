using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_move : MonoBehaviour {

    public Camera uiCamera;
    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertial = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertial);
        this.GetComponent<Rigidbody2D>().AddForce(movement * speed);

    }
}
