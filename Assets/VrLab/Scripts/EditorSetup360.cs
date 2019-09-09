using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.VrLab.Scripts {
    public class EditorSetup360 : MonoBehaviour {
        public MainUiControllers mainainUiControllers;
        public List<Info360Img> listInfo360Img = new List<Info360Img>();
        public Transform sphere;

        public Material materialOnSphere;
        [ReadOnly] public Texture currentTexture;


        [EasyButtons.Button]
        public void SetImg() {
            var info360Img = GetInfo360ImgByNameTexture(currentTexture.name);
            if (info360Img == null) {
                listInfo360Img.Add(new Info360Img() {
                    texture = currentTexture,
                    name = currentTexture.name,
                    vector3 = sphere.eulerAngles
                });
                return;
            }
            info360Img.texture = currentTexture;
            info360Img.name = currentTexture.name;
            info360Img.vector3 = sphere.eulerAngles;
        }

        public Info360Img GetInfo360ImgByNameTexture(string nameText) {
            foreach (var info360Img in listInfo360Img) {
                if (info360Img.texture.name == nameText) {
                    return info360Img;
                }
            }
            return null;

        }

        //[EasyButtons.Button]
        public void GetNext() {
            if (currentTexture != null) {
                for (var i = 0; i < mainainUiControllers.listTextures.Count; i++) {
                    if (mainainUiControllers.listTextures[i].name == currentTexture.name && i < mainainUiControllers.listTextures.Count - 1) {
                        currentTexture = mainainUiControllers.listTextures[i + 1];
                        materialOnSphere.mainTexture = currentTexture;
                        return;
                    }
                }
            }

            currentTexture = mainainUiControllers.listTextures[0];
            materialOnSphere.mainTexture = currentTexture;
        }

        [EasyButtons.Button]
        public void GetNextFromListInfo() {
            if (currentTexture != null) {
                for (var i = 0; i < listInfo360Img.Count; i++) {
                    if (listInfo360Img[i].name == currentTexture.name && i < listInfo360Img.Count - 1) {
                        currentTexture = listInfo360Img[i + 1].texture;
                        materialOnSphere.mainTexture = currentTexture;
                        sphere.eulerAngles = listInfo360Img[i + 1].vector3;
                        return;
                    }
                }
            }

            currentTexture =  currentTexture = listInfo360Img[0].texture;
            materialOnSphere.mainTexture = currentTexture;
            sphere.eulerAngles = listInfo360Img[0].vector3;
        }
    }


    [Serializable]
    public class Info360Img {
        public string name;
        public int number;
        public Vector3 vector3;
        public Texture texture;
    }
}