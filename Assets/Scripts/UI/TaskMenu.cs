using System;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectAU.UI
{
    public class TaskMenu : MonoBehaviour
    {
        public UnityEvent TaskComplete;

        public void CompleteTask()
        {
            TaskComplete.Invoke();
            gameObject.SetActive(false);
        }
    }
}
