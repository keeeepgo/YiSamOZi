

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Director_start1 : Director_Mono_abs
{
 
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

 

    public void First_session1()
    {
        //MainCharacter.transform.DOMove(soldier_oldman_task_point.transform.localPosition,1.5f);
        MainCharacter.GetComponent<DOTweenPath>().DOPlay();
    }


}

