using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour {
    private Transform camera_trans;

	// Use this for initialization
	void Start () {
        camera_trans = Camera.main.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        float bgLen = StaticVar.BGNUMBER*StaticVar.HEIGHT;
        float camera_py = camera_trans.position.y;
        float deltaLen = camera_py-this.GetComponent<Transform>().position.y;
        if (deltaLen>bgLen/2)
        {
            int moveTime = (int)(deltaLen / bgLen + 0.5f);
            this.GetComponent<Transform>().Translate(new Vector2(0, moveTime * bgLen),Space.World);
        }
	}
}
