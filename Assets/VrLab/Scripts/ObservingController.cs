using UnityEngine;

namespace Assets.VrLab.Scripts {
    public class ObservingController : MonoBehaviour {
        public static ObservingController inst;
        public int startIndex = 3;
        public static int maxIndex = 5;
        public Sphere360 spheresPrefab;

        public Sphere360 currentSphere;
        //public Point point;
        //public List<Point> fullPointsList = new List<Point>();

        public void Awake() {
            inst = this;
        }

        public void CreateSphere(int index) {
            DeleteSphere(index);
        }

        public void DeleteSphere(int index) {
            if (currentSphere != null) {
                currentSphere.SetActivePointsList(false);
                currentSphere.FadingSphere(0, 1.5f, () => {
                    currentSphere.DeletePoints();
                    Destroy(currentSphere.gameObject);
                    currentSphere = Instantiate(spheresPrefab);
                    currentSphere.Setup(index);
                }); //1.5f
            } else {
                currentSphere = Instantiate(spheresPrefab);
                currentSphere.Setup(index);
            }
        }


        public void Start() {
            CreateSphere(startIndex);
        }
    }
}