using System.Collections;
using System.Collections.Generic;
using Assets.VrLab.Scripts;
using UnityEngine;

public class MeasurementModule : MonoBehaviour
{
    private Coroutine _coro;

    public void Awake () {
        gameObject.SetActive(true);
    }
    public void ActionOnEnterBtn () {
        StopCoro();
        //Debug.Log("Указатель зашел на кнопку в measurment module");
        _coro = StartCoroutine(IEActionOnBtn());
    }

    public void ActionOnExitBtn () {
        StopCoro();
        //Debug.Log("Указатель покинул кнопку в measurment module");
    }

    public void StopCoro () {
        if(_coro != null) {
            StopCoroutine(_coro);
            _coro = null;
        }
    }

    public IEnumerator IEActionOnBtn () {
        yield return new WaitForSeconds(1.5f);
        //Debug.Log("Действие при задержке взгляда на кнопку в measurment module");
        ObservingController.inst.currentSphere.SetActivePointsList(true);
        ObservingController.inst.currentSphere.SetActivePinsList(true);
        Destroy(gameObject);
    }
}
