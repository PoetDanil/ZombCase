using UnityEngine;

namespace CaseSimulator.Gameplay
{
    public class Rarity : ScriptableObject
    {
        [SerializeField] private string _rarityName;
        [Range(0,100)][SerializeField] private float _dropChance;
        [SerializeField] private Color _rarityColor;

        public string RarityName => _rarityName;
        public float DropChance => _dropChance;
        public Color RarityColor => _rarityColor;
    }
}