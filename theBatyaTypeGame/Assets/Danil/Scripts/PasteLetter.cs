using Danil.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(TMP_Text))]
public class PasteLetter : MonoBehaviour
{
    public Image ParentImage;
    public int LetterId;
    public AudioClip AudioClip;
    public TMP_Text Text;
    
    public InputLetters InputLetters;
    
    private AudioSource _audioSource;
    
    public void Initialize()
    {
        InputLetters.InputField.onValueChanged.AddListener(OnValueChanged);

        Text = GetComponent<TMP_Text>();
        
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnValueChanged(string str)
    {
        str = str.Replace(" ", "");

        if (str.Length == LetterId + 1)
        {
            Text.text = str[LetterId].ToString();
            _audioSource.clip = AudioClip;
            _audioSource.Play();
        }
        else
        {
            if (str.Length < LetterId + 1)
            {
                Text.text = "";
            }
        }
    }
}
