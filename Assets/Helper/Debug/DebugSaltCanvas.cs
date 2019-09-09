using System.Collections;
using System.Collections.Generic;
using Assets.MainFolder.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class DebugSaltCanvas : MonoBehaviour {
    private static DebugSaltCanvas inst;
    public Canvas canvas;
    public string numberBuildStr;
    public Text numberBuildText;
   
    private bool isShowBigLogs;
    public RectTransform panelBigLogs;
    private bool isShowLowLogs;
    public RectTransform panelLowLogs;
    public Button btnDelAll;
    public Button btnHideLogs;

    private int indexAsk;
    public TextBlock textBlockPrefab;
    public List<TextBlock> listTextBlocks;

    private List<string> listStringForTextBlocks = new List<string>();

    public RectTransform parent;
    private int maxLenght = 500;
    private int maxAllLenght = 395000;
    public Text infoText;

    private int needLogsCount = 25;
    private int needDelLogsCount = 50;

    public Queue<string> queueNewLog = new Queue<string>();

    public Coroutine coroShowLog;

    [ReadOnly] public LongPressEventTrigger longPressEventTrigger;
    public Button showDebug;

    public void Awake() {
        inst = this;
        canvas.sortingOrder = 100;
    }


    public void OnEnable () {
        Application.logMessageReceived += HandleLog;
    }

    public void OnDisable () {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog (string logString, string stackTrace, LogType type) {
        if (type == LogType.Warning) {
            return;
        }

        Log(type + " " + logString + " " + stackTrace);
    }

    public void Start () {
        btnHideLogs.onClick.AddListener(SwapActivPanelBigLogs);
        showDebug.onClick.AddListener(SwapActivPanelBigLogs);
        //longPressEventTrigger = showDebug.GetComponent<LongPressEventTrigger>();
        //longPressEventTrigger.onLongPress.AddListener(SwapActivPanelBigLogs);

        indexAsk = 0;
        btnDelAll.onClick.AddListener(DelAll);
        numberBuildText.text = numberBuildStr;

        isShowBigLogs = false;
        panelBigLogs.gameObject.SetActive(isShowBigLogs);
        isShowLowLogs = false;
        panelLowLogs.gameObject.SetActive(isShowLowLogs);

    }

    public static void SwapActivPanelLowLogs () {
        inst.isShowLowLogs = !inst.isShowLowLogs;
        inst.panelLowLogs.gameObject.SetActive(inst.isShowLowLogs);
    }

    public static void SetActivPanelLowLogs (bool var) {
        inst.isShowLowLogs = var;
        inst.panelLowLogs.gameObject.SetActive(var);
    }

    public static void SwapActivPanelBigLogs () {
        inst.isShowBigLogs = !inst.isShowBigLogs;
        inst.panelBigLogs.gameObject.SetActive(inst.isShowBigLogs);
        if (inst.isShowBigLogs) {
            inst.DoOnShowBigLogs();
        } else {
            inst.DoOnHideBigLogs();
        }
    }

    public static void SetActivPanelBigLogs (bool var) {
        inst.isShowBigLogs = var;
        inst.panelBigLogs.gameObject.SetActive(var);
        if(inst.isShowBigLogs) {
            inst.DoOnShowBigLogs();
        } else {
            inst.DoOnHideBigLogs();
        }
    }

    public void DoOnShowBigLogs () {
        StartCoroutine(InstLogs());
        //StartCoroutine(MainUIController.inst.IEnumWaitSwapUILayer(UILayer.none, 0.1f));
    }

    public void DoOnHideBigLogs () {
        //MainUIController.inst.SetStateUI(StateUI.mapLook);
        //StartCoroutine(MainUIController.inst.IEnumWaitSwapUILayer(UILayer.clickOnMap, 0.1f));
        //CameraController.inst.SetChangeCamera();
    }

    public static void Log (string str) {
        if (inst != null) {
            inst.AddLog(str);
        }
      
    }

    private void AddLog(string str) {
        queueNewLog.Enqueue(str);
    }

    public void Update() {
        if (queueNewLog.Count != 0 && coroShowLog == null) {
            coroShowLog = StartCoroutine(IEnumAddLog(queueNewLog.Dequeue()));
        }
    }

    private IEnumerator IEnumAddLog (string str) {
        if(str.Length < maxAllLenght) {
            if(str.Length < maxLenght) {
                listStringForTextBlocks.Add("\n" + " ## " + indexAsk + " ## \n" + str + " \n  \n end");
            } else {
                var res = ChunkStr(str, maxLenght);
                for(int i = 0; i < res.Count; i++) {
                    listStringForTextBlocks.Add("\n" + " ## indexAsk = " + indexAsk + " part = " + i + " ## \n" + res[i] + " \n  \n end");
                    yield return null;
                }
            }
        }

        if(needDelLogsCount < listStringForTextBlocks.Count && !isShowBigLogs) {
            DelOldLogs();
        }

        indexAsk++;
        coroShowLog = null;
    }
    
    private IEnumerator InstLogs () {
        DelAllBlocks();
        for (int i = 0; i < listStringForTextBlocks.Count; i++) {
            var textBlock = Instantiate(textBlockPrefab);
            textBlock.transform.SetParent(parent);
            textBlock.transform.localScale = Vector3.one;
            listTextBlocks.Add(textBlock);
            textBlock.SetText("## all=" + listStringForTextBlocks.Count + "##" + listStringForTextBlocks[i], this, i);
           
        }
        yield return null;
    }

    public void DelOldLogs() {
        while (listStringForTextBlocks.Count >= needLogsCount) {
            if(listStringForTextBlocks[0] != null) {
                listStringForTextBlocks.RemoveAt(0);
            }
        }
    }

    private void DelAll () {
        DelAllBlocks();
        DelAllString();
    }

    private void DelAllBlocks () {
        for(int i = 0; i < listTextBlocks.Count; i++) {
            if(listTextBlocks[i] != null) {
                Destroy(listTextBlocks[i].gameObject);
            }
        }
        listTextBlocks.Clear();
    }

    private void DelAllString () {
        listStringForTextBlocks.Clear();
    }


    public void DelString(int i) {
        listStringForTextBlocks.RemoveAt(i);
    }

    private List<string> ChunkStr (string s1, int chunkSize) {
        string s = s1;
        int n = chunkSize;
        var lst = new List<string>();
        for(int i = 0; i + n <= s.Length; i += n) {
            lst.Add(s.Substring(i, n));
        }
        return lst;
    }

}
