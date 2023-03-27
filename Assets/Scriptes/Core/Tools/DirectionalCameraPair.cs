using System;
using System.Collections.Generic;
using Cinemachine;
using Core.Enums;
using UnityEngine;

namespace Core.Tools
{
    [Serializable]
    public class DirectionalCameraPair
    {
        [SerializeField] private CinemachineVirtualCamera _rightCamera;
        [SerializeField] private CinemachineVirtualCamera _leftCamera;

        private Dictionary<Direction, CinemachineVirtualCamera> _directionalCamera;

        public Dictionary<Direction, CinemachineVirtualCamera> DirectionalCamera
        {
            get
            {
                if (_directionalCamera != null)
                    return _directionalCamera;

                _directionalCamera = new Dictionary<Direction, CinemachineVirtualCamera>
                {
                    { Direction.Right, _rightCamera },
                    { Direction.Left, _leftCamera }
                };
                return _directionalCamera;
            }
        }
    }
}
