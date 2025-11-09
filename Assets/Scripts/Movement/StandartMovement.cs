using UnityEngine;

namespace Assets.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class StandartMovement : AbstractMovement
    {
        [SerializeField]
        private Transform m_rotatableObject;

        private Rigidbody2D m_rb;

        private void Start()
        {
            m_rb = GetComponent<Rigidbody2D>();
        }

        protected override void Move()
        {
            m_rb.velocity = Direction * m_speed;
            Rotate();
        }

        private void Rotate()
        {
            if (Direction.x > 0) m_rotatableObject.rotation = Quaternion.Euler(0, 0, 0);
            else if (Direction.x < 0) m_rotatableObject.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}