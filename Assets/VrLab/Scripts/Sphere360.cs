using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.VrLab.Scripts {
    public class Sphere360: MonoBehaviour {

        [SerializeField] private int _index;
        private float _alpha;
        private List<Point> pointsList = new List<Point>();
        public Point prefabPoint;
        public Material material;
        public Coroutine coro;
        public Color tintColor = new Color (1, 1, 1, 0);
        public Renderer renderer;

        public void Setup (int index) {
            renderer = GetComponent<Renderer>();
            _index = index;
            var infoSphere = InfoClass.inst.GetInfoSphere(index);
            var tex = infoSphere.textureInfo;
            FadingSphere(1, 1.5f);
            GetComponent<Renderer>().material.SetTexture("_MainTex", tex);
            this.gameObject.transform.Rotate(infoSphere.angleX, infoSphere.angleY, infoSphere.angleZ);
            SetupPoints(index);
        }

        public void SetupPoints (int index) {
            var infoSphere = InfoClass.inst.GetInfoSphere(index);
            foreach(var infoPointI in infoSphere.infoPointsList) {
                var point = Instantiate(prefabPoint);
                point.transform.position = infoPointI.position;
                point.transform.LookAt(Camera.main.transform);
                point.gameObject.transform.Rotate(0,180,0);
                point.iD = infoPointI.id;
                pointsList.Add(point);
            }
        }

        public void DeletePoints () {
            foreach(var pointS in pointsList) {
                Destroy(pointS.gameObject);
            }
            pointsList.Clear();
        }

        public void FadingSphere (int tintsAlpha, float fadingTime) {
            coro = StartCoroutine(FadingTint(tintsAlpha, fadingTime));
            GetComponent<Renderer>().material.SetColor("_Color", tintColor);
        }

        public IEnumerator FadingTint (int tintsAlpha, float fadingTime) {
            var currentA = tintColor.a;
            var currentTime = 0f;
            float t;
            while(currentTime < fadingTime) {
                Debug.Log(" " + tintColor.a);
                t = currentTime / fadingTime;
                currentTime += Time.deltaTime;
                tintColor.a = Mathf.Lerp(currentA, tintsAlpha, t);
                renderer.material.SetColor("_Color", tintColor);
                yield return null;
            }
            tintColor.a = tintsAlpha;
            renderer.material.SetColor("_Color", tintColor);
        }
    }
}
