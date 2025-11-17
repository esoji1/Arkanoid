using UnityEngine;

namespace _Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ScreenEdgeCollidersConfig",
        menuName = "ScriptableObjects/Configs/New ScreenEdgeCollidersConfig", order = 0)]
    public class ScreenEdgeCollidersConfig : ScriptableObject
    {
        [field: SerializeField] public float ColliderDepth { get; private set; } = 1f;
        [field: SerializeField] public float Thickness { get; private set; } = 2f;
        [field: SerializeField] public bool IsTrigger { get; private set; }
        [field: SerializeField, Range(1, 4)] public int NumberColliders { get; private set; }
    }
}