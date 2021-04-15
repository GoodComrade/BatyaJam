using System.Collections.Generic;
using UnityEngine;

namespace Danil.Scripts.Scriptables
{
    [CreateAssetMenu(fileName = "Sprites", menuName = "Danil/Sprites", order = 0)]
    public class Sprites : ScriptableObject
    {
        public List<Sprite> AllSprites;
    }
}