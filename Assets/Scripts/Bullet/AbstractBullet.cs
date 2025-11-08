using Assets.Scripts.HealtPoint;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public abstract class AbstractBullet : MonoBehaviour
    {
        [SerializeField]
        protected int m_damage;

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.TryGetComponent<Health>(out Health target))
            {
                target.TakeDamage(m_damage);
            }

            Destroy(gameObject);
        }
    }
}