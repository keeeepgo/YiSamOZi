using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed = 2f;
    public float yiSam_cold = 0.3f;
    public float attackRange = 0.1f;
    public Text rankText;

    private Transform mytrans;
    private float yiSam_lastTime;
	// Use this for initialization
	void Start () {
        mytrans = GetComponent<Transform>();
        yiSam_lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = 0;
        horizontal = Input.GetAxisRaw("Horizontal")*StaticVar.WIDTH/3;
        //Debug.Log("horizontal: " + horizontal);
        float hmove=Mathf.Abs(mytrans.position.x+horizontal)>StaticVar.WIDTH/2?0:horizontal;
        if (hmove != 0) yisam(hmove);
        mytrans.position += new Vector3(0, speed * Time.deltaTime);
        //Debug.Log(mytrans.position);
	}

    private void yisam(float xmove)
    {
        //Debug.Log("Start Coroutine");
        if (yiSam_lastTime + yiSam_cold > Time.time)
            return;
        yiSam_lastTime = Time.time;
        SortedList list = new SortedList(10);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("enemy");
        Vector3 mpositon = mytrans.position;
        foreach(var enemy in objs){
            Vector3 epositon = enemy.GetComponent<Transform>().position;
            float distance = Vector3.Distance(epositon, mpositon);
            if (Mathf.Abs(epositon.x - mpositon.x) < 0.01f && distance <= attackRange)
                list.Add(distance, enemy);
        }
        if (list.Count > 0)
        {
            GameObject.Destroy((GameObject)list.GetByIndex(0));
            string[] temp= rankText.text.Split(':');
            int rank = int.Parse(temp[1])+10;
            rankText.text = "Rank:" + rank ;
        }
        mytrans.position += new Vector3(xmove, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("enemy"))
        {
            Debug.Log("died");
        }
    }

}
