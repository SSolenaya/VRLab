using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.VrLab.Scripts {
    public class InfoClass : MonoBehaviour
    {
        //public List<Texture> texturesList = new List<Texture>();
        public static InfoClass inst;
        public List<InfoSphere> infoSpheresList = new List<InfoSphere>(ObservingController.maxIndex);

        void Awake() {
            inst = this;
        }

        public InfoSphere GetInfoSphere (int index) {
            return infoSpheresList[index];
        }
    }
    [Serializable]
    public class InfoPoint {

    }

    [Serializable]
    public class InfoSphere {
        public List<InfoPoint> infoPointsList = new List<InfoPoint>();
        public Texture textureInfo;
    }
}