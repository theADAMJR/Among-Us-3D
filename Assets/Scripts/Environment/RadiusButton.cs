using Sirenix.OdinInspector;
using ProjectAU.Controls;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectAU.Environment
{
    public class RadiusButton : SerializedMonoBehaviour
    {
        [SerializeField]
        public Button taskButton { get; set; }

        protected bool preconditionMet = true;
        protected PlayerController playerController;
        protected Player.Player player;

        public void Start()
        {
            playerController = FindObjectOfType<PlayerController>();
            player = playerController.GetComponent<Player.Player>();
        }
        
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.tag != "Player") return;
            taskButton.gameObject.SetActive(preconditionMet);
        }
        public void OnTriggerExit(Collider collider)
        {
            if (collider.tag != "Player") return;
            taskButton.gameObject.SetActive(false);
        }
    }
}
