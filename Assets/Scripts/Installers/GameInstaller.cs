using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<Dependencies.Game>().AsSingle();
        Container.BindInterfacesTo<Dependencies.Scene>().AsSingle();
        Container.BindInterfacesTo<Dependencies.Enemy>().AsSingle();
        Container.BindInterfacesTo<Dependencies.Hero>().AsSingle();
    }
}
