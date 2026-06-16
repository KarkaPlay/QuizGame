using StarterAssets;
using UnityEngine;
using QuizGame.Core;

namespace QuizGame.Core
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] private GameObject _player;

        private ThirdPersonController _thirdPersonController;
        private StarterAssetsInputs _starterAssetsInputs;
        private float _originalMoveSpeed;
        private float _originalSprintSpeed;

        public bool IsInputEnabled { get; private set; } = true;

        private void Awake()
        {
            if (_player != null)
            {
                _player.TryGetComponent(out _thirdPersonController);
                _player.TryGetComponent(out _starterAssetsInputs);
            }
        }

        private void Start()
        {
            if (_thirdPersonController != null)
            {
                _originalMoveSpeed = _thirdPersonController.MoveSpeed;
                _originalSprintSpeed = _thirdPersonController.SprintSpeed;
            }
        }

        public void DisableInput()
        {
            if (_thirdPersonController != null)
            {
                _thirdPersonController.MoveSpeed = 0;
                _thirdPersonController.SprintSpeed = 0;
            }
            if (_starterAssetsInputs != null)
            {
                _starterAssetsInputs.enabled = false;
            }
            IsInputEnabled = false;
        }

        public void RestoreInput()
        {
            if (_thirdPersonController != null)
            {
                _thirdPersonController.MoveSpeed = _originalMoveSpeed;
                _thirdPersonController.SprintSpeed = _originalSprintSpeed;
                _thirdPersonController.enabled = true;
            }
            if (_starterAssetsInputs != null)
            {
                _starterAssetsInputs.enabled = true;
            }
            IsInputEnabled = true;
        }

        public void TeleportTo(Vector3 position)
        {
            if (_player != null)
            {
                _player.SetActive(false);
                _player.transform.position = position;
                _player.SetActive(true);
            }
        }
    }
}
