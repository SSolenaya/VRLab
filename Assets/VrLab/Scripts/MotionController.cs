using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MotionController : MonoBehaviour {

    public static MotionController inst;
    public Sphere360 currentSphere;
    public Sphere360 nextSphere;
    public Point point;
    public List<Point> fullPointsList = new List<Point>();
    public Observer observer;

    public void Awake () {
        inst = this;
    }


    public void ClickingPoints() {
        foreach (var p in fullPointsList) {
            
        }
    }

    public void InstantiateSphereToPoint () {
        nextSphere.currentSphereTexture = point.pointsTexture;
        nextSphere.spherePosition = point.pointPosition;
    }

    public void SwitchingSpheres() {
        Observer.inst.StartObserversMovement(point.pointPosition);
    }


    public void Start() {

    }

}
