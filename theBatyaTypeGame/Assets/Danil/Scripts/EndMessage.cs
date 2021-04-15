using System;
using System.Collections.Generic;
using System.Linq;
using Danil.Scripts.Manager;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Danil.Scripts
{
    public class EndMessage : MonoBehaviour
    {
        [SerializeField] private Score _score;
        [SerializeField] private ScoreViewManager _scoreImage;

        private TMP_Text _text;
        private AudioSource _audioSource;
        
        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _audioSource = GetComponent<AudioSource>();
            _text.text = "";
        }

        public void ShowScore()
        {
            Time.timeScale = 0.0f;
            _audioSource.Play();
            AudioManager.Instance.AdjustMusicVolume(-80.0f);
            _text.text = "";
            
            _scoreImage.gameObject.SetActive(true);
            _scoreImage.ShowText($"Поздравляем, вы набрали {_score.ScoreCount} очков");
        }
    }
}