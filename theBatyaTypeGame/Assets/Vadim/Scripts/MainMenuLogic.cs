using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    int difficulty = 0;
    public Text _difficultyText;
    public Text _soundSettingsText;
    public Button _difficultyButton;
    public Button _soundSettingsButton;
    public Button _startButton;
    public Button _exitButton;

    private bool _shouldSound;

    string[] _difficulties = { "новобранец", "смельчак", "боец" };

    private void Start()
    {
        Button btnDiff = _difficultyButton.GetComponent<Button>();
        Button btnSound = _soundSettingsButton.GetComponent<Button>();
        Button btnStart = _startButton.GetComponent<Button>();
        Button btnExit = _exitButton.GetComponent<Button>();

        btnDiff.onClick.AddListener(ChangeDifficulty);
        btnSound.onClick.AddListener(ChangeSound);
        btnStart.onClick.AddListener(StartGame);
        btnExit.onClick.AddListener(ExitGame);

        _difficultyText.text = _difficulties[difficulty];
        PlayerPrefs.SetInt("PlayerDifficulty", 0);

        _shouldSound = Mathf.Approximately(PlayerPrefs.GetFloat("Music", 0.0f), 0.0f);
    }
    public void StartGame()
    {
        //SceneTransition.SwitchToScene("MainScene");
        SceneManager.LoadScene(1);
    }

    public void ChangeSound()
    {
        _shouldSound = !_shouldSound;
        AudioManager.Instance.AdjustMusicVolume(_shouldSound);
    }

    public void ChangeDifficulty()
    {
        difficulty++;
        
        if (difficulty > 2)
        {
            difficulty = 0;
        }

        switch (difficulty)
        {
            case 0:
                _difficultyText.text = _difficulties[difficulty];
                break;
            case 1:
                _difficultyText.text = _difficulties[difficulty];
                break;
            case 2:
                _difficultyText.text = _difficulties[difficulty];
                break;
        }

        PlayerPrefs.SetInt("PlayerDifficulty", difficulty);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
