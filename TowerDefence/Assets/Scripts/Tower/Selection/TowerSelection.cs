using System.Collections.Generic;
using UnityEngine;

namespace Tower.Selection
{
    public class TowerSelection : MonoBehaviour
    {
        public List<TowerSelectionButtonHolder> Buttons { get; set; } = new();
        public TowerSelectionButtonHolder SelectedButton { get; private set; }

        public void ChangeSelection(TowerSelectionButtonHolder button) =>
            SelectedButton = button;
    }
}