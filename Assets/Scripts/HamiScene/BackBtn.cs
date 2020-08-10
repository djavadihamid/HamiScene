using UnityEngine;

namespace HamiScene
{
    public class BackBtn : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CScene.Previous(true);
            }
        }
    }
}