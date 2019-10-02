using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.UI;
using UnityEngine.VR;
using UnityEngine.XR;

namespace Assets.VrLab.Scripts {
    public class ObservingController: MonoBehaviour {

        public static ObservingController inst;
        public int startIndex = 3;
        public static int maxIndex = 5;
        public Sphere360 spheresPrefab;
        public Sphere360 currentSphere;
        public bool modeVR;

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

        IEnumerator LoadDevice (string newDevice, bool isEnable) {
            XRSettings.LoadDeviceByName(newDevice);
            yield return new WaitForSeconds(0.5f);
            XRSettings.enabled = isEnable;
        }

        public void EnableVR () {
            StartCoroutine(LoadDevice("cardboard", true));
            Camera.main.transform.localRotation = Quaternion.identity;
        }

        public void DisableVR () {
            StartCoroutine(LoadDevice("", false));
            Camera.main.ResetAspect();
            Camera.main.transform.localRotation = UnityEngine.XR.InputTracking.GetLocalRotation(XRNode.CenterEye);
        }

    }
}
