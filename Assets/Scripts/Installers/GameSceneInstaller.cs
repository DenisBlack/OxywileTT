using System.Collections;
using System.Collections.Generic;
using Asteroids;
using Inputs;
using Services;
using UnityEngine;
using Utils;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [Inject] private GameSettingInstaller.Settings _settings;
    public override void InstallBindings()
    {
        Container.Bind<GameStateService>().AsSingle();
        Container.BindInterfacesAndSelfTo<LevelBorders>().AsSingle().WithArguments(Camera.main).NonLazy();
        Container.BindInterfacesAndSelfTo<AsteroidFactory>().AsSingle().WithArguments(_settings.AsteroidPrefabContainer).NonLazy();
        Container.Bind<ScoreService>().AsSingle();
        BindInput();
    }
    
    private void BindInput()
    {
#if UNITY_EDITOR
        Container.Bind<IInputService>().To<MouseInputService>().AsSingle().NonLazy();
#else
        Container.Bind<IInputService>().To<TouchInputService>().AsSingle().NonLazy();
#endif
    }
}
