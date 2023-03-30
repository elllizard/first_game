using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class GameUIInputView : MonoBehaviour, IEntityInputSource
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _jumpButton;

        public float Direction => _joystick.Horizontal;
        
        public bool Jump { get; private set; }

        private void Awake()
        {
            _jumpButton.onClick.AddListener(()=> Jump = true);
            
        }

        private void OnDestroy()
        {
            _jumpButton.onClick.RemoveAllListeners();
        }
        
        public void ResetOneTimeActions()
        {
            Jump = false;
        }
    }
}