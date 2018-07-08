using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[AttributeUsage(AttributeTargets.Field|AttributeTargets.Property)]
public class CustomClassAttribute : Attribute {
    private static bool showState=true;

    public CustomClassAttribute()
    {
    }
    public bool ShowState { get { return showState; } set { showState = value; } }
}
