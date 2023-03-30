using UnityEngine;

namespace Player
{
    public class ExternalDevicesInputReader : IEntityInputSource

    {
        public float Direction => Input.GetAxisRaw("Horizontal");
        public bool Jump { get; private set; }
    
        public void OnUpdate()
        {
            if (Input.GetButtonDown("Jump"))
                Jump = true;
        }
    
        public void ResetOneTimeActions()
        {
            Jump = false;
        }
    }
}