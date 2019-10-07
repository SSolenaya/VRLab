using System.Collections;
using Assets.VrLab.Scripts;
using UnityEngine;

public class Oscilograf : MonoBehaviour
{
    private Coroutine _coro;

    public void Awake () {
        gameObject.SetActive(true);
    }
    public void ActionOnEnterBtn () {
        StopCoro();
        //Debug.Log("Указатель зашел на кнопку в Oscilograf");
        _coro = StartCoroutine(IEActionOnBtn());
    }

    public void ActionOnExitBtn () {
        StopCoro();
        //Debug.Log("Указатель покинул кнопку в Oscilograf");
    }

    public void StopCoro () {
        if(_coro != null) {
            StopCoroutine(_coro);
            _coro = null;
        }
    }

    public IEnumerator IEActionOnBtn () {
        yield return new WaitForSeconds(1.5f);
        //Debug.Log("Действие при задержке взгляда на кнопку в Oscilograf");
        ObservingController.inst.currentSphere.SetActivePointsList(true);
        ObservingController.inst.currentSphere.SetActivePinsList(true);
        Destroy(gameObject);
    }
}
