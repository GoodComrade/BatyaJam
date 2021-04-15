using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Danil.Scripts;
using System.Data;
using System.Linq;
using Random = UnityEngine.Random;

public class InputConditionManager : MonoBehaviour
{
    [SerializeField] private PhraseOutput _phraseOutput;
    [SerializeField] private InputLetters _inputLetters;

    private string _phraseToCheck;
    private int _level = 0;
    private int _phrasePreparation;
    
    private void Start()
    {
        Screen.SetResolution(1024, 768, FullScreenMode.FullScreenWindow);
        
        _inputLetters.InputField.onValueChanged.AddListener(OnValueChanged);

        _level = AllStatic.LEVEL;
        
        PrepareText(_phrasePreparation);
    }

    private void PrepareText(int index)
    {
        if (index == 0)
        {
            _phraseToCheck = AllStatic.DRINK;
        }
        if (index == 1)
        {
            _phraseToCheck = AllStatic.SMOKE;
        }
        if (index == 2)
        {
            _phraseToCheck = AllStatic.USE;
        }

        _phraseToCheck.ToLower();
        
        SetPhrase();
    }

    private void SetPhrase()
    {
        var phrase = _phraseToCheck;
        var charStr = _phraseToCheck.Distinct().ToList();
        charStr.RemoveAll(c => c == ' ');
        
        var wordsToAdd = "";
        
        if (_level == 0)
        {
            var randChar = charStr[Random.Range(0, charStr.Count)];
            
            var alpha = AllStatic.ALPHABET;
            alpha.RemoveAll(c => c == randChar);
            
            var randCharToReplace = alpha[Random.Range(0, alpha.Count)];

            wordsToAdd = $", где \"{randChar}\" это \"{randCharToReplace}\"";

            _phraseToCheck = _phraseToCheck.Replace(randChar, randCharToReplace);
        }

        if (_level == 1)
        {
            var randChar1 = charStr[Random.Range(0, charStr.Count)];
            charStr.RemoveAll(c => c == randChar1);
            var randChar2 = charStr[Random.Range(0, charStr.Count)];
            
            var alpha = AllStatic.ALPHABET;
            alpha.RemoveAll(c => c == randChar1 || c == randChar2);
            var randCharToReplace1 = alpha[Random.Range(0, alpha.Count)];
            alpha.RemoveAll(c => c == randCharToReplace1);
            var randCharToReplace2 = alpha[Random.Range(0, alpha.Count)];
            
            wordsToAdd = $", где \"{randChar1}\" это \"{randCharToReplace1}\" и \"{randChar2}\" это \"{randCharToReplace2}\"";
            
            _phraseToCheck = _phraseToCheck.Replace(randChar1, randCharToReplace1);
            _phraseToCheck = _phraseToCheck.Replace(randChar2, randCharToReplace2);
            
            Debug.Log(_phraseToCheck + " " + randChar1 + " " + randChar2);
        }

        if (_level == 2)
        {
            var randChar1 = charStr[Random.Range(0, charStr.Count)];
            charStr.RemoveAll(c => c == randChar1);
            var randChar2 = charStr[Random.Range(0, charStr.Count)];
            charStr.RemoveAll(c => c == randChar2);
            var randChar3 = charStr[Random.Range(0, charStr.Count)];
            
            var alpha = AllStatic.ALPHABET;
            alpha.RemoveAll(c => c == randChar1 || c == randChar2 || c == randChar3);
            var randCharToReplace1 = alpha[Random.Range(0, alpha.Count)];
            alpha.RemoveAll(c => c == randCharToReplace1);
            var randCharToReplace2 = alpha[Random.Range(0, alpha.Count)];
            alpha.RemoveAll(c => c == randCharToReplace2);
            var randCharToReplace3 = alpha[Random.Range(0, alpha.Count)];
            alpha.RemoveAll(c => c == randCharToReplace3);
            
            wordsToAdd = $", где \"{randChar1}\" это \"{randCharToReplace1}\" " +
                         $"и \"{randChar2}\" это \"{randCharToReplace2}\"  и \"{randChar3}\" это \"{randCharToReplace3}\"";
            
            _phraseToCheck = _phraseToCheck.Replace(randChar1, randCharToReplace1);
            _phraseToCheck = _phraseToCheck.Replace(randChar2, randCharToReplace2);
            _phraseToCheck = _phraseToCheck.Replace(randChar3, randCharToReplace3);
            
            Debug.Log(_phraseToCheck + " " + randChar1 + " " + randChar2 + " " + randChar3);
        }
        
        _phraseOutput.ChangePhrase(phrase + wordsToAdd);
        _phraseToCheck = _phraseToCheck.Replace(" ", "");
        
        Debug.Log(_phraseToCheck);
    }

    private void OnValueChanged(string str)
    {
        str = str.Replace(" ", "").ToLower();
        Debug.Log(_phraseToCheck + " " + str);
        
        if (_phraseToCheck.StartsWith(str))
        {
            if (str.Length == _phraseToCheck.Length)
            {
                _inputLetters.OnAnswer(true);
                _phrasePreparation++;
                PrepareText(_phrasePreparation % 3);
            }
        }
        else
        {
            _inputLetters.OnAnswer(false);
        }
    }
}
