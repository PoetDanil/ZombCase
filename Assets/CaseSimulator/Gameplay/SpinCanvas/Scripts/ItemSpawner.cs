using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace CaseSimulator.Gameplay.SpinSystem
{
    public class ItemSpawner : Sounds
    {
        [SerializeField] private CaseInfo _case;
        [SerializeField] private RectTransform _spinPanel;
        [SerializeField] private Item _emptyItemPrefab;
        [Space]
        [SerializeField] private int _spawnCount;

        public CaseInfo Case { get { return _case; } }
        private HorizontalLayoutGroup _layoutGroup;
        private int _leftPadding => _layoutGroup.padding.left;
        private int _rightPadding => _layoutGroup.padding.right;
        private float _spacing => _layoutGroup.spacing;
        private List<float> _chances = new List<float>();

        private void Awake()
        {
            _layoutGroup = _spinPanel.GetComponent<HorizontalLayoutGroup>();
        }

        public void Spawn(CaseInfo caseInfo)
        {
            _case = caseInfo;

            float itemWidth = _emptyItemPrefab.RectTransform.sizeDelta.x;
            float width = itemWidth * _spawnCount + _leftPadding + _rightPadding + _spacing * (_spawnCount - 1);
            _spinPanel.sizeDelta = new Vector2(width, _spinPanel.sizeDelta.y);

            _chances.Clear();

            foreach (ItemInfo item in _case.Items)
            {
                float dropChance = item.Rarity.DropChance;
                if (!_chances.Contains(dropChance))
                {
                    _chances.Add(dropChance);
                }
            }

            _chances.Sort();

            if (_spinPanel.childCount == 0)
            {
                for (int i = 0; i < _spawnCount; i++)
                {
                    Item newItem = Instantiate(_emptyItemPrefab, _spinPanel);
                    newItem.SetItem(GenerateRandomItem());
                }
            }
            else
            {
                for (int i = 0; i < _spawnCount; i++)
                {
                    Item newItem = _spinPanel.GetChild(i).GetComponent<Item>();
                    newItem.SetItem(GenerateRandomItem());
                }
            }
        }

        private ItemInfo GenerateRandomItem()
        {
            float chance = Random.Range(0f, 100f);
            float normalizedChance = 0;
            List<ItemInfo> items = new List<ItemInfo>(); 
            
            foreach (float ch in _chances)
            {
                if (chance <= ch)
                {
                    normalizedChance = ch;
                    break;
                }
            }

            if (normalizedChance == 0)
            {
                normalizedChance = _chances.Max();
            }

            foreach (ItemInfo item in _case.Items)
            {
                if (item.Rarity.DropChance == normalizedChance)
                {
                    items.Add(item);
                }
            }

            ItemInfo itemInfo = items[Random.Range(0, items.Count)];

            return itemInfo;
        }
    }
}