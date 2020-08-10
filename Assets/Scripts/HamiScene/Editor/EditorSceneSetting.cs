using UnityEditor;

namespace HamiScene.Editor
{
    internal class EditorSceneSetting : EditorWindow
    {
        private const string __KEY_HAS_FADER = "HamiScene_HasFadeEffect";
        private const string __KEY_TIME_FADER = "HamiScene_FaderTime";
        private const string __KEY_MAIN_SCENE = "HamiScene_MainScene";
        private const string __KEY_EXCLUDED_SCENE = "HamiScene_ExcludedScenes";
        private string[] activeScenes;

        private bool _hasFade;
        private float _faderTime;
        private int _mainMenuIndex;
        private int _excludedScenes;

        private void Awake()
        {
            activeScenes = HamiSceneNames.Get();
            _hasFade = EditorPrefs.GetBool(__KEY_HAS_FADER);
            _faderTime = EditorPrefs.GetFloat(__KEY_TIME_FADER);
            _mainMenuIndex = EditorPrefs.GetInt(__KEY_MAIN_SCENE);
            _excludedScenes = EditorPrefs.GetInt(__KEY_EXCLUDED_SCENE);
        }

        [MenuItem("Hami/Scene/Settings")]
        public static void ShowWindow()
        {
            GetWindow<EditorSceneSetting>("HamiScene Settings");
        }

        private void OnGUI()
        {
            _hasFade = EditorGUILayout.Toggle("Transition fade", _hasFade);
            _faderTime = EditorGUILayout.Slider("Fade time", _faderTime, 0, 10);
            _mainMenuIndex = EditorGUILayout.Popup("Main menu", _mainMenuIndex, activeScenes);
            _excludedScenes = EditorGUILayout.MaskField("Excluded scenes", _excludedScenes, activeScenes);
        }

        private void OnDestroy()
        {
            EditorPrefs.SetBool(__KEY_HAS_FADER, _hasFade);
            EditorPrefs.SetFloat(__KEY_TIME_FADER, _faderTime);
            EditorPrefs.SetInt(__KEY_MAIN_SCENE, _mainMenuIndex);
            EditorPrefs.SetInt(__KEY_EXCLUDED_SCENE, _excludedScenes);
        }
    }
}