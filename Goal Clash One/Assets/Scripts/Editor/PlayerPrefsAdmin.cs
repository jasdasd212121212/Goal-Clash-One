using UnityEditor;
using UnityEngine;

public class PlayerPrefsAdmin : EditorWindow
{
    private string _key;

    [MenuItem("PlayerPrefs/Reseter")]
    public static void Open()
    {
        GetWindow<PlayerPrefsAdmin>();
    }

    private void OnGUI()
    {
        _key = EditorGUILayout.TextField(_key);

        if (GUILayout.Button("Reset"))
        {
            PlayerPrefs.DeleteKey(_key);
        }
    }
}