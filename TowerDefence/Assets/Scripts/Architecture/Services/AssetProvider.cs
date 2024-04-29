using Architecture.Services.Interfaces;
using UnityEngine;

namespace Architecture.Services
{
    public class AssetProvider : IAssetProvider
    {
        public T Initialize<T>(string path) where T : Object =>
            Resources.Load<T>(path);
    }
}