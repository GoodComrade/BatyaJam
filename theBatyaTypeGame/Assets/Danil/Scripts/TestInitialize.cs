using Manager;
using UnityEngine;
using UnityEngine.Audio;

namespace Danil.Scripts
{
    public class TestInitialize : MonoBehaviour
    {
        private void Awake()
        {
            AllStatic.LEVEL = PlayerPrefs.GetInt("PlayerDifficulty", 0);
            Screen.SetResolution(1024, 768, FullScreenMode.FullScreenWindow);

            Time.timeScale = 1.0f;

            //if (Mathf.Approximately(PlayerPrefs.GetFloat("Music", 0), 0.0f))
            //{
            //    AudioManager.Instance.AdjustMusicVolume(true);
            //}
            //else
            //{
            //    AudioManager.Instance.AdjustMusicVolume(false);
            //}
        }
    }
}