using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public abstract class AbstractWeapon : MonoBehaviour
    {
        [SerializeField]
        protected float m_attackDelay;

        protected bool m_canAttack = true;

        public abstract void Attack();

        protected virtual async UniTaskVoid ReloadAttack()
        {
            m_canAttack = false;

            await UniTask.WaitForSeconds(m_attackDelay);

            m_canAttack = true;
        }
    }
}