using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class GameService : IInitializable
{
    [Inject] private ISpawnEntitiesService _spawnEntitiesService;
    [Inject] private BackgroundController _backgroundController;
    [Inject] private PlayerCamera _playerCamera;
    [Inject] private MapController _mapController;
    
    public ICharacterEntity PlayerEntity { get; private set; }
    
    public void Initialize()
    {
        _mapController.Init();
        PlayerEntity = _spawnEntitiesService.SpawnPlayerEntity();
        _playerCamera.Init(PlayerEntity.EntityTransform);
        _backgroundController.Init();
    }
}
