using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Task_Director : MonoBehaviour {

    public GameObject MainCharacter;
    public GameObject OldMan;
    public GameObject DrunkSoldier;
    public GameObject soldier_oldman_task_point;
    public Camera MainCamera;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Freeze_Main_Move_and_Camera_Follow()
    {
        MainCharacter.GetComponent<Main_move>().enabled = false;
        MainCamera.GetComponent<CameraFollow>().enabled = false;
    }

    public void Awake_Main_Move_and_Camera_Follow()
    {
        MainCharacter.GetComponent<Main_move>().enabled = true;
        MainCamera.GetComponent<CameraFollow>().enabled = true;
    }

    public void Soldier_oldman_task()
    {
        Debug.Log(MainCharacter.transform.localPosition);
        Debug.Log(soldier_oldman_task_point.transform.localPosition);
        //MainCharacter.transform.DOMove(soldier_oldman_task_point.transform.localPosition,1.5f);
        MainCharacter.GetComponent<DOTweenPath>().DOPlay();
    }
}
