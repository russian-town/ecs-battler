using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
    public class LoadProgressState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;

        public LoadProgressState(
            IGameStateMachine stateMachine,
            IStaticDataService staticDataService)
        {
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            InitializeProgress();

            //_stateMachine.Enter<ActualizeProgressState>();
        }

        private void InitializeProgress()
        {
            /*if (_saveLoadService.HasSavedProgress)
                _saveLoadService.LoadProgress();
            else
                CreateNewProgress();*/
        }

        private void CreateNewProgress()
        {
            /*_saveLoadService.CreateProgress();

            CreateMetaEntity.Empty()
                .With(x => x.isStorage = true)
                .AddGold(0)
                .AddGoldPerSecond(_staticDataService.AfkGain.GoldPerSecond);*/
        }

        public void Exit() { }
    }
}
