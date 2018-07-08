using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace yisamozi.model
{

    [System.Serializable]
    public class InitRelation
    {
        //public GameObject enemy;
        private float profac;
        public float abrProfac;
        public List<float> fileNumProFac;

        public float Profac
        {
            get { return profac; }
            set {
                if (value >= 0 && value <= 1)
                    this.profac = value;
            }
        }
        public override string ToString()
        {
            return "profac: " + profac + " abrProfac: " + abrProfac;
        }
    }
}
