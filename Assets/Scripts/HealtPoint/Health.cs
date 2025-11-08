using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.HealtPoint
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int m_point;

        [SerializeField]
        private UnityEvent<int> m_ChangedHealth;

        [SerializeField]
        private UnityEvent m_Deathed;

        private void Start()
        {
            m_Deathed.AddListener(Death);
        }

        public void TakeDamage(int damage)
        {
            m_point -= damage;
            m_ChangedHealth.Invoke(m_point);

            if (m_point <= 0) m_Deathed?.Invoke();

        }

        private void Death()
        {
            Destroy(gameObject);
        }
    }
}