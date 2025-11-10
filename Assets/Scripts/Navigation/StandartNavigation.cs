using UnityEngine;

namespace Assets.Scripts.Navigation
{
    public class StandartNavigation : AbstractNavigation
    {
        [SerializeField]
        private float m_stopDistance;

        private Transform m_startPoint;

        private Transform m_target;
        private Transform m_transform;

        private void Awake()
        {
            m_state = ENavigationState.Idle;
            m_transform = transform;

            m_startPoint = new GameObject("StartPoint_" + gameObject.name).transform;
            m_startPoint.position = m_transform.position;
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

            if (Vector2.Distance(m_target.position, m_transform.position) <= m_stopDistance) m_state = ENavigationState.Idle;
        }

        private void Update()
        {
            if (m_state != ENavigationState.Idle) CalculateDirectionToTarget();
        }
    }
}