using UnityEngine;

namespace CaseSimulator.Gameplay
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip spinSound;
        [SerializeField] private AudioClip winSound;

        private void Awake()
        {
            SoundPlayer.RegisterSound("spin", spinSound);
            SoundPlayer.RegisterSound("win", winSound);
        }
    }
}
