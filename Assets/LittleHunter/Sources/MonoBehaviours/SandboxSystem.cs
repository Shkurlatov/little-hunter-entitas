using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Photon.Pun;

namespace LittleHunter
{
    public class SandboxSystem : MonoBehaviourPunCallbacks
    {
        [SerializeField] private List<Transform> spawnPoints;
        [SerializeField] private Transform cameraRoot;
        [SerializeField] private Transform cameraPivot;

        private Systems _systems;
        private Contexts _contexts;

        private Systems _physicSystems;
        private Systems _lateFixedUpdateSystems;

        private void Awake()
        {
            _contexts = Contexts.sharedInstance;
            _systems = new Feature("Game System");
            _physicSystems = new Feature("Physics Systems");
            _lateFixedUpdateSystems = new Feature("Late Systems");

            _systems.Add(new CreateSpawnPointSystem(_contexts, spawnPoints));
            _systems.Add(new CreateLocalPlayerSystem(_contexts));

            _physicSystems.Add(new MovePlayerSystem(_contexts));
            _physicSystems.Add(new RotatePlayerSystem(_contexts));
            _lateFixedUpdateSystems.Add(new CameraFollowTargetSystem(_contexts, cameraRoot));
        }

        private void Start()
        {
            _contexts.network.isPendingConnection = false;
            _systems.Initialize();
            _physicSystems.Initialize();
            _lateFixedUpdateSystems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        private void FixedUpdate()
        {
            _physicSystems.Execute();
            _lateFixedUpdateSystems.Execute();
            _physicSystems.Cleanup();
            _lateFixedUpdateSystems.Cleanup();
        }
    }
}
