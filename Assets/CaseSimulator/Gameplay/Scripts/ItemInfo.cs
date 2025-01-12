using UnityEngine;

namespace CaseSimulator.Gameplay
{
    public class ItemInfo : ScriptableObject
    {
        [SerializeField] private string _itemName;
        [SerializeField] private int _cost;
        [SerializeField] private Sprite _itemSprite;
        [SerializeField] private Rarity _rarity;
        
        public string ItemName => _itemName;
        public int Cost => _cost;
        public Sprite ItemSprite => _itemSprite;
        public Rarity Rarity => _rarity;
    }
}