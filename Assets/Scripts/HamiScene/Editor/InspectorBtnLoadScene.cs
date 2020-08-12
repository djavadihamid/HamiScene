using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace HamiScene.Editor
{
    [CustomEditor(typeof(BtnLoadScene))]
    public class InspectorBtnLoadScene : UnityEditor.Editor
    {
        private string[] sceneList;
        private int _choiceIndex;
        private BtnLoadScene _btnLoadScene;

        private void Awake()
        {
            sceneList = HamiSceneNames.Get();
            _btnLoadScene = target as BtnLoadScene;

            for (int i = 0; i < sceneList.Length; i++)
            {
                if (sceneList[i] == _btnLoadScene.selectedScene)
                {
                    _choiceIndex = i;
                }
            }
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            _choiceIndex = EditorGUILayout.Popup(_choiceIndex, sceneList);
            if (GUI.changed)
            {
                _btnLoadScene.selectedScene = sceneList[_choiceIndex];
                EditorUtility.SetDirty(target);
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            }
        }
    }
}