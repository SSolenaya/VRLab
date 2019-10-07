using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.VrLab.Scripts {
    public class Sphere360: MonoBehaviour {

        [SerializeField] private int _index;
        private float _alpha;
        private List<Point> pointsList = new List<Point>();
        private List<Pin> pinsList = new List<Pin>();
        public Point prefabOfPoint;
        public Pin prefabOfPin;
        public Material material;
        public Coroutine coro;
        public Color tintColor = new Color (1, 1, 1, 0);
        public new Renderer renderer;

        public void Setup (int index) {
            renderer = GetComponent<Renderer>();
            _index = index;
            var infoSphere = InfoClass.inst.GetInfoSphere(_index);
            var tex = infoSphere.textureInfo;
            SetupPoints(index);
            SetupPins(index);
            FadingSphere(1, 1.8f, () => {
                SetActivePointsList(true);
                SetActivePinsList(true);
            });
            GetComponent<Renderer>().material.SetTexture("_MainTex", tex);
            this.gameObject.transform.Rotate(infoSphere.angleX, infoSphere.angleY, infoSphere.angleZ);
        }

        public void SetupPoints (int index) {
            var infoSphere = InfoClass.inst.GetInfoSphere(index);
            foreach(var infoPointI in infoSphere.infoPointsList) {
                var point = Instantiate(prefabOfPoint);
                point.gameObject.SetActive(false);
                point.transform.position = infoPointI.position;
                point.transform.LookAt(Camera.main.transform);
                point.gameObject.transform.Rotate(0,180,0);
                point.iD = infoPointI.id;
                pointsList.Add(point);
            }
        }

        public void SetupPins (int index) {
            var infoSphere = InfoClass.inst.GetInfoSphere(index);
            foreach(var infoPinI in infoSphere.infoPinsList) {
                var pin = Instantiate(prefabOfPin);
                pin.gameObject.SetActive(false);
                pin.transform.position = infoPinI.position;
                pin.transform.LookAt(Camera.main.transform);
                //pin.gameObject.transform.Rotate(0, 0, 0);
                pin.pinsRelatedPrefab = infoPinI.prefab;
                //pin.iD = infoPinI.id;
                pinsList.Add(pin);
            }
        }

        public void DeletePointsAndPins () {
            foreach(var pointS in pointsList) {
                Destroy(pointS.gameObject);
            }
            foreach(var pinS in pinsList) {
                Destroy(pinS.gameObject);
            }
            pointsList.Clear();
            pinsList.Clear();
        }

        public void FadingSphere (int tintsAlpha, float fadingTime, Action action) {
            coro = StartCoroutine(FadingTint(tintsAlpha, fadingTime, action));
            GetComponent<Renderer>().material.SetColor("_Color", tintColor);
        }

        public IEnumerator FadingTint (int tintsAlpha, float fadingTime, Action action) {
            var currentA = tintColor.a;
            var currentTime = 0f;
            float t;
            while(currentTime < fadingTime) {
                //Debug.Log(" " + tintColor.a);
                t = currentTime / fadingTime;
                currentTime += Time.deltaTime;
                tintColor.a = Mathf.Lerp(currentA, tintsAlpha, t);
                renderer.material.SetColor("_Color", tintColor);
                yield return null;
            }
            tintColor.a = tintsAlpha;
            renderer.material.SetColor("_Color", tintColor);
            if (action != null) {
                action.Invoke();
            }
        }

        public void SetActivePointsList(bool var) {
            foreach (var eachPoint in pointsList) {
                eachPoint.gameObject.SetActive(var);
            }
        }

        public void SetActivePinsList (bool var) {
                foreach(var eachPin in pinsList) {
                    eachPin.gameObject.SetActive(var);
                }
            }
    }
}
