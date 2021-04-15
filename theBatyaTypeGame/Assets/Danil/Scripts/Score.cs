using System;
using TMPro;
using UnityEngine;

namespace Danil.Scripts
{
    public class Score : MonoBehaviour
    {
        public int ScoreCount = 0;
        
        [SerializeField] private TimeManager _timeManager;
        [SerializeField] private InputLetters _inputLetters;
        
        private TMP_Text _text;
        private int _level;

        private void Start()
        {
            _inputLetters.OnAction += Action;
            _text = GetComponent<TMP_Text>();

            _text.text = "Счёт: 0";

            _level = AllStatic.LEVEL + 1;
        }
        
        private void Action(bool right)
        {
            if (right)
            {
                ScoreCount += 10 * _timeManager.ReduceCount * _level;
                _text.text = "Счёт: " + ScoreCount;
            }
        }
    }
}