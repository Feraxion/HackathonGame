﻿using System.Collections.Generic;
using Game.Core.UI;
using Injection;
using UnityEngine;

namespace Game
{
    public sealed class CagesManager : Mediator<GameView>
    {
        [Inject] private GameManager _gameManager;
        
        private readonly Dictionary<AnimationUnitView, Transform> _cagesMap;

        public CagesManager()
        {
            _cagesMap = new Dictionary<AnimationUnitView, Transform>();
        }

        protected override void Show()
        {
            _gameManager.UNIT_KILLED += UnitKilled;
            _gameManager.UNIT_RESCUED += UnitRescued;
        }
        
        protected override void Hide()
        {
            _cagesMap.Clear();
            _view.CagesPool.ReleaseAllInstances();
            _gameManager.UNIT_KILLED -= UnitKilled;
            _gameManager.UNIT_RESCUED -= UnitRescued;
        }

        private void UnitKilled(AnimationUnitView unit)
        {
            var cage = _view.CagesPool.Get<Transform>();
            cage.SetParent(unit.transform);
            cage.localPosition = Vector3.zero;
            cage.localScale = Vector3.one;

            _cagesMap[unit] = cage;
        }

        private void UnitRescued(AnimationUnitView unit)
        {
            _view.CagesPool.Release(_cagesMap[unit]);
            _cagesMap.Remove(unit);
        }
    }
}