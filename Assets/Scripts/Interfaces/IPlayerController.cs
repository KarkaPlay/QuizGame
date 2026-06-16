using UnityEngine;

namespace QuizGame.Core
{
    public interface IPlayerController
    {
        void DisableInput();
        void RestoreInput();
        void TeleportTo(Vector3 position);
        bool IsInputEnabled { get; }
    }
}
