using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private SpawnPointsController _spawnPointsControllerInstance;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerCamera _playerCamera;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<SpawnEntitiesService>().AsSingle();
        Container.BindInterfacesTo<GameService>().AsSingle();
        Container.BindInterfacesTo<PlayerInput>().FromInstance(_playerInput).AsSingle();
        Container.Bind<SpawnPointsController>().FromInstance(_spawnPointsControllerInstance).AsSingle();
        Container.Bind<PlayerCamera>().FromInstance(_playerCamera).AsSingle();
    }
}
