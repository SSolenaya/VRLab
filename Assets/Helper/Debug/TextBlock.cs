using UnityEngine;
using UnityEngine.UI;

namespace Assets.MainFolder.Scripts {
    public class TextBlock : MonoBehaviour {
        [ReadOnly] public DebugSaltCanvas _debugSaltCanvas;
        [ReadOnly] public int _index;

        public Text textContent;

        public RectTransform content;
        public RectTransform parentText;

        public Button btnDel;

        public void Start() {
            btnDel.onClick.AddListener(DelBox);
        }

        public void DelBox() {
            _debugSaltCanvas.DelString(_index);
            Destroy(gameObject);
        }

        public void SetText(string str, DebugSaltCanvas debugSaltCanvas, int index) {
            _index = index;
            _debugSaltCanvas = debugSaltCanvas;
            gameObject.SetActive(true);
            textContent.text = str;
            SetSizeRectText();
        }

        [ContextMenu("SetSizeRectText")]
        public void SetSizeRectText () {
            parentText.sizeDelta = new Vector2(parentText.sizeDelta.x, textContent.preferredHeight);
            //Debug.Log(content.position);
            //Debug.Log(content.sizeDelta);
            //Debug.Log(content.anchorMax + " " + content.anchorMin + " " + content.anchoredPosition + " " + " " + content.rect.position);
            //content.position = new Vector3(content.position.x, 0f, 0f);
        }


    }
}