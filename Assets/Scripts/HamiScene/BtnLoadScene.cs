using UnityEngine;
using UnityEngine.EventSystems;

namespace HamiScene
{
    public class BtnLoadScene : MonoBehaviour, IPointerDownHandler
    {
        [HideInInspector] public string selectedScene;

        public void OnPointerDown(PointerEventData eventData)
        {
            CScene.Load(selectedScene);
        }
    }
}