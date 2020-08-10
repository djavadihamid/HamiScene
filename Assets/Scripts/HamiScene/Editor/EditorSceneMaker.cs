using System.IO;
using System.Threading;
using UnityEditor;

namespace HamiScene.Editor
{
    [InitializeOnLoad]
    public class EditorSceneMaker : UnityEditor.Editor
    {
        static EditorSceneMaker()
        {
            if (!EditorPrefs.HasKey("SceneEnumMade")) Load();
            EditorBuildSettings.sceneListChanged += Load;
        }

        public static void Load()
        {
            string basePath = Directory.GetCurrentDirectory() + "\\Assets\\Hami\\Scene";
            string completePath = $"{basePath}\\ESceneNames.cs";
            if (!Directory.Exists(basePath)) Directory.CreateDirectory(basePath);
            if (!File.Exists(completePath)) File.Create(completePath);
            Thread.Sleep(100);
            File.WriteAllText(completePath, string.Empty);
            File.WriteAllText(completePath,
                $"public enum ESceneNames{{ None , {string.Join(",", HamiSceneNames.Get())} }}");
            if (!EditorPrefs.HasKey("SceneEnumMade")) EditorPrefs.SetBool("SceneEnumMade", true);
        }
    }
}