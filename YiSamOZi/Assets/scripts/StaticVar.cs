using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVar : MonoBehaviour {
    private static  int bgNumber = 3;
    private static float scheight = 1920;
    private static float scwidth = 1080;
    private static float height = 20f;

    public static int BGNUMBER { get { return bgNumber;}}

    public static float HEIGHT{ get { return height;}}

    public static float WIDTH { get { return height * (scwidth / scheight); } }
}
