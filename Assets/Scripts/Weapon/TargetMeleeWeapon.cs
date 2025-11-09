using Assets.Scripts.HealtPoint;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class TargetMeleeWeapon : AbstractWeapon
    {
        [SerializeField]
        private int m_damage;

        [SerializeField]
        private Scanner m_targetScanner;

        private Health m_target;

        private void Start()
        {
            m_targetScanner.SubDetectedEvent((target) => target.TryGetComponent<Health>(out m_target));
            m_targetScanner.SubLostedEvent((target) => m_target = null);
        }

        public override void Attack()
        {
            if (m_target == null || !m_canAttack) return;

            m_target.TakeDamage(m_damage);

            ReloadAttack().Forget();
        }
    }
}