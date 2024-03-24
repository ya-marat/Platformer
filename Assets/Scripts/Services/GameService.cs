using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class GameService : IInitializable
{
    [Inject] private ISpawnEntitiesService _spawnEntitiesService;
    
    public ICharacterEntity PlayerEntity { get; private set; }
    
    public void Initialize()
    {
        PlayerEntity = _spawnEntitiesService.SpawnPlayerEntity();
    }
}
