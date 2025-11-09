using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Utility
{
    public class Scanner : MonoBehaviour
    {
        [SerializeField]
        private LayerMask m_targetLayer;

        [SerializeField]
        private UnityEvent<GameObject> m_Detected;

        [SerializeField]
        private UnityEvent<GameObject> m_Losted;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (m_targetLayer.value != (1 << collision.gameObject.layer)) return;

            m_Detected?.Invoke(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (m_targetLayer.value != (1 << collision.gameObject.layer)) return;

            m_Losted?.Invoke(collision.gameObject);
        }


        public void SubDetectedEvent(UnityAction<GameObject> action)
        {
            m_Detected.AddListener(action);
        }

        public void UnsubDetectedEvent(UnityAction<GameObject> action)
        {
            m_Detected.RemoveListener(action);
        }


        public void SubLostedEvent(UnityAction<GameObject> action)
        {
            m_Losted.AddListener(action);
        }

        public void UnsubLostedEvent(UnityAction<GameObject> action)
        {
            m_Losted.RemoveListener(action);
        }
    }
}