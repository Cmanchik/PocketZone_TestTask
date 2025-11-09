using Assets.Scripts.Movement;
using Assets.Scripts.Utility;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class FireWeapon : AbstractWeapon
    {
        [SerializeField]
        private AbstractMovement m_bulletPrefab;

        [SerializeField]
        private Transform m_gunPoint;

        [SerializeField]
        private Scanner m_enemyScanner;


        private List<Transform> m_targets;
        private bool m_canAttack = true;

        private void Awake()
        {
            m_targets = new List<Transform>();
        }

        private void Start()
        {
            m_enemyScanner.SubDetectedEvent((enemy) => m_targets.Add(enemy.GetComponent<Transform>()));
            m_enemyScanner.UnsubLostedEvent((enemy) => m_targets.Remove(enemy.GetComponent<Transform>()));
        }

        public override void Attack()
        {
            if (m_targets.Count == 0 || !m_canAttack) return;

            Transform target = GetNearestTarget();

            Vector2 direction = (target.position - m_gunPoint.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            AbstractMovement bullet = Instantiate(m_bulletPrefab, m_gunPoint.position, Quaternion.Euler(0, 0, angle - 90));
            bullet.Direction = direction;

            Reload().Forget();
        }

        private async UniTaskVoid Reload()
        {
            m_canAttack = false;

            await UniTask.WaitForSeconds(m_attackDelay);

            m_canAttack = true;
        }

        private Transform GetNearestTarget()
        {
            m_targets.RemoveAll(t => t == null);
            if (m_targets.Count == 0) return null;

            return m_targets.OrderByDescending(t => Vector2.Distance(t.position, m_gunPoint.position)).First();
        }
    }
}