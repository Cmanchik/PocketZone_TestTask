using Assets.Scripts.Item;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    [CreateAssetMenu(fileName = "NewInventory", menuName = "Game/Inventories")]
    public class InventoryData : ScriptableObject
    {
        [SerializeField]
        private ItemStack[] m_items;

        public ItemStack this[int index]
        {
            get
            {
                if (index < 0 || index >= m_items.Length)
                    throw new IndexOutOfRangeException();
                return m_items[index];
            }
            set
            {
                if (index < 0 || index >= m_items.Length)
                    throw new IndexOutOfRangeException();

                if (value == null)
                {
                    m_items[index] = null;
                }

                m_items[index] = value;
            }
        }

        public int Length => m_items.Length;

        public bool Contains(ItemData data)
        {
            return Array.Exists(m_items, item => item.ItemData == data);
        }
    }
}