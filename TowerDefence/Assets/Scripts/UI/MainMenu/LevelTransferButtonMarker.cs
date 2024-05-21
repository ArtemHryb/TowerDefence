using Data.LevelData;
using UnityEngine;

namespace UI.MainMenu
{
    public class LevelTransferButtonMarker : MonoBehaviour
    {
        public Levels Id;
        public bool IsOpened;
        public LevelTransferButton OpenedButton;
        public GameObject ClosedButton;
    }
}