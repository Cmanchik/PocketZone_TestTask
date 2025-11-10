using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.HealtPoint
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private HealthData m_data;

        [SerializeField]
        private UnityEvent<int> m_ChangedHealth;

        [SerializeField]
        private UnityEvent m_Deathed;

        [SerializeField]
        private bool m_savedData;

        private int m_currentPoint;

        public int MaxPoint => m_data.MaxPoint;

        private void Start()
        {
            m_Deathed.AddListener(Death);

            m_currentPoint = m_data.CurrentPoint;
            m_ChangedHealth.Invoke(m_currentPoint);
        }

        public void TakeDamage(int damage)
        {
            m_currentPoint -= damage;
            m_ChangedHealth.Invoke(m_currentPoint);

            if (m_currentPoint <= 0) m_Deathed?.Invoke();

        }

        private void Death()
        {
            Destroy(gameObject);
        }

        public void SubChangingHealthEvent(UnityAction<int> action)
        {
            m_ChangedHealth.AddListener(action);
        }

        public void UnsubChangingHealthEvent(UnityAction<int> action)
        {
            m_ChangedHealth.RemoveListener(action);
        }

        private void OnDestroy()
        {
            if (m_savedData) m_data.CurrentPoint = m_currentPoint;
        }
    }
}