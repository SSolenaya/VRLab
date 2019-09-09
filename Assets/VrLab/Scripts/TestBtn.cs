using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.VrLab.Scripts {
    public class TestBtn : MonoBehaviour {
        public EventTrigger eventTrigger;
        public bool onEnter;
        public float currentTime;
        public int index;

        public void OnEnter() {
            onEnter = true;
        }

        public void OnExit() {
            onEnter = false;
        }

        public void Update() {
            if (onEnter) {
                currentTime += Time.deltaTime;
                if (currentTime > 1) {
                    currentTime = 0;
                    MainUiControllers.inst.SetMat(index);
                }
            } else {
                currentTime = 0;
            }
        }
    }
}