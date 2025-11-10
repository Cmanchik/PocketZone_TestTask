using Assets.Scripts.Item;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Inventory
{
    public class InventoryPlayer : MonoBehaviour, IEnumerable
    {
        [SerializeField]
        private InventoryData m_arrayItems;

        [SerializeField]
        private UnityEvent<ItemStack, int> m_AddedItem;

        public ItemStack this[int index]
        {
            get
            {
                if (index < 0 || index >= m_arrayItems.Length)
                    throw new IndexOutOfRangeException();
                return m_arrayItems[index];
            }
        }

        public int Length => m_arrayItems.Length;

        public bool CanAdd { get { return m_arrayItems.Contains(null); } }

        public void Add(ItemStack itemStack)
        {
            if (CanAdd)
            {
                for (int i = 0; i < Length; i++)
                {
                    if (m_arrayItems[i].ItemData == itemStack.ItemData && m_arrayItems[i].Count < m_arrayItems[i].ItemData.MaxCountStack)
                    {
                        m_arrayItems[i].Count++;
                        m_AddedItem.Invoke(itemStack, i);
                        return;
                    }

                    if (m_arrayItems[i].ItemData == null)
                    {
                        m_arrayItems[i] = itemStack;
                        m_AddedItem.Invoke(itemStack, i);
                        return;
                    }
                }
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= m_arrayItems.Length)
                throw new IndexOutOfRangeException();

            m_arrayItems[index] = null;
        }

        public void SubAddedItemEvent(UnityAction<ItemStack, int> action)
        {
            m_AddedItem.AddListener(action);
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}