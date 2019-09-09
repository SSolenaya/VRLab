using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Point : MonoBehaviour, IPointerEnterHandler {

    public Vector3 pointPosition;
    public Texture pointsTexture;
    public MotionController mC;

    void Awake() {
        mC.point = this;
    }

    
    public void OnPointerEnter (PointerEventData eventData) {
        MotionController.inst.InstantiateSphereToPoint();
    }

    public void OnPointerExit (PointerEventData eventData) {

    }

}
