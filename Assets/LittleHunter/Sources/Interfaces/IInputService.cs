using UnityEngine;

namespace LittleHunter
{
    public interface IInputService
    {
        Vector2 GetMovement { get; }
        Vector2 GetLook { get; }
        void Dispose();
    }
}
