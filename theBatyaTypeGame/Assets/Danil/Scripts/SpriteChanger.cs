using System;
using System.Collections.Generic;
using System.Linq;
using Danil.Scripts.Scriptables;
using UnityEngine;
using UnityEngine.UI;

namespace Danil.Scripts
{
    public class SpriteChanger : MonoBehaviour
    {
        public AllTypesOfSprites Sprites;

        private Image _spriteRenderer;
        
        public int CurrentSpriteTypeNumber { get; set; }

        public int CurrentSpriteListNumber { get; set; }
        
        private void Start()
        {
            _spriteRenderer = GetComponent<Image>();
            
            _spriteRenderer.sprite = Sprites.SpriteTypes[0].AllSprites[0];
        }

        public void ChangeSprite()
        {
            _spriteRenderer.sprite = Sprites.SpriteTypes[CurrentSpriteTypeNumber].AllSprites[CurrentSpriteListNumber];
        }
    }
}