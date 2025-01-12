using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class AdManager : MonoBehaviour
{

    private void OnEnable()
    {
		  YandexGame.RewardVideoEvent += Rewarded;
    }

    // Отписываемся от события открытия рекламы в OnDisable
    private void OnDisable()
    {
		  YandexGame.RewardVideoEvent -= Rewarded;
    }

    // Подписанный метод получения награды
    void Rewarded(int id)
    {
        if(id == 0)
        {
            AudioListener.volume = 1f;
            OpenPan.OnOpenPan?.Invoke();
            CaseSimulator.Gameplay.CaseSystem.Case.OnOpenCase?.Invoke();
        }
    }

    public static void ShowRewardAd(int id)
    {
        AudioListener.volume = 0f;
        YandexGame.RewVideoShow(id);
    }
}
