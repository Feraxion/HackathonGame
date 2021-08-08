using Game.UI;
using UnityEngine;

namespace Game.States
{
    public sealed class GamePlayHideState : BaseGamePlayState
    {
        public override void Initialize()
        {
            base.Initialize();

            for (int i = 2; i < _levelView.Units.Length; i++)
            {
                _gameManager.CreateEnemy(_levelView.Units[i], true);
            }

            _gameManager.CreatePlayer(_levelView.Units[1], true);
            _gameView.CameraFollower.SetTarget(_gameManager.Player.View.gameObject);

            AddMediator(new GameHudMediator(true), _gameView.GameHud);
            AddMediator(new UnitsHolderHudMediator(true), _gameView.UnitsHolderHud);
            AddMediator(new RadarHudMediator(), _gameView.GameHud);

            AddMediator(new HearStepsManager(false), _levelView);

            _timer.ONE_SECOND_TICK += TimerOnONE_SECOND_TICK;
        }

        public override void Dispose()
        {
            base.Dispose();
            _gameView.CameraFollower.SetTarget(null);
            _timer.ONE_SECOND_TICK -= TimerOnONE_SECOND_TICK;
            _gameManager.Dispose();
        }

        private void TimerOnONE_SECOND_TICK()
        {
            if (Time.time > _startTime)
            {
                _gameManager.CreateEnemy(_levelView.Units[0], false);
                _startTime = float.MaxValue;
            }

            if (_gameManager.Player.IsDied || _gameModel.IsTimeOut)
            {
                _timer.ONE_SECOND_TICK -= TimerOnONE_SECOND_TICK;

                _gameView.GameHud.gameObject.SetActive(false);

                bool isWin = !_gameManager.Player.IsDied;

                if (isWin)
                {
                    _gameManager.Player.View.Idle();
                    _gameManager.Player.Dispose();
                }
                
                AddMediator(new EndGameHudMediator(isWin), _gameView.EndGameHud);
            }
        }
    }
}