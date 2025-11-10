using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Joystick m_input;

        [SerializeField]
        private AbstractMovement m_movement;


        private void Update()
        {
            m_movement.Direction = m_input.Direction.normalized;
        }
    }
}