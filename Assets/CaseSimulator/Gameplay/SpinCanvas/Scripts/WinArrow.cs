using System.Collections;
using UnityEngine;

namespace CaseSimulator.Gameplay.SpinSystem
{
    public class WinArrow : MonoBehaviour
    {
        [SerializeField] private string _spinSoundTag;
        [SerializeField] private string _winSoundTag;
        [SerializeField] private float _waitBeforeClaim;
        [SerializeField] private WinningPanel _winPanel;

        private Item _item;
        private GameObject _droppedItem;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            SoundPlayer.PlayAudio(_spinSoundTag);
            _droppedItem = collision.gameObject;
        }

        public void OnWin()
        {
            SoundPlayer.PlayAudio(_winSoundTag);
            _item = _droppedItem.GetComponent<Item>();
            StartCoroutine(WaitBeforeClaim());
        }

        private IEnumerator WaitBeforeClaim()
        {
            yield return new WaitForSeconds(_waitBeforeClaim);
            _winPanel.Show(_item.ItemInfo);
        }
    }
}
