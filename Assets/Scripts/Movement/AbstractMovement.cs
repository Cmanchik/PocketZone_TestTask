using UnityEngine;

namespace Assets.Scripts.Movement
{
    public abstract class AbstractMovement : MonoBehaviour
    {
        public Vector2 Direction { protected get; set; }

        [SerializeField]
        protected float m_speed;

        protected abstract void Move();

        protected virtual void FixedUpdate()
        {
            Move();
        }
    }
}