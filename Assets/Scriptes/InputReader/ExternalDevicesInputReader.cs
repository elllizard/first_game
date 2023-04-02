using System;
using Core.Services.Updater;
using Player;
using UnityEngine;

namespace InputReader
{
    public class ExternalDevicesInputReader : IEntityInputSource, IDisposable

    {
        public float Direction => Input.GetAxisRaw("Horizontal");
        public bool Jump { get; private set; }

        public ExternalDevicesInputReader()
        {
            ProjectUpdater.Instance.UpdateCalled += OnUpdate;
        }
    
        public void ResetOneTimeActions()
        {
            Jump = false;
        }

        public void Dispose() => ProjectUpdater.Instance.UpdateCalled -= OnUpdate;
        
        private void OnUpdate()
        {
            if (Input.GetButtonDown("Jump"))
                Jump = true;
        }
    }
}