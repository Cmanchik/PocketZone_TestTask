using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class StandartMovement : AbstractMovement
    {
        private Rigidbody2D m_rb;

        private void Start()
        {
            m_rb = GetComponent<Rigidbody2D>();
        }

        protected override void Move()
        {
            m_rb.velocity = Direction * m_speed;
        }
    }
}