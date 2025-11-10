using Assets.Scripts.Inventory;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Item
{
    public class ItemObject : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer m_icon;

        [SerializeField]
        private Scanner m_playerScanner;

        private ItemStack m_item;

        private void Start()
        {
            m_playerScanner.SubDetectedEvent(OnDetectedPlayer);
        }

        public void Init(ItemStack itemStack)
        {
            m_item = itemStack;
            m_icon.sprite = itemStack.ItemData.Icon;
        }
           
        private void OnDetectedPlayer(GameObject player)
        {
            if (player.TryGetComponent(out InventoryPlayer inventory) && inventory.CanAdd) AddPlayerInventory(inventory);
        }

        private void AddPlayerInventory(InventoryPlayer inventory)
        {
            inventory.Add(m_item);
            Destroy(gameObject);
        }
    }
}