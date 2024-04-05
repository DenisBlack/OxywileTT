using System;
using System.Collections;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingInstaller", menuName = "Installers/GameSettingInstaller")]
public class GameSettingInstaller : ScriptableObjectInstaller<GameSettingInstaller>
{
    public Settings GameSettings;
        
    public override void InstallBindings()
    {
        Container.BindInstance(GameSettings).IfNotBound();
    }
    
    [Serializable]
    public class Settings
    {
        public AsteroidPrefabContainer AsteroidPrefabContainer;
    }
}
