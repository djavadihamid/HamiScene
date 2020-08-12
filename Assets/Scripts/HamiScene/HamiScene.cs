using HamiScene.System;
using UnityEngine;

namespace HamiScene
{
    [RequireComponent(typeof(UiFade))]
    public class HamiScene : MonoBehaviour
    {
        private static HamiScene  _ins;
        private        Manager Manager;

        [SerializeField] private float       _duration;
        [SerializeField] private UiFade      _uiFade;

        [SerializeField] private string   MainMenuSceneName;
        [SerializeField] private string[] exceludedScenes;
        [SerializeField] private bool     useScreenFade;

        private void Start()
        {
            if (_ins      == null) _ins = this;
            else if (_ins != this) Destroy(_ins);

            Configs.useFader          = useScreenFade;
            Configs.excludedScenes    = exceludedScenes;
            Configs.mainMenuSceneName = MainMenuSceneName;
            Configs.Duration          = _duration;

            Manager = new Manager(this, _uiFade);
        }

         public static void Load(string sceneCSceneNameEnum)                      => _ins.Manager.LoadScene(sceneCSceneNameEnum, Configs.useFader);
        public static void Load(string sceneCSceneNameEnum, bool useScreenFader) => _ins.Manager.LoadScene(sceneCSceneNameEnum, useScreenFader);

        public static void Reload()                    => _ins.Manager.ReloadScene(Configs.useFader);
        public static void Reload(bool useScreenFader) => _ins.Manager.ReloadScene(useScreenFader);

        public static void Previous()                    => _ins.Manager.LoadPreviousScene(Configs.useFader);
        public static void Previous(bool useScreenFader) => _ins.Manager.LoadPreviousScene(useScreenFader);
    }
}