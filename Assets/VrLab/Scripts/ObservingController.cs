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

       public void CreateSphere (int index) {
            if (currentSphere != null) {
                currentSphere.SetActivePointsList(false);
                currentSphere.FadingSphere(0, 1.2f, () => {
                    currentSphere.DeletePoints();
                    Destroy(currentSphere.gameObject);
                    InstantiateSphere(index);
                });
            }
            else {
                InstantiateSphere(index);
            }
        }

        public void InstantiateSphere(int index) {
            currentSphere = Instantiate(spheresPrefab);
            currentSphere.Setup(index);
        }

        public void Start() {
            CreateSphere(startIndex);
        }

    }
}
