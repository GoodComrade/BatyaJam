using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Manager
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;

        public static AudioManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            AdjustMusicVolume(GetMusicVolume());
        }

        public void AdjustMusicVolume(float volume)
        {
            if (!Mathf.Approximately(PlayerPrefs.GetFloat("Music"), -80.0f))
            {
                _audioMixer.SetFloat("Music", volume);
            }
        }

        public void AdjustMusicVolume(bool shouldSound)
        {
            if (shouldSound)
            {
                _audioMixer.SetFloat("Music", 0.0f);
                PlayerPrefs.SetFloat("Music", 0.0f);
            }
            else
            {
                PlayerPrefs.SetFloat("Music", -80.0f);
                _audioMixer.SetFloat("Music", -80.0f);
            }
        }

        public bool GetMusicVolumeBool()
        {
            Debug.Log(PlayerPrefs.GetFloat("Music"));
            return Mathf.Approximately(PlayerPrefs.GetFloat("Music"), 0.0f);
        }

        public float GetMusicVolume()
        {
            return PlayerPrefs.GetFloat("Music");
        }
    }
}