using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private SpawnPointsController _spawnPointsControllerInstance;
    [SerializeField] private PlatformerPlayerInput _platformerPlayerInput;
    [SerializeField] private PlayerCamera _playerCamera;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<SpawnEntitiesService>().AsSingle();
        Container.BindInterfacesTo<GameService>().AsSingle();
        Container.Bind<ICommandHolderGetter>().To<PlatformerPlayerInput>().FromInstance(_platformerPlayerInput).AsSingle();
        Container.Bind<SpawnPointsController>().FromInstance(_spawnPointsControllerInstance).AsSingle();
        Container.Bind<PlayerCamera>().FromInstance(_playerCamera).AsSingle();
    }
}
