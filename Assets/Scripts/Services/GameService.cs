using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class GameService : IInitializable
{
    [Inject] private ISpawnEntitiesService _spawnEntitiesService;
    [Inject] private BackgroundController _backgroundController;
    [Inject] private PlayerCamera _playerCamera;
    
    public ICharacterEntity PlayerEntity { get; private set; }
    
    public void Initialize()
    {
        PlayerEntity = _spawnEntitiesService.SpawnPlayerEntity();
        _playerCamera.Init(PlayerEntity.EntityTransform);
        _backgroundController.Init();
    }
}
