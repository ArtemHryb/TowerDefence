using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu (fileName = "Musics", menuName = "Create Music Holder/Holder")]
    public class MusicHolder : ScriptableObject
    {
        public List<MusicData> Musics;
    }
}