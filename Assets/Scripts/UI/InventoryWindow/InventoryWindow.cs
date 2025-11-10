using Assets.Scripts.Inventory;
using Assets.Scripts.Item;
using Assets.Scripts.UI.InventoryWindow.Item;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI.InventoryWindow
{
    public class InventoryWindow : MonoBehaviour
    {
        [SerializeField]
        private InventoryPlayer m_inventoryLogic;

        [SerializeField]
        private InventoryItemButton[] m_itemButtons;

        [SerializeField]
        private RectTransform m_deleteItemButton;

        private InventoryItemButton m_selectedItem;

        private void Start()
        {
            m_inventoryLogic.SubAddedItemEvent(OnAddedItem);
            m_deleteItemButton.GetComponent<Button>().onClick.AddListener(DeleteItem);

            foreach (var item in m_itemButtons)
            {
                item.SetInventory(this);
            }
        }

        public void ClickItem(InventoryItemButton item)
        {
            if (m_selectedItem == null)
            {
                m_selectedItem = item;
                m_deleteItemButton.gameObject.SetActive(true);
                m_deleteItemButton.position = item.GetComponent<RectTransform>().position;
            }
            else
            {
                m_selectedItem = null;
                m_deleteItemButton.gameObject.SetActive(false);
            }
            
        }

        private void UpdateView()
        {
            for (int i = 0; i < m_inventoryLogic.Length; i++)
            {
                m_itemButtons[i].Init(m_inventoryLogic[i], i);
            }
        }

        private void DeleteItem()
        {
            m_inventoryLogic.Remove(m_selectedItem.IndexInventoryItem);
            m_selectedItem.Clear();
            m_selectedItem = null;
            m_deleteItemButton.gameObject.SetActive(false);
        }

        private void OnAddedItem(ItemStack newItem, int index)
        {
            if (m_itemButtons[index].Compare(newItem.ItemData)) m_itemButtons[index].IncreaseCount();
            else m_itemButtons[index].Init(newItem, index);
        }

        private void OnEnable()
        {
            UpdateView();
        }
    }
}