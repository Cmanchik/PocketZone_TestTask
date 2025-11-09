using UnityEngine;

namespace Assets.Scripts.Navigation
{
    public abstract class AbstractNavigation : MonoBehaviour
    {
        public Vector2 DirectionToTarget { get; protected set; }

        protected ENavigationState m_state;

        public abstract void OnFindedTarget(GameObject target);

        public abstract void OnLostedTarget(GameObject target);

    }
}