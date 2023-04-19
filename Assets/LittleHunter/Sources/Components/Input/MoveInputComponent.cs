using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input, Unique]
public class MoveInputComponent : IComponent
{
    public UnityEngine.Vector2 value;
}
