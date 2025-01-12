using UnityEngine;
using UnityEngine.UI;

namespace CaseSimulator.Gameplay.MoneySystem
{
    public class Counter : MonoBehaviour
    {
        private Text _text;

        #region MONO

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        #endregion 

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        public void UpdateCount(int moneyCount)
        {
            _text.text = moneyCount.ToString();
        }
    }
}