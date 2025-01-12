using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace CaseSimulator.Gameplay.CaseSystem
{
    public class Case : MonoBehaviour
    {
        public static Action OnAdOpened;
        public static Action OnAdClosed;
        public static Action OnOpenCase;
        public static Action<CaseInfo> OnCaseSelected;

        [SerializeField] private CaseInfo _caseInfo;
        [SerializeField] private Text _nameText;
        [SerializeField] private Text _costText;

        private bool _rewardValid;

        private void OnEnable()
        {
            OnOpenCase += OpenCase;
            LanguageChecker.OnLanguageChecked += ChangeLang;

            if (LanguageChecker.GetLanguage() == Language.Ru)
            {
                _nameText.text = _caseInfo.RuName;
            }
            else
            {
                _nameText.text = _caseInfo.EnName;
            }

            _costText.text = $"{_caseInfo.Cost}";
        }

        private void OnDisable()
        {
            OnOpenCase -= OpenCase;
            LanguageChecker.OnLanguageChecked -= ChangeLang;
        }

        private void ChangeLang(Language language)
        {
            if (language == Language.Ru)
            {
                _nameText.text = _caseInfo.RuName;
            }
            else
            {
                _nameText.text = _caseInfo.EnName;
            }
        }

        public void OpenCase()
        {
            if (_caseInfo.IsAdCase)
            {
                //if (Application.isEditor)
                //{
                    //OnAdOpened?.Invoke();
                    //Time.timeScale = 0;
                    OnRewarded();
                    GetReward();
                //}
                //else
                //{
            
                //    OnAdOpened?.Invoke();
                //    Time.timeScale = 0;
                //}
            }
            else
            {
                OnCaseSelected?.Invoke(_caseInfo);
            }
        }

        public void OnRewarded()
        {
            _rewardValid = true;
        }

        public void GetReward()
        {
            //Time.timeScale = 1;
            //OnAdClosed?.Invoke();

            if (_rewardValid)
            {
                OnCaseSelected?.Invoke(_caseInfo);
                _rewardValid = false;
            }
        }
    }
}
