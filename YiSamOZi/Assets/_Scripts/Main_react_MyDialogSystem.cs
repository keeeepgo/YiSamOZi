using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_react_MyDialogSystem : MonoBehaviour {

    public Canvas UI_canvas;
    GameObject DialogBox;
    GameObject DialogBox_Text;
    GameObject PopBox;
    GameObject PopBox_Content;
    GameObject PopBox_Content_PointName;
    GameObject PopBox_Content_Question;
    GameObject ReactButton;
    bool React;

    private void UI_show(GameObject UI)
    {
        UI.GetComponent<CanvasGroup>().alpha = 1;
        UI.GetComponent<CanvasGroup>().interactable = true;
        UI.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private void UI_hide(GameObject UI)
    {
        UI.GetComponent<CanvasGroup>().alpha = 0;
     //   UI.GetComponent<CanvasGroup>().interactable = false;
        UI.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    private void ReactButtondown()
    {
        React = true;
        UI_hide(ReactButton);
    }

    // Use this for initialization
    void Start()
    {
        DialogBox = GameObject.Find("DialogBox");
        DialogBox_Text = DialogBox.transform.Find("Text").gameObject; ;
        PopBox = GameObject.Find("PopBox");
        PopBox_Content = PopBox.transform.Find("Content").gameObject;
        PopBox_Content_PointName = PopBox_Content.transform.Find("PointName").gameObject;
        PopBox_Content_Question = PopBox_Content.transform.Find("Question").gameObject;
        ReactButton = GameObject.Find("ReactButton");
        ReactButton.GetComponent<Button>().onClick.AddListener(ReactButtondown);

        UI_hide(DialogBox);
        UI_hide(PopBox);
        UI_hide(ReactButton);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collision_object = collision.gameObject;
        //Debug.Log(collision_object.tag);

        if (!React)
        {
            UI_show(ReactButton);
        }else{
            UI_hide(ReactButton);
            if (collision_object.tag == "NPC")
            {
                Let_NPC_say(collision_object);
            }
            if (collision_object.tag == "CheckPoint")
            {
                Check_enter(collision_object);
            }
            if (collision_object.tag == "LeavePoint")
            {
                Leave_enter(collision_object);
            }
            
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collision_object = collision.gameObject;
        Debug.Log(collision_object.tag);

        React = false;
        UI_hide(ReactButton);

        if (collision_object.tag == "NPC")
        {
            Let_NPC_skip(collision_object);
        }
        if (collision_object.tag == "CheckPoint")
        {
            Check_exit(collision_object);
        }
        if (collision_object.tag == "LeavePoint")
        {
            Leave_exit(collision_object);
        }
    }


    public void Let_NPC_say(GameObject NPC)
    {
        UI_show(DialogBox);
        DialogBox_Text.GetComponent<Text>().text = NPC.GetComponent<NPC_info>().say_words;
    }

    public void Let_NPC_skip(GameObject NPC)
    {
        UI_hide(DialogBox);
    }

    public void Check_enter(GameObject checkpoint)
    {
        UI_show(PopBox);
        PopBox_Content_PointName.GetComponent<Text>().text = checkpoint.GetComponent<CheckPoint_info>().point_name;
        PopBox_Content_Question.GetComponent<Text>().text = checkpoint.GetComponent<CheckPoint_info>().question;
    }

    public void Check_exit(GameObject checkpoint)
    {
        UI_hide(PopBox);
    }

    public void Leave_enter(GameObject leavepoint)
    {
        UI_show(PopBox);
        PopBox_Content_PointName.GetComponent<Text>().text = leavepoint.GetComponent<LeavePoint_info>().point_name;
        PopBox_Content_Question.GetComponent<Text>().text = leavepoint.GetComponent<LeavePoint_info>().question;
    }

    public void Leave_exit(GameObject leavepoint)
    {
        UI_hide(PopBox);
    }
}
