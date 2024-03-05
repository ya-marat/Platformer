using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MainSOInstaller", menuName = "Installers/MainSOInstaller", order = 1)]
public class MainSOInstaller : ScriptableObjectInstaller
{
    [SerializeField] private SpawnObjectsHolderSO _spawnObjectsHolderSo;
    [SerializeField] private GameConfig _gameConfig;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<SpawnObjectsHolderSO>().FromInstance(_spawnObjectsHolderSo).AsSingle();
        Container.Bind<GameConfig>().FromInstance(_gameConfig).AsSingle();
    }
}
