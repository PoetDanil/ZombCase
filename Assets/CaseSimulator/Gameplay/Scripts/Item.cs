using System;
using UnityEngine;
using UnityEngine.UI;

namespace CaseSimulator.Gameplay
{
    public class Item : MonoBehaviour
    {
        public static Action<ItemInfo> OnItemSelected;

        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Image _mainImage;

        private ItemInfo _itemInfo;

        public RectTransform RectTransform => _rectTransform;
        public ItemInfo ItemInfo => _itemInfo;

        public void SetItem(ItemInfo itemInfo)
        {
            _itemInfo = itemInfo;
            _backgroundImage.color = itemInfo.Rarity.RarityColor;
            _mainImage.sprite = itemInfo.ItemSprite;
        }

        public void Select()
        {
            OnItemSelected?.Invoke(_itemInfo);
        }
    }
}