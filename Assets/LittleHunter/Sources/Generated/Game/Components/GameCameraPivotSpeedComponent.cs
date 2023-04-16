//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity cameraPivotSpeedEntity { get { return GetGroup(GameMatcher.CameraPivotSpeed).GetSingleEntity(); } }
    public CameraPivotSpeedComponent cameraPivotSpeed { get { return cameraPivotSpeedEntity.cameraPivotSpeed; } }
    public bool hasCameraPivotSpeed { get { return cameraPivotSpeedEntity != null; } }

    public GameEntity SetCameraPivotSpeed(float newValue) {
        if (hasCameraPivotSpeed) {
            throw new Entitas.EntitasException("Could not set CameraPivotSpeed!\n" + this + " already has an entity with CameraPivotSpeedComponent!",
                "You should check if the context already has a cameraPivotSpeedEntity before setting it or use context.ReplaceCameraPivotSpeed().");
        }
        var entity = CreateEntity();
        entity.AddCameraPivotSpeed(newValue);
        return entity;
    }

    public void ReplaceCameraPivotSpeed(float newValue) {
        var entity = cameraPivotSpeedEntity;
        if (entity == null) {
            entity = SetCameraPivotSpeed(newValue);
        } else {
            entity.ReplaceCameraPivotSpeed(newValue);
        }
    }

    public void RemoveCameraPivotSpeed() {
        cameraPivotSpeedEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CameraPivotSpeedComponent cameraPivotSpeed { get { return (CameraPivotSpeedComponent)GetComponent(GameComponentsLookup.CameraPivotSpeed); } }
    public bool hasCameraPivotSpeed { get { return HasComponent(GameComponentsLookup.CameraPivotSpeed); } }

    public void AddCameraPivotSpeed(float newValue) {
        var index = GameComponentsLookup.CameraPivotSpeed;
        var component = (CameraPivotSpeedComponent)CreateComponent(index, typeof(CameraPivotSpeedComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCameraPivotSpeed(float newValue) {
        var index = GameComponentsLookup.CameraPivotSpeed;
        var component = (CameraPivotSpeedComponent)CreateComponent(index, typeof(CameraPivotSpeedComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCameraPivotSpeed() {
        RemoveComponent(GameComponentsLookup.CameraPivotSpeed);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCameraPivotSpeed;

    public static Entitas.IMatcher<GameEntity> CameraPivotSpeed {
        get {
            if (_matcherCameraPivotSpeed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CameraPivotSpeed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCameraPivotSpeed = matcher;
            }

            return _matcherCameraPivotSpeed;
        }
    }
}
