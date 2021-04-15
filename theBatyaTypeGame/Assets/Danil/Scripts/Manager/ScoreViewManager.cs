using TMPro;
using UnityEngine;

namespace Danil.Scripts.Manager
{
    public class ScoreViewManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void ShowText(string str)
        {
            _text.text = str;
        }
    }
}