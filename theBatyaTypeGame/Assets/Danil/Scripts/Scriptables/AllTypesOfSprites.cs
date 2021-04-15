using System.Collections.Generic;
using UnityEngine;

namespace Danil.Scripts.Scriptables
{
    [CreateAssetMenu(fileName = "AllTypes", menuName = "Danil/AllTypes", order = 0)]
    public class AllTypesOfSprites : ScriptableObject
    {
        public List<Sprites> SpriteTypes;
    }
}