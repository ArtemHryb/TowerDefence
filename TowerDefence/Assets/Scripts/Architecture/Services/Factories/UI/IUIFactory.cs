using Tower.Selection;
using UI.InGame.Pause;
using UnityEngine;

namespace Architecture.Services.Factories.UI
{
    public interface IUIFactory
    {
        TowerSelection TowerSelection { get; }
        Transform UIRoot { get; }
        PauseMenu PauseMenu { get; }
        void CreateMainMenu();
        void CreateInGameMenu();
        void CreateLoseMenu();
        void CreateVictoryMenu();
        void CreateLevelSelection();
        void CreateSettingsMenu();
        void CreatePauseMenu();
    }
}