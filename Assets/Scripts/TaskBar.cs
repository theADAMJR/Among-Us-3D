using UnityEngine;

namespace ProjectAU.UI
{    
    public class TaskBar : MonoBehaviour
    {
        private Player.Player player;

        public void Start()
        {
            player = FindObjectOfType<Player.Player>();
        }

        public void AddTask()
        {
            var freePanel = GetIncompletePanel();
            if (!freePanel) return; //> player wins game

            var rectTransform = freePanel.GetComponent<RectTransform>();
            int totalTasks = player.IncompleteTasks.Count + player.CompletedTasks.Count;
            Debug.Log(totalTasks);
            rectTransform.localScale = new Vector3(player.CompletedTasks.Count / totalTasks, 1, 1);
        }

        private TaskPanel GetIncompletePanel()
        {
            var panels = GetComponentsInChildren<TaskPanel>();
            foreach (var panel in panels)
            {
                var scaleX = panel.GetComponent<RectTransform>().localScale.x;
                if (scaleX < 1)
                    return panel;
            }
            return null;
        }
    }
}
