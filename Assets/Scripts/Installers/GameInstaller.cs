using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private SpawnPointsController _spawnPointsControllerInstance;
    [SerializeField] private PlatformerPlayerInput _platformerPlayerInput;
    [SerializeField] private PlayerCamera _playerCamera;
    [SerializeField] private BackgroundController _backgroundController;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<SpawnEntitiesService>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameService>().AsSingle();
        Container.Bind<ICommandHolderGetter>().To<PlatformerPlayerInput>().FromInstance(_platformerPlayerInput).AsSingle();
        Container.Bind<SpawnPointsController>().FromInstance(_spawnPointsControllerInstance).AsSingle();
        Container.Bind<PlayerCamera>().FromInstance(_playerCamera).AsSingle();
        Container.Bind<BackgroundController>().FromInstance(_backgroundController).AsSingle();
    }
}
