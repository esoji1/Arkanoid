using System;
using _Project.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace _Project.GameFeatures.Camera
{
    public class ScreenEdgeColliders : IInitializable
    {
        private ScreenEdgeCollidersConfig _screenEdgeCollidersConfigs;
        private UnityEngine.Camera _orthoCamera;
        private Transform _parentTransform;
        private BoxCollider _deathDownWall;

        private BoxCollider[] _colliders;

        public ScreenEdgeColliders(ScreenEdgeCollidersConfig screenEdgeCollidersConfigs, UnityEngine.Camera orthoCamera,
            Transform parentTransform, BoxCollider deathDownWall)
        {
            _screenEdgeCollidersConfigs = screenEdgeCollidersConfigs;
            _orthoCamera = orthoCamera;
            _parentTransform = parentTransform;
            _deathDownWall = deathDownWall;
        }

        public void Initialize()
        {
            CreateColliders();
            UpdateColliders();
        }

        private void CreateColliders()
        {
            _colliders = new BoxCollider[_screenEdgeCollidersConfigs.NumberColliders];

            for (int i = 0; i < _screenEdgeCollidersConfigs.NumberColliders; i++)
            {
                GameObject colliderObject = new GameObject($"Wall ({i})");
                colliderObject.transform.SetParent(_parentTransform);
                _colliders[i] = colliderObject.AddComponent<BoxCollider>();
                _colliders[i].isTrigger = _screenEdgeCollidersConfigs.IsTrigger;
            }
        }

        private void UpdateColliders()
        {
            if (_orthoCamera == null || !_orthoCamera.orthographic)
            {
                throw new ArgumentException("Orthographic camera required!");
            }

            float screenAspect = (float)Screen.width / Screen.height;
            float cameraHeight = _orthoCamera.orthographicSize * 2;
            Vector3 cameraPosition = _orthoCamera.transform.position;

            float left = cameraPosition.x - cameraHeight * screenAspect / 2;
            float right = cameraPosition.x + cameraHeight * screenAspect / 2;
            float top = cameraPosition.y + _orthoCamera.orthographicSize;
            float bottom = cameraPosition.y - _orthoCamera.orthographicSize;

            SetCollider(_colliders[0],
                new Vector3(left - _screenEdgeCollidersConfigs.Thickness / 2, cameraPosition.y, 0f),
                new Vector3(_screenEdgeCollidersConfigs.Thickness, cameraHeight,
                    _screenEdgeCollidersConfigs.ColliderDepth));
            SetCollider(_colliders[1],
                new Vector3(right + _screenEdgeCollidersConfigs.Thickness / 2, cameraPosition.y, 0f),
                new Vector3(_screenEdgeCollidersConfigs.Thickness, cameraHeight,
                    _screenEdgeCollidersConfigs.ColliderDepth));
            SetCollider(_colliders[2],
                new Vector3(cameraPosition.x, top + _screenEdgeCollidersConfigs.Thickness / 2, 0f),
                new Vector3(cameraHeight * screenAspect, _screenEdgeCollidersConfigs.Thickness,
                    _screenEdgeCollidersConfigs.ColliderDepth));
            SetBottomCollider(_deathDownWall, cameraPosition, bottom, cameraHeight * screenAspect);
        }

        private void SetCollider(BoxCollider boxCollider, Vector3 position, Vector3 size)
        {
            boxCollider.transform.position = position;
            boxCollider.size = size;
        }

        private void SetBottomCollider(BoxCollider boxCollider, Vector3 cameraPosition, float bottom, float width)
        {
            Vector3 position = new Vector3(cameraPosition.x, 
                bottom - _screenEdgeCollidersConfigs.Thickness / 2, 0f);
            Vector3 size = new Vector3(width, _screenEdgeCollidersConfigs.Thickness,
                _screenEdgeCollidersConfigs.ColliderDepth);

            SetCollider(boxCollider, position, size);
        }
    }
}