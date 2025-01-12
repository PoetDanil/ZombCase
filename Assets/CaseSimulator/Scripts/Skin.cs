
using CaseSimulator.Gameplay.ClickerSystem;
using CaseSimulator.Gameplay.MoneySystem;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Skin : MonoBehaviour
{
    [Header("Техические поля")]
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Clicker _clicker;
    [SerializeField] private Image _clickerImage;
    [SerializeField] private Image _skinImage;
    [SerializeField] private Text _skinPriceText;
    [SerializeField] private Text _addedClickPointsText;
    [Header("Поля, которые нужно установить")]
    [SerializeField] private SkinInfo _skinInfo;
    [SerializeField] private Skin _nextSkin;
    [SerializeField] private bool _startSkin;
    private bool _skinIsBuyed;

    public SkinInfo SkinInfo => _skinInfo;

    private void Start()
    {
        Init();
        if (YandexGame.savesData.CurrentSkin == null)
        {
            if (_startSkin)
            {
                YandexGame.savesData.CurrentSkin = _skinInfo.SkinSprite;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else if(YandexGame.savesData.CurrentSkin != _skinInfo.SkinSprite)
        {
            gameObject.SetActive(false);
            if (YandexGame.savesData.CurrentClickerSkin != null)
            {
                _clickerImage.sprite = YandexGame.savesData.CurrentClickerSkin;
            }
        }

        if (_clickerImage.sprite == null)
        {
            _clickerImage.sprite = _defaultSprite;
        }
    }

    public void Init()
    {
        _skinImage.sprite = _skinInfo.SkinSprite;
        _skinPriceText.text = _skinInfo.SkinPrice.ToString();
        _addedClickPointsText.text = _skinInfo.AddedClickPoints.ToString();
    }

    public void BuySkin()
    {
        if (!_skinIsBuyed)
        {
            if (Bank.GetMoney() >= _skinInfo.SkinPrice)
            {
                Bank.RemoveMoney(_skinInfo.SkinPrice);
                if (_clicker != null)
                {
                    _clicker.AddMultipler(_skinInfo.AddedClickPoints);
                    _clickerImage.sprite = _skinInfo.SkinSprite;
                }

                _skinIsBuyed = true;
                if (_nextSkin != null)
                {
                    _nextSkin.gameObject.SetActive(true);
                    YandexGame.savesData.CurrentSkin = _nextSkin.SkinInfo.SkinSprite;
                    YandexGame.savesData.CurrentClickerSkin = _clickerImage.sprite;
                    YandexGame.SaveProgress();
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
