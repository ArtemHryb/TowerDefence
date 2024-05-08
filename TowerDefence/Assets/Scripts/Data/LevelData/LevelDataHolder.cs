using System.Collections.Generic;
using UnityEngine;

namespace Data.LevelData
{
    [CreateAssetMenu (fileName = "LevelData", menuName = "LevelData/LevelData")]
    public class LevelDataHolder : ScriptableObject
    {
       public List<LevelData> Levels;
    }
}