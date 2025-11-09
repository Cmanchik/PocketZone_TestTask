using Assets.Scripts.Movement;
using Assets.Scripts.Navigation;
using Assets.Scripts.Utility;
using Assets.Scripts.Weapon;
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

        [Space]

        [SerializeField]
        private AbstractWeapon m_weaponLogic;

        private void Start()
        {
            m_pursuitScanner.SubDetectedEvent(m_navigationLogic.OnFindedTarget);
            m_pursuitScanner.SubLostedEvent(m_navigationLogic.OnLostedTarget);

            m_attackScanner.SubDetectedEvent((target) => m_weaponLogic.Attack());
            m_attackScanner.SubStayedEvent((target) => m_weaponLogic.Attack());
        }

        private void FixedUpdate()
        {
            m_movementLogic.Direction = m_navigationLogic.DirectionToTarget;
        }
    }
}