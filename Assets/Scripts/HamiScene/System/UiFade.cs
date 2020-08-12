using UnityEngine;

namespace HamiScene.System
{
    internal class UiFade : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup whatToFade;

        [SerializeField]
        private float duration;

        public void FadeOut()
        {
            whatToFade.gameObject.SetActive(true);
            iTween.ValueTo(whatToFade.gameObject, iTween.Hash(
                                                              "from", 0f, "to", 1f,
                                                              "time", duration,
                                                              "onupdate", "SetAlpha"
                                                             )
                          );
        }

        public void FadeIn()
        {
            iTween.ValueTo(whatToFade.gameObject, iTween.Hash(
                                                              "from", 1f,
                                                              "to", 0f,
                                                              "time", duration,
                                                              "onupdate", "SetAlpha"
                                                             )
                          );
            Timer.Register(duration + .1f, () => { whatToFade.gameObject.SetActive(false); });
        }

        private void SetAlpha(float newAlpha)
        {
            whatToFade.alpha = newAlpha;
        }
    }
}