using CaseSimulator.Gameplay.CaseSystem;
using UnityEngine;

namespace CaseSimulator.Gameplay
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip _musicClip;
        private AudioSource _sourceAudio;

        private void OnEnable()
        {
            /*Adv.OnAdShowed += StopMusic;
            Adv.OnAdFinished += ResumeMusic;
            Case.OnAdOpened += StopMusic;
            Case.OnAdClosed += ResumeMusic;*/
        }

        private void OnDisable()
        {
            /*Adv.OnAdShowed -= StopMusic;
            Adv.OnAdFinished -= ResumeMusic;
            Case.OnAdOpened -= StopMusic;
            Case.OnAdClosed -= ResumeMusic;*/
        }

        private void Awake()
        {
            _sourceAudio = GetComponent<AudioSource>();
            if (_musicClip != null)
            {
                _sourceAudio.clip = _musicClip;
                if (Application.isEditor)
                {
                    print("Music Started");
                    _sourceAudio.Play();
                }
            }
            else
            {
        
            }
        }

        private void StopMusic()
        {
            print("Music Stopped");
            _sourceAudio.Stop();
        }

        private void ResumeMusic()
        {
            print("Music Resumed");
            if (_musicClip != null)
            {
                _sourceAudio.clip = _musicClip;
                _sourceAudio.Play();
            }
            else
            {
            }
        }
    }
}
