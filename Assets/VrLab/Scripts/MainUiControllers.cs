using System.Collections.Generic;
using Assets.VrLab.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class MainUiControllers: MonoBehaviour {
    public static MainUiControllers inst;
    public TestBtn sampleBtn;
    public Material sphereMat;
    public List<Texture> listTextures;
    public Transform parentBtn;

    public void Awake() {
        inst = this;
    }

    void Start () {
      /*  for (int i = 0; i < listTextures.Count; i++) {
            var newBtn = Instantiate(sampleBtn);
            newBtn.GetComponentInChildren<Text>().text = i.ToString();
            newBtn.transform.SetParent(parentBtn.transform);

            newBtn.index = i;

            newBtn.gameObject.SetActive(true);
            newBtn.transform.localPosition = Vector3.zero;
            newBtn.transform.localScale = Vector3.one;*/
        }
    }

   /* public void SetMat(int i) {
        sphereMat.mainTexture = listTextures[i];
    }*/

