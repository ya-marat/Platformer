using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface ISpawnEntitiesService
{
    public ICharacterEntity SpawnPlayerEntity();
}

public class SpawnEntitiesService : ISpawnEntitiesService
{
    [Inject] private ISpawnObjectsHolderSO _spawnObjectsHolderSo;
    [Inject] private SpawnPointsController _spawnPointsController;
    [Inject] private GameConfig _gameConfig;
    [Inject] private DiContainer _diContainer;

    public ICharacterEntity SpawnPlayerEntity()
    {
        var newPlayerInstance = Object.Instantiate(_spawnObjectsHolderSo.PlayerEntityPrefab,
            _spawnPointsController.PlayerSpawnPoint.position, Quaternion.identity);

        var entity = newPlayerInstance.GetComponent<ICharacterEntity>();
        
        entity.ComponentsHolder.AddComponent(new MoveHorizontalComponent(_gameConfig.PlayerConfig.MoveSpeed));
        entity.ComponentsHolder.AddComponent(new FlipComponent());
        entity.ComponentsHolder.AddComponent(new AnimatorComponent());
        entity.ComponentsHolder.AddComponent(new JumpComponent(_gameConfig.PlayerConfig.JumpTime, _gameConfig.PlayerConfig.JumpPower, _gameConfig.PlayerConfig.FallMultiplier, _gameConfig.PlayerConfig.JumpMultiplier));
        entity.ComponentsHolder.AddComponent(new GroundComponent(_gameConfig.PlayerConfig.GroundCheckLayers));
        
        var controller = newPlayerInstance.GetComponent<PlayerController>();
        controller.Init();

        _diContainer.Inject(entity);
        return entity;
    }
}
