using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public sealed class CameraSmoothTimeComponent : IComponent
{
    public float value;
}
