using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Item
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Game/Items")]
    public class ItemData : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public int MaxCountStack;
    }
}