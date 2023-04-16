//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MoveDirectionComponent moveDirection { get { return (MoveDirectionComponent)GetComponent(GameComponentsLookup.MoveDirection); } }
    public bool hasMoveDirection { get { return HasComponent(GameComponentsLookup.MoveDirection); } }

    public void AddMoveDirection(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.MoveDirection;
        var component = (MoveDirectionComponent)CreateComponent(index, typeof(MoveDirectionComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMoveDirection(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.MoveDirection;
        var component = (MoveDirectionComponent)CreateComponent(index, typeof(MoveDirectionComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMoveDirection() {
        RemoveComponent(GameComponentsLookup.MoveDirection);
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

    static Entitas.IMatcher<GameEntity> _matcherMoveDirection;

    public static Entitas.IMatcher<GameEntity> MoveDirection {
        get {
            if (_matcherMoveDirection == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MoveDirection);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMoveDirection = matcher;
            }

            return _matcherMoveDirection;
        }
    }
}