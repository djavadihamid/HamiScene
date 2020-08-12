using System;
using System.IO;
using HamiScene.Models;
using Newtonsoft.Json;
using UnityEditor;

namespace HamiScene.Editor
{
    internal class EditorSceneSetting : ScriptableWizard
    {
        public bool     hasFadeEffect;
        public float    fadingTime;
        public string   mainMenuScene;
        public string[] excludedScenes;

        [MenuItem("Hami/Scene/Configurations")]
        public static void ShowWindow()
        {
            DisplayWizard<EditorSceneSetting>("HamiScene configs", "", "Apply");
        }

        private void Awake()
        {
            SceneConfigModel a = HamiIO.HamiModuleJsonConfig.Read<SceneConfigModel>("HamiScene", "SceneNames");
            if (a == null) return;
            hasFadeEffect  = a.hasFadeEffect;
            fadingTime     = a.fadingTime;
            mainMenuScene  = a.mainScene;
            excludedScenes = a.excludedScenesFromBackBtn;
        }

        private void OnWizardOtherButton()
        {
            HamiIO.HamiModuleJsonConfig.Write("HamiScene", "SceneNames", new SceneConfigModel
                                                                             {
                                                                                 fadingTime                = fadingTime,
                                                                                 mainScene                 = mainMenuScene,
                                                                                 hasFadeEffect             = hasFadeEffect,
                                                                                 excludedScenesFromBackBtn = excludedScenes
                                                                             });
        }
    }
}