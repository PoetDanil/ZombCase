using UnityEngine;
using System.Collections.Generic;

namespace CaseSimulator.Gameplay.InventorySystem
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private string _itemsSaveTag;
        [SerializeField] private InventoryData _inventoryData;
        [SerializeField] private ItemInfo[] _allItems;

        public InventoryData InventoryData => _inventoryData;

        private void Awake()
        {
            if (_inventoryData == null)
            {
                return;
            }

            if (_allItems == null || _allItems.Length == 0)
            {
                return;
            }

            _inventoryData.ItemInfos.Clear();
            Load();
        }

        public void AddItem(ItemInfo itemInfo)
        {
            if (_inventoryData == null)
            {
                Debug.LogError("InventoryData is not assigned.");
                return;
            }

            _inventoryData.ItemInfos.Add(itemInfo);
            Save();
        }

        public void RemoveItem(ItemInfo itemInfo)
        {
            if (_inventoryData == null)
            {
                Debug.LogError("InventoryData is not assigned.");
                return;
            }

            if (_inventoryData.ItemInfos.Contains(itemInfo))
            {
                _inventoryData.ItemInfos.Remove(itemInfo);
            }
            Save();
        }

        private void Load()
        {
            if (_inventoryData == null)
            {
                Debug.LogError("InventoryData is not assigned.");
                return;
            }

            string saveStr = PlayerPrefs.GetString(_itemsSaveTag);
            string[] names = saveStr.Split(',');
            foreach (string name in names)
            {
                if (string.IsNullOrEmpty(name)) continue;

                foreach (ItemInfo itemInfo in _allItems)
                {
                    if (itemInfo == null) continue;

                    if (name == itemInfo.ItemName)
                    {
                        _inventoryData.ItemInfos.Add(itemInfo);
                    }
                }
            }
        }

        private void Save()
        {
            if (_inventoryData == null)
            {
                return;
            }

            string saveStr = string.Empty;

            foreach (ItemInfo item in _inventoryData.ItemInfos)
            {
                if (item == null) continue;

                saveStr += $"{item.ItemName},";
            }

            PlayerPrefs.SetString(_itemsSaveTag, saveStr);
        }
    }
}
