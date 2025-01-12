using UnityEngine;
using YG;

namespace CaseSimulator.Gameplay.MoneySystem
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] private string _saveName = "Money";
        [SerializeField] private Counter _counter;

        private static int Money;
        private static Counter Counter;
        private static string SaveName;

        private void Start()
        {
            Counter = _counter;
            SaveName = _saveName;
            Money = PlayerPrefs.GetInt(SaveName);
            Counter.UpdateCount(Money);
        }

        public static void AddMoney(int money)
        {
            Money += Mathf.Abs(money);
            Counter.UpdateCount(Money);
            SaveMoney();
            YandexGame.NewLeaderboardScores("BestMoney", money);
        }

        public static void RemoveMoney(int money)
        {
            Money -= Mathf.Abs(money);
            Counter.UpdateCount(Money);
            SaveMoney();
        }

        private static void SaveMoney()
        {
            PlayerPrefs.SetInt(SaveName, Money);
        }

        public static int GetMoney()
        {
            return Money;
        }
    }
}