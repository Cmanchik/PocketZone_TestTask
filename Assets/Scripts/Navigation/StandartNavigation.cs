using UnityEngine;

namespace Assets.Scripts.Navigation
{
    public class StandartNavigation : AbstractNavigation
    {
        [SerializeField]
        private Transform m_startPoint;

        private Transform m_target;
        private Transform m_transform;

        private void Awake()
        {
            m_state = ENavigationState.Idle;
            m_transform = transform;
        }

        public override void OnFindedTarget(GameObject target)
        {
            m_target = target.GetComponent<Transform>();
            m_state = ENavigationState.Persecution;
        }

        public override void OnLostedTarget(GameObject target)
        {
            m_target = m_startPoint;
        }

        private void CalculateDirectionToTarget()
        {
            if (m_target == null)
            {
                m_target = m_startPoint;
                m_state = ENavigationState.Return;
                return;
            }
            
            DirectionToTarget = (m_target.position - m_transform.position).normalized;

            if (DirectionToTarget == Vector2.zero) m_state = ENavigationState.Idle;
        }

        private void Update()
        {
            if (m_state != ENavigationState.Idle) CalculateDirectionToTarget();
        }
    }
}