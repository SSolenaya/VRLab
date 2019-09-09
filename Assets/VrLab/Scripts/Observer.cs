using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.XR;

public class Observer : MonoBehaviour {

    public Vector3 observersPosition;
    public Camera pointsCamera;
    public Camera VRCamera;
    public PointLight observersPointLight;
    public Coroutine coro;
    public static  Observer inst;



    void Awake() {
        inst = this;
    }

    public void StartObserversMovement(Vector3 destination) {
        if (coro != null) coro = null;
        coro = StartCoroutine(IEObserversMovement(destination));
    }

    public IEnumerator IEObserversMovement(Vector3 destination) {
        Vector3 startPos = observersPosition;
        float currentTime = 0;
        float fullTime = 3f;

        while (currentTime < fullTime) {
            var t = currentTime / fullTime;
            observersPosition = Vector3.Lerp(startPos,destination,t);
            currentTime += Time.deltaTime;
        }
        yield return null;
    }



}
