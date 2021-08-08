﻿using System.Collections.Generic;
using Game.Config;
using Game.Core;
using Game.Core.UI;
using Game.UI;
using Injection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.States
{
    public abstract class BaseGamePlayState : GameState
    {
        [Inject]
        protected GameManager _gameManager;
        [Inject]
        protected LevelView _levelView;
        [Inject]
        protected GameView _gameView;
        [Inject]
        protected Timer _timer;
        [Inject]
        protected GameStateManager _gameStateManager;
        [Inject]
        protected GameModel _gameModel;
        [Inject]
        protected Injector _injector;
        [Inject]
        protected GameConfig _config;

        private readonly List<Mediator> _mediators;
        protected float _startTime;

        protected BaseGamePlayState()
        {
            _mediators = new List<Mediator>();
        }

        public override void Initialize()
        {
            _gameView.GameHud.gameObject.SetActive(true);
            _startTime = Time.time + _config.GetValue(GameParam.GameStartDelayDuration);

            AddMediator(new CagesManager(), _gameView);
            AddMediator(new RescueUnitsManager(), _levelView);
            AddMediator(new CoinsManager(), _levelView);
        }

        public override void Dispose()
        {
            _gameView.GameHud.gameObject.SetActive(false);

            foreach (var mediator in _mediators)
            {
                mediator.Unmediate();
            }
            _mediators.Clear();
        }

        protected void AddMediator<T>(Mediator<T> mediator, T hud) where T : MonoBehaviour
        {
            _injector.Inject(mediator);
            mediator.Mediate(hud);

            _mediators.Add(mediator);
        }
    }
}