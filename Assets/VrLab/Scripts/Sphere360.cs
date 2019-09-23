using System.Collections.Generic;
using UnityEngine;

namespace Assets.VrLab.Scripts {
    public class Sphere360 : MonoBehaviour {

        private int _index;
        private float _alpha;
        private List<Point> pointsList = new List<Point>();
        public Point prefabPoint;
        public Material material;


        public void Setup(int index) {
            var infoSphere = InfoClass.inst.GetInfoSphere(index);
            var tex = infoSphere.textureInfo;
            GetComponent<Renderer>().material.SetTexture("_MainTex", tex);
            material.mainTexture = tex;
            SetupPoints(index);
        }

        public void SetupPoints(int index) {
            var infoSphere = InfoClass.inst.GetInfoSphere(index);
            foreach (var infoPointI in infoSphere.infoPointsList) {
                var point = Instantiate(prefabPoint);
                point.transform.position = infoPointI.position;
                point.iD = infoPointI.id;
                pointsList.Add(point);
            }
        }

        public void DeletePoints() {
            foreach (var pointS in pointsList) {
                Destroy(pointS.gameObject);
            }
            pointsList.Clear();
        }
    }
}
