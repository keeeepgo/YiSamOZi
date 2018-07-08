using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace yisamozi.model
{
    [System.Serializable]
    public class Wave
    {
        public int Enemynum;
        public float waitForStart;
        public List<InitRelation> iniReList;

        public override string  ToString()
        {
            return "Enemynum: " + Enemynum + "\n waitForStart: " + waitForStart;
        }
    }

}