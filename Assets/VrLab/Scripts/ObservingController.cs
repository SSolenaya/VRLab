using System.Collections.Generic;
using UnityEngine;

namespace Assets.VrLab.Scripts {
    public class ObservingController: MonoBehaviour {

        public static ObservingController inst;
        public int startIndex = 3;
        public static int maxIndex = 5;
        public Sphere360 spheresPrefab;
        //public Point point;
        public List<Point> fullPointsList = new List<Point>();
    
        public void Awake () {
            inst = this;
        }

        public void CreateSphere(int index) {
            var sphereOnScene = Instantiate(spheresPrefab);
            sphereOnScene.Setup(index);
        }

        public void Start() {
            CreateSphere(startIndex);
        }

    }
}
