using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Danil.Scripts
{
    public class LetterController : MonoBehaviour
    {
        [SerializeField] private InputLetters _inputLetters;
        public List<AudioClip> _audioClips;
        private List<PasteLetter> _pasteLetters;

        private int _stage = 0;
        
        private void Start()
        {
            _pasteLetters = GetComponentsInChildren<PasteLetter>().ToList();

            _inputLetters.OnAction += SetCells;
    
            for (int i = 0; i < _pasteLetters.Count; i++)
            {
                _pasteLetters[i].LetterId = i;
                _pasteLetters[i].AudioClip = _audioClips[Random.Range(0, 3)];
                _pasteLetters[i].InputLetters = _inputLetters;
                _pasteLetters[i].Initialize();
            }

            var phrase = "";
            phrase = AllStatic.DRINK;
            phrase = phrase.Replace(" ", "");
            var stageCount = 0;
            stageCount = phrase.Length;
            
            for (int i = 0; i < stageCount; i++)
            {
                var img = _pasteLetters[i].ParentImage;
                img.enabled = true;
            }

            for (int i = stageCount; i < _pasteLetters.Count; i++)
            {
                var img = _pasteLetters[i].ParentImage;
                img.enabled = false;
            }
            
            Debug.Log(_stage);
        }

        private void SetCells(bool right)
        {
            if (right)
            {
                _stage++;
                
                var stage = _stage % 3;
                
                var stageCount = 0;

                var phrase = "";
                
                if (stage == 0)
                {
                    phrase = AllStatic.DRINK;
                    phrase = phrase.Replace(" ", "");
                }

                if (stage == 1)
                {
                    phrase = AllStatic.SMOKE;
                    phrase = phrase.Replace(" ", "");
                }

                if ( stage == 2)
                {
                    phrase = AllStatic.USE;
                    phrase = phrase.Replace(" ", "");
                }
                
                stageCount = phrase.Length;
                
                for (int i = 0; i < stageCount; i++)
                {
                    var img = _pasteLetters[i].ParentImage;
                    img.enabled = true;
                }

                for (int i = stageCount; i < _pasteLetters.Count; i++)
                {
                    var img = _pasteLetters[i].ParentImage;
                    img.enabled = false;
                }
            }
        }
    }
}