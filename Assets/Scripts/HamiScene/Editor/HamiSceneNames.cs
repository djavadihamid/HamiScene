using System.Collections.Generic;
using UnityEditor;

namespace HamiScene.Editor
{
    internal class HamiSceneNames
    {
        public static string[] Get(bool GetInactives = false)
        {
            List<string> scenes = new List<string>();
            string[] parts;
            string sceneName;
            foreach (var scene in EditorBuildSettings.scenes)
            {
                if (scene.enabled || GetInactives)
                {
                    parts = scene.path.Split('/');
                    sceneName = parts[parts.Length - 1];
                    scenes.Add($"{sceneName.Split('.')[0]}");
                }
            }

            return scenes.ToArray();
        }
    }
}