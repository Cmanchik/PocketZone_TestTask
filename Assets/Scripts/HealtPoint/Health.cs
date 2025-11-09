using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.HealtPoint
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int m_maxPoint;


        [SerializeField]
        private UnityEvent<int> m_ChangedHealth;

        [SerializeField]
        private UnityEvent m_Deathed;


        private int m_currentPoint;

        public int MaxPoint => m_maxPoint;

        private void Awake()
        {
            m_currentPoint = m_maxPoint;
        }

        private void Start()
        {
            m_Deathed.AddListener(Death);
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
    }
}