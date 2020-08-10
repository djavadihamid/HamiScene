using System.Collections.Generic;
using System.Linq;
using HamiScene.Helper;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HamiScene.System
{
    internal class Manager
    {
        private MonoBehaviour Mono;
        private UiFade        uiFade;

        private Stack<string> _previousSceneName = new Stack<string>();
        private string        _previousItem;

        public Manager(MonoBehaviour mono, UiFade uiFade)
        {
            Mono        = mono;
            this.uiFade = uiFade;
        }

        public void LoadScene(string toGo, bool useScreenFader = false)
        {
            if (toGo != _previousItem)
            {
                if (!Configs.excludedScenes.Contains(SceneManager.GetActiveScene().name))
                {
                    _previousSceneName.Push(SceneManager.GetActiveScene().name);
                    _previousItem = toGo;
                }
            }

            if (useScreenFader) FadingLoad(toGo);
            else SceneManager.LoadScene(toGo);
        }

        public void ReloadScene(bool useScreenFader) => LoadScene(SceneManager.GetActiveScene().name, useScreenFader);

        public void LoadPreviousScene(bool useScreenFader)
        {
            if (SceneManager.GetActiveScene().name == Configs.mainMenuSceneName)
            {
                _previousSceneName.Clear();
                Application.Quit();
                return;
            }

            string sceneToGo;
            if (_previousSceneName.Count == 0) sceneToGo = Configs.mainMenuSceneName;
            else sceneToGo                               = _previousSceneName.Pop();

            if (useScreenFader) FadingLoad(sceneToGo);
            else SceneManager.LoadScene(sceneToGo);
        }

        private void FadingLoad(string sceneName)
        {
            uiFade.FadeOut();
            Mono.C_SetTimeout(Configs.Duration, () =>
                {
                    SceneManager.LoadScene(sceneName);
                    Mono.C_SetTimeout(Configs.Duration, () => uiFade.FadeIn());
                }
            );
        }
    }
}