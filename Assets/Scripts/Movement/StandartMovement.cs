using UnityEngine;

namespace Assets.Scripts.Movement
{
    
    public class StandartMovement : LinearMovement
    {
        [SerializeField]
        private Transform m_rotatableObject;

        private void Start()
        {
            m_rb = GetComponent<Rigidbody2D>();
        }

        protected override void Move()
        {
            base.Move();
            Rotate();
        }

        private void Rotate()
        {
            if (Direction.x > 0) m_rotatableObject.rotation = Quaternion.Euler(0, 0, 0);
            else if (Direction.x < 0) m_rotatableObject.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}