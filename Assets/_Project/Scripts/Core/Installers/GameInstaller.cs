using _Project.GameFeatures.Camera;
using _Project.GameFeatures.EndOfGame;
using _Project.GameFeatures.Input;
using _Project.GameFeatures.PlatformManagement;
using _Project.GameFeatures.UI.PointsView;
using _Project.GameFeatures.UI.ResultPopup;
using _Project.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.Core.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Platform")]
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Transform _platformTransform;
        [SerializeField] private PlatformConfig _platformConfig;
        
        [Space]
        [Header("ScreenEdgeColliders")]
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private ScreenEdgeCollidersConfig _screenEdgeCollidersConfig;
        [SerializeField] private BoxCollider _deathDownWall;
        [SerializeField] private Transform _parentTransform;
        
        [Space]
        [Header("UI")]
        [Header("PointsView")]
        [SerializeField] private PointsView _pointsView;
        
        [Space]
        [Header("ResultPopup")]
        [SerializeField] private ResultPopup _resultPopup;
        
        public override void InstallBindings()
        {
            BindScreenEdgeColliders();
            BindInputController();
            BindPlatform();
            BindEndOfGameManager();
            BindUI();
        }

        private void BindInputController()
        {
            Container
                .Bind<InputController>()
                .AsSingle()
                .WithArguments(_playerInput)
                .NonLazy();
        }

        private void BindPlatform()
        {
            BindPlatformConfig();
            BindMovement();
        }

        private void BindMovement()
        {
            Container
                .BindInterfacesTo<Movement>()
                .AsSingle()
                .WithArguments(_platformTransform);
        }
        
        private void BindPlatformConfig()
        {
            Container
                .Bind<PlatformConfig>()
                .AsSingle();
        }

        private void BindScreenEdgeColliders()
        {
            Container
                .BindInterfacesTo<ScreenEdgeColliders>()
                .AsSingle()
                .WithArguments(_screenEdgeCollidersConfig, _mainCamera, _parentTransform, _deathDownWall);
        }

        private void BindEndOfGameManager()
        {
            Container
                .Bind<EndOfGameManager>()
                .AsSingle();
        }

        private void BindUI()
        {
            BindPointsView();
            BindResultPopup();
        }

        private void BindPointsView()
        {
            Container
                .Bind<PointsView>()
                .FromInstance(_pointsView)
                .AsSingle();

            Container
                .BindInterfacesTo<PointsPresenter>()
                .AsSingle();
        }

        private void BindResultPopup()
        {
            Container
                .Bind<ResultPopup>()
                .FromInstance(_resultPopup)
                .AsSingle();
            
            Container
                .BindInterfacesTo<ResultPresenter>()
                .AsSingle();
        }
    }
}