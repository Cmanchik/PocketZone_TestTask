using Assets.Scripts.Movement;
using Assets.Scripts.Navigation;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class MonsterController : MonoBehaviour
    {
        [SerializeField]
        private Scanner m_pursuitScanner;

        [SerializeField]
        private Scanner m_attackScanner;

        [Space]

        [SerializeField]
        private AbstractMovement m_movementLogic;

        [SerializeField]
        private AbstractNavigation m_navigationLogic;

        // Weapon

        private void Start()
        {
            m_pursuitScanner.SubDetectedEvent(m_navigationLogic.OnFindedTarget);
            m_pursuitScanner.SubLostedEvent(m_navigationLogic.OnLostedTarget);
        }

        private void FixedUpdate()
        {
            m_movementLogic.Direction = m_navigationLogic.DirectionToTarget;
        }
    }
}