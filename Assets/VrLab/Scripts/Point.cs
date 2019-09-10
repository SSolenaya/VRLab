using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.VrLab.Scripts {
    public class Point : MonoBehaviour, IPointerEnterHandler {

        public Vector3 pointPosition;
        public Texture pointsTexture;
   
        void Awake() {
        }

    
        public void OnPointerEnter (PointerEventData eventData) {

        }

        public void OnPointerExit (PointerEventData eventData) {

        }

    }
}
