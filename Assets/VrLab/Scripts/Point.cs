using System.Collections;
using UnityEngine;

namespace Assets.VrLab.Scripts {
    public class Point : MonoBehaviour {
        public Coroutine coro;
        public int iD;
   
        void Awake() {
            gameObject.layer = 9;
        }

        public void ActionOnEnterPoint() {
            StopCoro();
            //Debug.Log("Указатель зашел на поинт " + iD);
            coro = StartCoroutine(IEActionOnPoint());
        }

        public void ActionOnExitPoint() {
            StopCoro();
            //Debug.Log("Указатель покинул поинт " + iD);
        }

        public void StopCoro() {
            if(coro != null) {
                StopCoroutine(coro);
                coro = null;
            }
        }

        public IEnumerator IEActionOnPoint() {
            yield return new WaitForSeconds(2f);
            //Debug.Log("Действие при задержке взгляда на поинте");
            ObservingController.inst.CreateSphere(iD);
        }

    }
}
