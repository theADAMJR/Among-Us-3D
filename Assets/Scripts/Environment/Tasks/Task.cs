using ProjectAU.UI;
using UnityEngine;

namespace ProjectAU.Environment
{
    public class Task : RadiusButton
    {
        [SerializeField]
        public string Name { get; set; }

        [SerializeField]
        public TaskMenu TaskMenu { get; set; }

        [SerializeField]
        public TaskMenus TaskMenus { get; set; }

        public void Start()
        {
            base.Start();
            taskButton.onClick.AddListener(Open);
        }

        public void Update()
        {
            preconditionMet = !player.IsImpostor;

            base.Update();
        }

        public void Open()
        {
            TaskMenus.gameObject.SetActive(true);
            TaskMenu.gameObject.SetActive(true);
            TaskMenu.TaskComplete.AddListener(OnTaskComplete);
        }

        public void OnTaskComplete()
        {
            player.IncompleteTasks.Remove(this);
            player.CompletedTasks.Add(this);
            TaskMenus.gameObject.SetActive(false);

            FindObjectOfType<TaskBar>().AddTask();
        }
    }
}