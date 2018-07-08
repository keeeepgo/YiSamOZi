using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using yisamozi.table;
using System.IO;
using System.Text;

[CustomEditor(typeof(GroupControl))]
public class PropertyExpose : Editor
{
    GroupControl group;
    TypeTable typeTable;
    public void OnEnable()
    {
        loadTarget();
        group = target as GroupControl;
        typeTable = TypeTable.getTable();
    }

    public override void OnInspectorGUI()
    {
        this.serializedObject.Update();
        if (group == null)
            return;
        //this.DrawDefaultInspector();
        var empty = new GUILayoutOption[0];
        EditorGUILayout.BeginVertical(empty);
        drawPool();


        EditorGUILayout.EndVertical();
        if (GUI.changed)
        {

            EditorUtility.SetDirty(target);
            saveTarget();
        }
        this.serializedObject.ApplyModifiedProperties();

    }

    private void drawPool()
    {
        var poolList = this.serializedObject.FindProperty("poolList");

        var temp2 = group.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        foreach (var f1 in temp2)
        {
            typeTable.drawIns(f1.FieldType, f1, this.target);
        }

        EditorGUILayout.Space();
    }


    private void saveTarget()
    {
        string fileName = @"Assets/data/" + target.name + ".dat";
        StreamWriter ws = new StreamWriter(fileName, false, Encoding.UTF8);

        string json = JsonUtility.ToJson(target);
        ws.Write(json);
        ws.Close();

    }
    private void loadTarget()
    {
        string fileName = @"Assets/data/" + target.name + ".dat";
        StreamReader sr = new StreamReader(fileName, Encoding.UTF8);
        string json = sr.ReadToEnd();
        sr.Close();
        JsonUtility.FromJsonOverwrite(json, target);
    }
}
