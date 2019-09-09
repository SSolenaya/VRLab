using System.Collections.Generic;
using UnityEngine;

namespace Assets.VrLab.Scripts {
    public class FloorController : MonoBehaviour {
        public float factor = 2;
        public OneCell oneCell;
        //public List<Ve> listPoint = new List<OneCell>();
        public Transform parentForCells;
        public List<OneCell> listGenerationCells;

        public void DestroyAllCells() {
            foreach (var cell in listGenerationCells) {
                if (cell != null) {
                    DestroyImmediate(cell.gameObject);
                }
             
            }
            listGenerationCells.Clear();
        }

        [EasyButtons.Button]
        public void GenerationAllCell() {
            DestroyAllCells();

            for (int x = 1; x <= 17; x++) {
                for (int y = 1; y <= 17; y++) {
                    var cell = Instantiate(oneCell);
                    listGenerationCells.Add(cell);
                    cell.transform.SetParent(parentForCells);
                    cell.transform.localPosition = new Vector3(y*factor, 0, x*factor);
                    cell.textMesh.text = "x=" + x + "\n" + "y=" + y;
                    cell.gameObject.SetActive(true);
                }
            }
          
        }
    }


}