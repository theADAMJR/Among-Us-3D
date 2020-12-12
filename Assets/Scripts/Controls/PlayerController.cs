using Sirenix.OdinInspector;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace ProjectAU.Controls
{
    public class PlayerController : SerializedMonoBehaviour
    {
        [SerializeField, PropertyRange(1f, 3f)]
        public float PlayerSpeed { get; set; } = 1;

        [SerializeField]
        public bool IsAlive { get; set; }

        private Rigidbody rigidbody => GetComponent<Rigidbody>();
        private Player.Player player => GetComponent<Player.Player>();

        public void Update()
        {
            // if (player.IsDead)
            // => show as ghost

            Run();
            Rotate();
        }

        public void Run() => rigidbody.velocity = GetVelocity();
        private void Rotate() => transform.rotation = Quaternion.LookRotation(-GetVelocity());

        private Vector3 GetVelocity() {
            float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            float vertical = CrossPlatformInputManager.GetAxis("Vertical");
            float speed = PlayerSpeed * 40;

            float multiplier = 0.75f;
            bool movingDiagonally = horizontal != 0 && vertical != 0;
            return (movingDiagonally)
                ? new Vector3(horizontal * speed * multiplier, 0, vertical * speed * multiplier)
                : new Vector3(horizontal * speed, 0, vertical * speed);
        }
    }
}
