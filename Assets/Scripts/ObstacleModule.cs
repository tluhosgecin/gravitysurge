using UnityEngine;
using GravitySurge.Player;

namespace GravitySurge.Obstacle
{
    public class ObstacleModule : MonoBehaviour
    {
        private Vector2 Velocity = new Vector2(0f, -3f);

        [Header("Component")]
        public Rigidbody2D Rigidbody;
        
        private void Update()
        {
            /*
            **  Applies A Steady Velocity To Rigidbody.
            */
            Rigidbody.velocity = Velocity;

            /*
            **  Removes And Destroys GameObject If It Leaves The Screen.
            */
            if (transform.position.y <= -11f)
            {
                transform.parent = null;
                
                if (transform.parent == null)
                {
                    Destroy(gameObject);
                }
            }
        }

        /*
        **  Assigns GameObject Specific Properties (Parent And Position).
        */
        public void Assign(Transform parent, Vector2 position)
        {
            transform.parent   = parent;
            transform.position = position;
        }
    }
}