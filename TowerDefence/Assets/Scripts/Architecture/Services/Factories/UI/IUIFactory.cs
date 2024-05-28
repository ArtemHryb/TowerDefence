using Tower.Selection;
using UnityEngine;

namespace Architecture.Services.Factories.UI
{
    public interface IUIFactory
    {
        TowerSelection TowerSelection { get; }
        Transform UIRoot { get; }
        void CreateMainMenu();
        void CreateInGameMenu();
        void CreateLoseMenu();
        void CreateVictoryMenu();
        void CreateLevelSelection();
        void CreateSettingsMenu();
    }
}