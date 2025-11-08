using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public abstract class AbstractWeapon : MonoBehaviour
    {
        [SerializeField]
        protected float m_reloadTime;

        //Попадание врага в зону атаки
        protected abstract void OnTriggerEnter2D(Collider2D collision);

        protected abstract void OnTriggerExit2D(Collider2D collision);

        public abstract void Attack();
    }
}