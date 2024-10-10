using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Singleton;

namespace Collectables
{
    public enum ItemType
    {
        COIN,
        LIFE_PACK,
        OBJECTIVE
    }

    public class ItemManager : Singleton<ItemManager>
    {
        public List<ItemSettup> itemSettups;

        private void Start()
        {
            Reset();
            Invoke(nameof(LoadItemFromSave), .1f);
        }

        public void LoadItemFromSave()
        {
            AddByType(ItemType.COIN, SaveManager.Instance.Setup.coins);
            AddByType(ItemType.LIFE_PACK, SaveManager.Instance.Setup.lifePacks);
            AddByType(ItemType.OBJECTIVE, SaveManager.Instance.Setup.objective);       
        }

        private void Reset()
        {
            foreach (var i in itemSettups) i.soInt.value = 0;
        }

        public void AddByType(ItemType itemType,  int ammount = 1)
        {
            if (ammount < 0) return;
            itemSettups.Find(i=>i.itemType == itemType).soInt.value += ammount;
        }        
        
        public ItemSettup GetItemByType(ItemType itemType)
        {
            return itemSettups.Find(i=>i.itemType == itemType);
        }

        public void RemoveByType(ItemType itemType, int ammount = 1)
        {
            var item = itemSettups.Find(i => i.itemType == itemType);
            item.soInt.value -= ammount;

            if (item.soInt.value < 0) item.soInt.value = 0;
        }

        [NaughtyAttributes.Button]
        private void AddCoin()
        {
            AddByType(ItemType.COIN);
        }

        [NaughtyAttributes.Button]
        private void AddLifePack()
        {
            AddByType(ItemType.LIFE_PACK);
        }

    }

    [System.Serializable]
    public class ItemSettup
    {
        public ItemType itemType;
        public SOInt soInt;
        public Sprite icon;
    }
}
