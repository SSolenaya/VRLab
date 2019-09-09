#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build;

[InitializeOnLoad]
public class PreloadSigningAlias {
    static PreloadSigningAlias () {
        Init();
    }

    public static void Init () {
        PlayerSettings.Android.keystoreName = "./Assets/fiveone.keystore";
        PlayerSettings.Android.keystorePass = "08062015";

        PlayerSettings.Android.keyaliasName = "fiveone";
        PlayerSettings.Android.keyaliasPass = "08062015";
        //PlayerSettings.Android.bundleVersionCode++;
    }
}

class BuildProcessor: IPreprocessBuild {
    public int callbackOrder { get { return 0; } }
    public void OnPreprocessBuild (BuildTarget target, string path) {
        PlayerSettings.SplashScreen.showUnityLogo = false;
    }
}
#endif