using CaseSimulator.Gameplay.InventorySystem;
using CaseSimulator.Gameplay.MoneySystem;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace CaseSimulator.Gameplay.SpinSystem
{
    public class WinningPanel : Sounds
    {
        public static Action OnRewardClaimed;

        [SerializeField] private Interactor _inventoryInteractor;
        [SerializeField] private GameObject _panel;
        [SerializeField] private Item _item;
        [SerializeField] private Text _costText;

        private ItemInfo _itemInfo;

        public void Show(ItemInfo itemInfo)
        {
            _panel.SetActive(true);
            _item.SetItem(itemInfo);
            _itemInfo = itemInfo;
            _costText.text = $"{itemInfo.Cost}";
        }

        public void OnApplicationQuit()
        {
            ClaimReward();
        }

        public void ClaimReward()
        {
            _inventoryInteractor.AddItem(_itemInfo);
            OnRewardClaimed?.Invoke();
        }

        public void Sell()
        {
            Bank.AddMoney(_itemInfo.Cost);
            PlaySound(sounds[0]);
            OnRewardClaimed?.Invoke();
        }

        public void Hide()
        {
            _panel.SetActive(false);
        }
    }
}