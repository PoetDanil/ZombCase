using System.Runtime.InteropServices;
using UnityEngine;

public class OurGames : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern bool GetLang();

    [SerializeField] private Links[] _links;

    private bool _isRu;

    private void OnEnable()
    {
        if (LanguageChecker.GetLanguage() == Language.Ru)
        {
            print("RU");
            _isRu = true;
        }
        else
        {
            print("EN");
            _isRu = false;
        }
    }

    public void StartGame(int count)
    {
        if (_isRu)
        {
            Application.OpenURL(_links[count]._ruLink);
        }
        else
        {
            Application.OpenURL(_links[count]._enLink);
        }
    }
}