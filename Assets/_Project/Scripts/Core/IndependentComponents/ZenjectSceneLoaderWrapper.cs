using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Project.Core.IndependentComponents
{
    public class ZenjectSceneLoaderWrapper
    {
        private readonly ZenjectSceneLoader _zenjectSceneLoader;

        public ZenjectSceneLoaderWrapper(ZenjectSceneLoader zenjectSceneLoader) =>
            _zenjectSceneLoader = zenjectSceneLoader;

        public void Load(Action<DiContainer> action, int sceneID, LoadSceneMode mode = default) =>
            _zenjectSceneLoader.LoadScene(sceneID, mode, action);
    }
}