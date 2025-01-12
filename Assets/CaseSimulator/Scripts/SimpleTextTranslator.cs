using UnityEngine;
using UnityEngine.UI;

public class SimpleTextTranslator : MonoBehaviour
{
    [TextArea(2, 3)][SerializeField] private string _ruText;
    [TextArea(2,3)][SerializeField] private string _enText;

    private Text _text;

    #region MONO

    private void OnEnable()
    {
        LanguageChecker.OnLanguageChecked += SetText;
    }

    private void OnDisable()
    {
        LanguageChecker.OnLanguageChecked -= SetText;
    }

    #endregion

    private void Awake()
    {
        _text = GetComponent<Text>();

        SetText(LanguageChecker.GetLanguage());
    }

    private void SetText(Language language)
    {
        if (language == Language.En)
        {
            _text.text = _enText;
        }
        else
        {
            _text.text = _ruText;
        }
    }
}
