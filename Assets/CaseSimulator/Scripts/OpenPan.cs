using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class OpenPan : MonoBehaviour
{
    public GameObject pan;
    public static Action OnOpenPan;

    public void OpenPanCase()
    {
        AdManager.ShowRewardAd(0);
    }

    public void SwitchOnPan()
    {
        pan.SetActive(true);
    }

    public void OnEnable()
    {
        OnOpenPan += SwitchOnPan;
    }

    public void OnDisable()
    {
        OnOpenPan -= SwitchOnPan;
    }

}
