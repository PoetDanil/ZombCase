using UnityEngine;

namespace CaseSimulator.Gameplay
{

    public class CaseInfo : ScriptableObject
    {
        [SerializeField] private string _ruName;
        [SerializeField] private string _enName;
        [SerializeField] private int _cost;
        [SerializeField] private ItemInfo[] _items;
        [SerializeField] private bool _isAdCase;

        public string RuName => _ruName;
        public string EnName => _enName;
        public int Cost => _cost;
        public ItemInfo[] Items => _items;
        public bool IsAdCase => _isAdCase;
    }
}