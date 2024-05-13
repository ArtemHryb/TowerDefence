using System.Collections.Generic;
using UnityEngine;

namespace Data.LevelData
{
    [CreateAssetMenu (fileName = "LevelData", menuName = "LevelData/LevelData")]
    public class LevelSettings : ScriptableObject
    {
       public List<LevelData> Levels;
    }
}