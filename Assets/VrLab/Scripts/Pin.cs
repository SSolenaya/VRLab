using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pin : MonoBehaviour {
    //public int pinsID;
    public Vector3 position;
    public GameObject pinsRelatedPrefab;
    private Coroutine _coro;

    public void Start() {
        
    }


    public void ActionOnEnterPin () {
        StopCoro();
        Debug.Log("Указатель зашел на pin ");
        _coro = StartCoroutine(IEActionOnPin());
    }

    public void ActionOnExitPin () {
        StopCoro();
        Debug.Log("Указатель покинул pin ");
    }

    public void StopCoro () {
        if(_coro != null) {
            StopCoroutine(_coro);
            _coro = null;
        }
    }

    public IEnumerator IEActionOnPin () {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Действие при задержке взгляда на pin");
        var content = Instantiate(pinsRelatedPrefab);
    }

}
