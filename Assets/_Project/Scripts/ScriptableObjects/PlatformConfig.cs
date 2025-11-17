using UnityEngine;

namespace _Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlatformConfig",
        menuName = "ScriptableObjects/Configs/New PlatformConfig", order = 0)]
    public class PlatformConfig : ScriptableObject
    {
        [field: SerializeField] public float ImpactForceY { get; private set; } = 300f;
        [field: SerializeField] public float ImpactForceX { get; private set; } = 400f;
    }
}