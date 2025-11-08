using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class StandartBullet : AbstractBullet
    {
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);
        }
    }
}