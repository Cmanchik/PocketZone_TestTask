using Assets.Scripts.HealtPoint;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.HPPanel
{
    public class HeathPointPanel : MonoBehaviour
    {
        [SerializeField]
        private Image m_hpBar;

        [SerializeField]
        private Health m_health;

        private void Awake()
        {
            m_health.SubChangingHealthEvent(OnChangeHpBar);
        }

        private void OnChangeHpBar(int hp)
        {
            m_hpBar.fillAmount = (float)hp / m_health.MaxPoint;
        }
    }
}