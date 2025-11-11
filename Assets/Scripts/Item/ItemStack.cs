using System;

namespace Assets.Scripts.Item
{
    [Serializable]
    public class ItemStack 
    {
        public ItemData ItemData;
        public int Count;

        public void Clear()
        {
            Count = 0;
            ItemData = null;
        }
    }
}