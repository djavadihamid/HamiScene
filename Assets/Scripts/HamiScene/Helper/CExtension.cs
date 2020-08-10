using System;
using System.Collections;
using UnityEngine;

namespace HamiScene.Helper
{
    internal static class CExtension
    {
        internal static void C_SetTimeout(this MonoBehaviour _behaviour, float delay, Action task)
        {
            _behaviour.StartCoroutine(DoTask(task, delay));
        }

        private static IEnumerator DoTask(Action task, float delay)
        {
            yield return new WaitForSeconds(delay);
            task?.Invoke();
        }

    }
}