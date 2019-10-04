using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.VrLab.Scripts {
    public class InfoClass : MonoBehaviour {
        //public List<Texture> texturesList = new List<Texture>();
        public static InfoClass inst;
        public List<InfoSphere> infoSpheresList = new List<InfoSphere>(ObservingController.maxIndex);

        void Awake() {
            inst = this;
        }

        public InfoSphere GetInfoSphere(int iD) {
            foreach (var sphere in infoSpheresList) {
                if (sphere.iD == iD) {
                    return sphere;
                }
            }
            throw new InvalidOperationException("Invalid sphere ID");
        }

        public List<InfoPoint> GetInfoPoints (InfoSphere sphere) {
            return sphere.infoPointsList;
        }

        public List<InfoPin> GetInfoPins (InfoSphere sphere) {
            return sphere.infoPinsList;
        }

    }

    [Serializable]
    public class InfoPoint {
        public int id;
        public Vector3 position;
    }

    [Serializable]
    public class InfoPin {
        public Vector3 position;
        public GameObject prefab;
    }

    [Serializable]
    public class InfoSphere {
        public int angleX;
        public int angleY;
        public int angleZ;
        public int iD;
        public List<InfoPoint> infoPointsList = new List<InfoPoint>();
        public List<InfoPin> infoPinsList = new List<InfoPin>();
        public Texture textureInfo;
    }
}