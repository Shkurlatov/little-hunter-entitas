using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input, Unique]
public class LookInputComponent : IComponent
{
    public UnityEngine.Vector2 value;
}
