using UnityEngine;

namespace Architecture.Services.Factories.UI
{
    public interface IUIFactory
    {
        Transform UIRoot { get; }
        void CreateMainMenu();
        void CreateInGameMenu();
    }
}