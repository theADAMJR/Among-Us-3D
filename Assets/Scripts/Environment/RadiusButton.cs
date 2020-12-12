using Sirenix.OdinInspector;
using ProjectAU.Controls;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectAU.Environment
{
    public class RadiusButton : SerializedMonoBehaviour
    {
        [SerializeField]
        public float ActivationRadius { get; set; } = 20;

        [SerializeField]
        public Button taskButton { get; set; }

        protected bool preconditionMet = true;
        protected PlayerController playerController;
        protected Player.Player player;

        // Start is called before the first frame update
        public void Start()
        {
            playerController = FindObjectOfType<PlayerController>();
            player = playerController.GetComponent<Player.Player>();
        }

        // Update is called once per frame
        public void Update()
        {
            bool withinRadius = Vector3.Distance(
                playerController.transform.position,
                transform.position
            ) <= ActivationRadius;
            taskButton.gameObject.SetActive(withinRadius && preconditionMet);
        }

    #if UNITY_EDITOR
        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, ActivationRadius);
        }
    #endif
    }
}
