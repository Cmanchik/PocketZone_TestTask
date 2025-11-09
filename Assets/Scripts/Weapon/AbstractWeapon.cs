using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public abstract class AbstractWeapon : MonoBehaviour
    {
        [SerializeField]
        protected float m_attackDelay;

        public abstract void Attack();
    }
}