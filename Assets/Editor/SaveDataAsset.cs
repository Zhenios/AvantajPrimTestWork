using UnityEditor;

public class SaveDataAsset {

    [MenuItem("Assets/Create/Save Data")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<SaveData>();
    }
}
