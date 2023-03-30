using System;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Core
{
    public class GameLevelInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerEntity _playerEntity;
        [SerializeField] private GameUIInputView _gameUIInputView;

        private ExternalDevicesInputReader _externalDevices;
        private PlayerBrain _playerBrain;

        private bool _onPause;

        private void Awake()
        {
            _externalDevices = new ExternalDevicesInputReader();
            _playerBrain = new PlayerBrain(_playerEntity, new List<IEntityInputSource>
            {
                _gameUIInputView,
                _externalDevices
            });
        }

        private void Update()
        {
            if(_onPause)
                return;
            _externalDevices.OnUpdate();
        }

        private void FixedUpdate()
        {
            if (_onPause)
                return;
            _playerBrain.OnFixedUpdate();
        }
    }
}