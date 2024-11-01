using Code.Gameplay.StaticData;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            BindStateMachine();
            BindStateFactory();
            BindGameStates();
            
            BindContexts();
            
            BindGameplayServices();
            BindGameplayFactories();
            
            BindSystemFactory();

            BindInfrastructureServices();
            BindAssetManagementServices();
        }

        private void BindStateMachine() =>
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

        private void BindStateFactory() =>
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();

        private void BindGameStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleLoopState>().AsSingle();
        }

        private void BindContexts()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
      
            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
            Container.Bind<InputContext>().FromInstance(Contexts.sharedInstance.input).AsSingle();
            Container.Bind<MetaContext>().FromInstance(Contexts.sharedInstance.meta).AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        }

        private void BindGameplayFactories() { }
        
        private void BindSystemFactory() =>
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
        
        private void BindInfrastructureServices()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
        }
        
        private void BindAssetManagementServices() =>
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();

        public void Initialize() =>
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
    }
}
