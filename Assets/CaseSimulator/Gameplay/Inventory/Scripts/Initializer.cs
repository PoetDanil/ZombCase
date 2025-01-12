using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CaseSimulator.Gameplay.InventorySystem
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private InventoryData _inventoryData;
        [SerializeField] private Item _itemPrefab;
        [SerializeField] private RectTransform _contentPanel;
        [SerializeField] private GridLayoutGroup _layoutGroup;
        [SerializeField] private Text _noItemsText;

        private List<ItemInfo> _items => _inventoryData.ItemInfos;
        private float _itemsCount => _items.Count; 
        private float _maxLength => _contentPanel.sizeDelta.x;
        private float _itemWidth => _layoutGroup.cellSize.x;
        private float _itemHeight => _layoutGroup.cellSize.y;
        private float _spacingX => _layoutGroup.spacing.x;
        private float _spacingY => _layoutGroup.spacing.y;


        private void OnEnable()
        {
            Initialize();
        }

        public void Initialize()
        {
            int maxLengthCount = (int)Mathf.Floor((_maxLength + _spacingX) / (_itemWidth + _spacingX));
            float height = (int)Mathf.Ceil(_itemsCount / maxLengthCount) * (_itemHeight + _spacingY) + _spacingY;
            _contentPanel.sizeDelta = new Vector2(_maxLength, height);

            for (int i = _contentPanel.childCount - 1; i >= 0; i--)
            {
                Destroy(_contentPanel.GetChild(i).gameObject);
            }

            Item newItem;

            if (_itemsCount == 0)
            {
                _noItemsText.gameObject.SetActive(true);
            }
            else
            {
                _noItemsText.gameObject.SetActive(false);
            }

            foreach (ItemInfo item in _items)
            {
                newItem = Instantiate(_itemPrefab, _contentPanel);
                newItem.SetItem(item);
            }
        }
    }
}