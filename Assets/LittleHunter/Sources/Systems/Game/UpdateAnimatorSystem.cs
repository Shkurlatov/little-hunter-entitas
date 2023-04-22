using Entitas;

namespace LittleHunter
{
    public class UpdateAnimatorSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public UpdateAnimatorSystem(Contexts contexts)
        {
            _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.MoveDirection,
                GameMatcher.MovementSpeed, GameMatcher.AnimatorView));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.animatorView.value.SetBool(Constants.AnimatorHash.IsMovingParam, entity.isMoving);
            }
        }
    }
}
