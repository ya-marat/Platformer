using UnityEngine;

public interface ISpawnObjectsHolderSO
{
    public GameObject PlayerEntityPrefab { get; }
}

[CreateAssetMenu(fileName = "SpawnObjectsHolderSO", menuName = "Spawn/SpawnObjectsHolderSO", order = 1)]
public class SpawnObjectsHolderSO : ScriptableObject, ISpawnObjectsHolderSO
{
    [SerializeField] private GameObject _playerEntityPrefab;

    public GameObject PlayerEntityPrefab => _playerEntityPrefab;
}