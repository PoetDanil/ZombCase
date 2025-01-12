using System.Collections.Generic;
using UnityEngine;

namespace CaseSimulator.Gameplay
{
    public class SoundPlayer : MonoBehaviour
    {
        private static AudioSource _sourceAudio;
        private static Dictionary<string, AudioClip> _soundClips = new Dictionary<string, AudioClip>();

        private void Awake()
        {
            _sourceAudio = GetComponent<AudioSource>();
        }

        public static void RegisterSound(string tag, AudioClip clip)
        {
            if (!_soundClips.ContainsKey(tag))
            {
                _soundClips[tag] = clip;
            }
        }

        public static void PlayAudio(string soundTag)
        {
            if (_soundClips.TryGetValue(soundTag, out AudioClip clip))
            {
                _sourceAudio.PlayOneShot(clip);
            }
            else
            {
     
            }
        }
    }
}
