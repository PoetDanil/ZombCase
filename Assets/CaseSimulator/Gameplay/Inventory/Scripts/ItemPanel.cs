using CaseSimulator.Gameplay.MoneySystem;
using UnityEngine;
using UnityEngine.UI;

namespace CaseSimulator.Gameplay.InventorySystem
{
    public class ItemPanel : Sounds
    {
        [SerializeField] private Initializer _initializer;
        [SerializeField] private Interactor _interactor;
        [SerializeField] private GameObject _panel;
        [SerializeField] private Item _item;
        [SerializeField] private Text _costText;

        #region MONO

        private void OnEnable()
        {
            Item.OnItemSelected += Show;
        }

        private void OnDisable()
        {
            Item.OnItemSelected -= Show;
        }

        #endregion

        private void Show(ItemInfo itemInfo)
        {
            _costText.text = $"{itemInfo.Cost}";
            _panel.SetActive(true);
            _item.SetItem(itemInfo);

            PlaySound(sounds[1]);
        }

        public void Hide() 
        {
            _panel.SetActive(false);
            PlaySound(sounds[2]);
        }

        public void Sell()
        {
            Bank.AddMoney(_item.ItemInfo.Cost);
            _panel.SetActive(false);
            _interactor.RemoveItem(_item.ItemInfo);
            _initializer.Initialize();

            PlaySound(sounds[0]);
        }
    }
}