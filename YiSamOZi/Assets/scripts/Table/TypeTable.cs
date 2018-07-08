using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using System;
using yisamozi.model;

namespace yisamozi.table
{
    public class TypeTable
    {

        delegate object draw(string name, object val, object info);

        //inspect面板下拉激活标志
        private Dictionary<int,bool> activeFlags = new Dictionary<int, bool>(10);

        private Dictionary<Type, draw> dict;
        private static TypeTable entity = null;
        private GUILayoutOption[] empty = new GUILayoutOption[0];
        //创建表
        private TypeTable()
        {
            dict = new Dictionary<Type, draw>(10);
            dict.Add(typeof(int), drawInt);
            dict.Add(typeof(float), drawFloat);
            dict.Add(typeof(List<Wave>), drawList);
            dict.Add(typeof(List<InitRelation>), drawList);
            dict.Add(typeof(Wave), drawProperty);
            dict.Add(typeof(InitRelation), drawProperty);
            dict.Add(typeof(List<float>), drawList);

        }

        public static TypeTable getTable()
        {
            if (entity != null)
                return entity;
            else
                return new TypeTable();
        }
        public void drawIns(Type dataType, object info, object target)
        {
            Type infotype = info.GetType();
            try
            {
                if (typeof(PropertyInfo).IsAssignableFrom(infotype))
                {
                    PropertyInfo pinfo = (PropertyInfo)info;
                    object oldval = pinfo.GetGetMethod().Invoke(target, null);

                    object newval = dict[dataType].Invoke(pinfo.Name, oldval, info);
                    if (newval != oldval && newval != null)
                    {
                        pinfo.GetSetMethod().Invoke(target, new[] { newval });
                    }
                }
                else if (typeof(FieldInfo).IsAssignableFrom(infotype))
                {
                    FieldInfo finfo = (FieldInfo)info;
                    object oldval = finfo.GetValue(target);

                    object newval = dict[dataType].Invoke(finfo.Name, oldval, info);

                    finfo.SetValue(target, newval);
                }
            }
            catch (KeyNotFoundException e)
            {
                EditorGUILayout.HelpBox(info + "在表中没有匹配", MessageType.Error);
            }
        }


        private object drawInt(string name, object val, object none)
        {
            return EditorGUILayout.IntField(name, (int)val, empty);
        }
        private object drawFloat(string name, object val, object none)
        {
            return EditorGUILayout.FloatField(name, (float)val, empty);
        }

        private object drawList(string name, object val, object info)
        {
            Type type;
            if (typeof(PropertyInfo).IsAssignableFrom(info.GetType()))
            {
                PropertyInfo pinfo = (PropertyInfo)info;
                type = pinfo.PropertyType;
            }
            else
            {
                FieldInfo finfo = (FieldInfo)info;
                type = finfo.FieldType;
            }
            if (val == null)
                val = type.GetConstructor(new Type[] { }).Invoke(new object[] { });
            int hashcode = val.GetHashCode();
            try
            {
                activeFlags[hashcode] = EditorGUILayout.Foldout(activeFlags[hashcode], name);
            }
            catch (KeyNotFoundException e)
            {
                activeFlags.Add(hashcode, false);
                activeFlags[hashcode] = EditorGUILayout.Foldout(activeFlags[hashcode], name);
            }


            if (activeFlags[hashcode])
            {
                EditorGUI.indentLevel++;
                Type eleType;

                MethodInfo getInfo;
                MethodInfo addInfo;
                PropertyInfo capacityInfo;
                PropertyInfo CountInfo;
               
                eleType = type.GetGenericArguments()[0];
                addInfo = type.GetMethod("Add");
                getInfo = type.GetMethod("get_Item");
                capacityInfo = type.GetProperty("Capacity");
                CountInfo = type.GetProperty("Count");

                int count = (int)CountInfo.GetGetMethod().Invoke(val, null);
                int capacity = EditorGUILayout.DelayedIntField("size", (int)capacityInfo.GetGetMethod().Invoke(val, null));

                //if (count > capacity)
                //{
                //    val=type.GetMethod("CopyTo",new Type[] { Int32,})
                //}
                capacityInfo.GetSetMethod().Invoke(val, new object[] { capacity });

                for (int i = 0; i < capacity; i++)
                {
                    object element;
                    if (count < capacity)
                    {
                        element = Activator.CreateInstance(eleType, new object[] { });
                        addInfo.Invoke(val, new object[] { element });
                        count++;
                    }
                    else
                    {
                        element = getInfo.Invoke(val, new object[] { i });
                    }
                    //var finfos = element.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

                    //foreach (var finfo in finfos)
                    //    drawIns(finfo.FieldType, finfo, element);
                    try { 
                        element=dict[eleType].Invoke(eleType.Name +" "+i+" :", element, null);
                            Debug.Log(getInfo.Invoke(val, new object[] { i }));
                    }
                    catch(KeyNotFoundException e)
                    {
                        EditorGUILayout.HelpBox(eleType+ "在表中没有匹配", MessageType.Error);
                    }
                }
                EditorGUI.indentLevel--;
            }
            return val;
        }

        private object drawProperty(string name,object val,object info)
        {
            Type type;
            if (val == null)
            {
                if (typeof(PropertyInfo).IsAssignableFrom(info.GetType()))
                {
                    PropertyInfo pinfo = (PropertyInfo)info;
                    type = pinfo.PropertyType;
                }
                else
                {
                    FieldInfo finfo = (FieldInfo)info;
                    type = finfo.FieldType;
                }
                val = type.GetConstructor(new Type[] { }).Invoke(new object[] { });
            }
            else
                type = val.GetType();
            int hashcode = val.GetHashCode();
            try
            {
                activeFlags[hashcode] = EditorGUILayout.Foldout(activeFlags[hashcode], name);
            }
            catch (KeyNotFoundException e)
            {
                activeFlags.Add(hashcode, false);
                activeFlags[hashcode] = EditorGUILayout.Foldout(activeFlags[hashcode], name);
            }
            if (activeFlags[hashcode])
            {
                EditorGUI.indentLevel++;
                var finfos=type.GetFields(BindingFlags.Public | BindingFlags.Instance);
                var pinfos= type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach(var finfo in finfos)
                    drawIns(finfo.FieldType, finfo, val);
                foreach (var pinfo in pinfos)
                    drawIns(pinfo.PropertyType, pinfo, val);
                EditorGUI.indentLevel--;
            }
            return val;
        }
    }
}