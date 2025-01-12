using System.Collections.Generic;
using UnityEngine;

namespace CaseSimulator.Gameplay.InventorySystem
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "Gameplay/Inventory Data")]
    public class InventoryData : ScriptableObject
    {
        public List<ItemInfo> ItemInfos = new List<ItemInfo>();
    }
}