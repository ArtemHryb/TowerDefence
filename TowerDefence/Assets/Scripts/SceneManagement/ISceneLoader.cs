using System;

namespace SceneManagement
{
    public interface ISceneLoader
    {
        void Load(string nextScene, Action onLoaded = null);
    }
}