using UnityEngine;
using Zenject;

namespace _Project.Core.IndependentComponents
{
    public class FPSCapRemover : IInitializable
    {
        public void Initialize()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }
    }
}