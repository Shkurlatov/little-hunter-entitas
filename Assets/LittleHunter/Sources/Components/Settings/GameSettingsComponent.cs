using Entitas;
using Entitas.CodeGeneration.Attributes;
using LittleHunter;

[Settings, Unique]
public sealed class GameSettingsComponent : IComponent
{
    public GameSettingsData value;
}
