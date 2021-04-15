using System;
using Danil.Scripts.Interface;
using TMPro;
using UnityEngine;

namespace Danil.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    public class InputLetters : MonoBehaviour, IAction<bool>
    {
        public event Action<bool> OnAction = (b => { });
        [SerializeField] private LetterController _letterController;
        [SerializeField] private AudioClip _audioClipRight;
        [SerializeField] private AudioClip _audioClipWrong;
        
        private AudioSource _audioSource;
        public TMP_InputField InputField;

        private bool _updated;

        private void Start()
        {
            InputField = GetComponent<TMP_InputField>();
            _audioSource = GetComponent<AudioSource>();
            
            InputField.onEndEdit.AddListener(OnEndEdit);
            InputField.ActivateInputField();
        }

        private void Update()
        {
            if (_updated)
            {
                InputField.onEndEdit.Invoke("");
                _updated = false;
            }
            
            InputField.ActivateInputField();
        }

        private void OnEndEdit(string str)
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
            {
                InputField.text = "";
            }
            
            InputField.ActivateInputField();
        }

        public void OnAnswer(bool right)
        {
            if (right)
            {
                _audioSource.clip = _audioClipRight;
                _audioSource.Play();
            }
            else
            {
                _audioSource.clip = _audioClipWrong;
                _audioSource.Play();
            }
            
            OnAction.Invoke(right);

            _updated = true;
        }
    }
}