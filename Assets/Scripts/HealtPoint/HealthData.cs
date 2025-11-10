using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.HealtPoint
{
    [CreateAssetMenu(fileName = "NewHealthData", menuName = "Game/Health")]
    public class HealthData : ScriptableObject
    {
        [SerializeField]
        private int m_MaxPoint;

        public int MaxPoint { get { return m_MaxPoint; } }

        public int CurrentPoint; 
    }
}