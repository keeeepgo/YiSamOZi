using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Director_Mono_abs : MonoBehaviour,Director_interface {

    public GameObject MainCharacter;
    public Camera MainCamera;

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

    public void Black_only_SayDia()
    {
        MainCamera.cullingMask = 1 << 5;
    }

    public void Recover_Black()
    {
        MainCamera.cullingMask = 11111;
    }

    public void Hide_LeaveDialog()
    {
        GameObject.Find("Leave_MenuDialog").SetActive(false);
    }
}
