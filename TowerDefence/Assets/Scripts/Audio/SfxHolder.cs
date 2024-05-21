using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu (fileName = "SoundEffects", menuName = "Create Sound Effects Holder/Holder")]
    public class SfxHolder : ScriptableObject
    {
        public List<SfxData> SoundEffects;
    }
}