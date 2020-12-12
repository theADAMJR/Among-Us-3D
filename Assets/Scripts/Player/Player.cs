using ProjectAU.Environment;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

namespace ProjectAU.Player
{
    public class Player : SerializedMonoBehaviour
    {
        [SerializeField]
        public bool IsDead { get; set; }

        [SerializeField]
        public List<Task> CompletedTasks = new List<Task>();

        [SerializeField]
        public List<Task> IncompleteTasks = new List<Task>();

        private bool isImpostor = false; 
        public bool IsImpostor
        {
            get => isImpostor;
            set
            {
                isImpostor = value;
                usernameText.color = (value) ? Color.white : Color.red;
            }
        }

        [SerializeField]
        public string Username { get; set; } = "User 01";

        private TMP_Text usernameText;

        // Start is called before the first frame update
        public void Start()
        {
            usernameText = GameObject
                .Find("Username")
                ?.GetComponent<TMP_Text>();
            usernameText.enabled = true;
            usernameText.SetText(Username);

            if (IsImpostor)
            {
                var tasks = FindObjectsOfType<Task>();
                foreach (var task in tasks)
                    task.enabled = false;
            }
        }

        // Update is called once per frame
        public void Update()
        {
            
        }

        public void SetImpostor() {
            IsImpostor = true;
            usernameText.color = Color.red;
        }

        public void SetCrewmate() {
            IsImpostor = false;
            usernameText.color = Color.white;
        }
    }
}
