using Assets.Scripts.Item;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class InventoryMonster : MonoBehaviour
    {
        [SerializeField]
        private InventoryData m_items;

        [SerializeField]
        private ItemObject m_itemObject;

        public void DropRandomItem()
        {
            ItemObject item = Instantiate(m_itemObject, transform.position, Quaternion.identity);
            item.Init(m_items[Random.Range(0, m_items.Length)]);
        }
    }
}