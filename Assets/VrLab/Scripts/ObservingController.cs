using System.Collections.Generic;
using UnityEngine;

namespace Assets.VrLab.Scripts {
    public class ObservingController: MonoBehaviour {

        public static ObservingController inst;
        public int startIndex = 3;
        public static int maxIndex = 5;
        public Sphere360 spheresPrefab;
        public Sphere360 currentSphere;
        //public Point point;
        //public List<Point> fullPointsList = new List<Point>();

        public void Awake () {
            inst = this;
        }

        public void CreateSphere(int index) {
            DeleteSphere();
            currentSphere = Instantiate(spheresPrefab);
            currentSphere.Setup(index);
        }

        public void DeleteSphere() {
            if (currentSphere != null) {
                currentSphere.FadingSphere(0, 1.5f);
                currentSphere.DeletePoints();
                Destroy(currentSphere.gameObject);
            }
        }

        public void Start() {
            CreateSphere(startIndex);
        }

    }
}
