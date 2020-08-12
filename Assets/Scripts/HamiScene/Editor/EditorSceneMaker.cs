using UnityEditor;

namespace HamiScene.Editor
{
    [InitializeOnLoad]
    public class EditorSceneMaker : UnityEditor.Editor
    {
        static EditorSceneMaker()
        {
            if (!HamiIO.HamiModuleEnum.Has("HamiScene", "SceneNames")) Load();
            EditorBuildSettings.sceneListChanged += Load;
        }

        public static void Load()
        {
            HamiIO.HamiModuleEnum.Write("HamiScene",
                                        "SceneNames",
                                        HamiSceneNames.Get()
                                       );
        }
    }
}