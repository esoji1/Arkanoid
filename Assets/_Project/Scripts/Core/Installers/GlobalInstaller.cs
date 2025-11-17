using _Project.Core.IndependentComponents;
using _Project.Core.Services;
using Zenject;

namespace _Project.Core.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFPSCapRemover();
            BindServices();
        }

        private void BindFPSCapRemover()
        {
            Container
                .BindInterfacesTo<FPSCapRemover>()
                .AsSingle();
        }

        private void BindServices()
        {
            BindPointsService();
        }

        private void BindPointsService()
        {
            Container
                .Bind<PointsService>()
                .AsSingle();
        }
    }
}