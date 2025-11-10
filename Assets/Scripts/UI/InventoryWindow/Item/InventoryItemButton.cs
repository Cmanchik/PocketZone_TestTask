using Assets.Scripts.Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.InventoryWindow.Item
{
    public class InventoryItemButton : MonoBehaviour
    {
        [SerializeField]
        private Image m_icon;

        [SerializeField]
        private TMP_Text m_count;

        [SerializeField]
        private Button m_button;


        public bool CanAdd { get { return m_itemStack.Count < m_itemStack.ItemData.MaxCountStack; } } 

        public int IndexInventoryItem { private set; get; }


        private ItemStack m_itemStack;

        public InventoryWindow InventoryWindow { private get; set; }

        private void Start()
        {
            m_button.onClick.AddListener(() => InventoryWindow.ClickItem(this));
        }

        public void SetInventory(InventoryWindow window)
        {
            InventoryWindow = window;
        }

        public void Init(ItemStack itemStack, int index)
        {
            if (itemStack.ItemData == null)
            {
                Clear(); 
                return;
            }

            m_itemStack = itemStack;
            IndexInventoryItem = index;
            m_icon.sprite = itemStack.ItemData.Icon;
            m_count.text = itemStack.Count != 1 ? itemStack.Count.ToString() : string.Empty;

            m_button.interactable = true;
        }

        public void Clear()
        {
            m_icon.sprite = null;
            m_count.text = string.Empty;
            m_itemStack = null;

            m_button.interactable = false;
        }

        public void IncreaseCount()
        {
            if (CanAdd)
            {
                m_itemStack.Count++;
                m_count.text = m_itemStack.Count.ToString();
            }  
        }

        public bool Compare(ItemData item)
        {
            return item == m_itemStack.ItemData;
        }
    }
}