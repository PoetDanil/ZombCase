using System;
using UnityEngine;
using YG;

public class LanguageChecker : MonoBehaviour
{
    public static Action<Language> OnLanguageChecked;

    [SerializeField] private Language _editorLanguage;
    private static Language _language;

    private void Awake()
    {
        if (!Application.isEditor)
        {
            string lang = YandexGame.EnvironmentData.language;
            _language = lang == "ru" ? Language.Ru : Language.En;
        }
        else
        {
            _language = _editorLanguage;
        }

        OnLanguageChecked?.Invoke(_language);
    }

    public static Language GetLanguage()
    {
        return _language;
    }
}
