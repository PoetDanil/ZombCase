using CaseSimulator.Gameplay.MoneySystem;
using System;
using UnityEngine;

namespace CaseSimulator.Gameplay.CaseSystem
{
    public class CaseManager : MonoBehaviour
    {
        public static Action<CaseInfo> OnCaseSelected;

        #region MONO

        private void OnEnable()
        {
            Case.OnCaseSelected += OpenCase;
        }

        private void OnDisable()
        {
            Case.OnCaseSelected -= OpenCase;
        }

        #endregion

        private void OpenCase(CaseInfo caseInfo)
        {
            if (Bank.GetMoney() >= caseInfo.Cost)
            {
                OnCaseSelected?.Invoke(caseInfo);
            }
            else
            {
                print("NoMoney!");
            }
        }
    }
}
