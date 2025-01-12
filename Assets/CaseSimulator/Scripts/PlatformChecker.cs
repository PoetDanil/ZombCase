using System;
using UnityEngine;
using YG;

public class PlatformChecker : MonoBehaviour
{
    [SerializeField] private Platform _editorPlatform;
    public static Action<Platform> OnPlatformChecked;

    private void Start()
    {
        if (Application.isEditor)
        {
            SetPlatform();
        }
        else
        {
            string deviceType = YandexGame.EnvironmentData.deviceType;
            SetPlatform(deviceType);
        }
    }

    public void SetPlatform(string deviceType)
    {
        if (deviceType == "desktop")
        {
            OnPlatformChecked?.Invoke(Platform.PC);
        }
        else
        {
            OnPlatformChecked?.Invoke(Platform.Mobile);
        }
    }

    private void SetPlatform()
    {
        OnPlatformChecked?.Invoke(_editorPlatform);
    }
}
