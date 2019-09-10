using System.Collections.Generic;
using UnityEngine;

namespace Assets.VrLab.Scripts {
    public class Sphere360 : MonoBehaviour {

        private int _index;
        private float _alpha;
    
        public void Setup(int index) {
            var infoSphere = InfoClass.inst.GetInfoSphere(index);
            Texture tex = infoSphere.textureInfo;
            GetComponent<Renderer>().material.SetTexture("_MainTex", tex);
        }
    }
}
