using System.Collections;
using Assets.VrLab.Scripts;
using UnityEngine;

public class Pin : MonoBehaviour {
    //public int pinsID;
    //public Vector3 position;
    public GameObject pinsRelatedPrefab;
    private Coroutine _coro;
   

    void Awake () {
        gameObject.layer = 9;
    }

    public void ActionOnEnterPin () {
        StopCoro();
        //Debug.Log("Указатель зашел на pin ");
        _coro = StartCoroutine(IEActionOnPin());
    }

    public void ActionOnExitPin () {
        StopCoro();
        //Debug.Log("Указатель покинул pin ");
    }

    public void StopCoro () {
        if(_coro != null) {
            StopCoroutine(_coro);
            _coro = null;
        }
    }

    public IEnumerator IEActionOnPin () {
        yield return new WaitForSeconds(1.5f);
        //Debug.Log("Действие при задержке взгляда на pin");
        var content = Instantiate(pinsRelatedPrefab);
        content.transform.LookAt(Camera.main.transform);
        content.transform.Rotate(0,180,0);
        ObservingController.inst.currentSphere.SetActivePointsList(false);
        ObservingController.inst.currentSphere.SetActivePinsList(false);

    }

}
