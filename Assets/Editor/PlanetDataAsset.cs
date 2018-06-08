using UnityEditor;

public class PlanetDataAsset
{
    [MenuItem("Assets/Create/Planet Data")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<PlanetData>();
    }
}