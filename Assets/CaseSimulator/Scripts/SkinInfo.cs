
using UnityEngine;
[CreateAssetMenu(fileName = "Skin", menuName = "Skins/New Skin")]
public class SkinInfo : ScriptableObject
{
    [SerializeField] private int _addedClickPoints;
    [SerializeField] private int _skinPrice;
    [SerializeField] private Sprite _skinSprite;

    public int AddedClickPoints => _addedClickPoints;
    public int SkinPrice => _skinPrice;
    public Sprite SkinSprite => _skinSprite;
}
