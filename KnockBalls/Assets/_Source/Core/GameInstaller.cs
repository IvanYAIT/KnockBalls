using System.Collections.Generic;
using _Source.LevelManaging;
using Audio;
using Cannon;
using Cannon.Bullets;
using Cannon.Skill;
using Level;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private CannonData cannonData;
        [SerializeField] private InputListener inputListener;
        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private BulletView bulletView;
        [SerializeField] private Game game;
        [SerializeField] private Transform levelsPosition;
        [SerializeField] private ScreenFader fader;
        [SerializeField] private GameLevelsSettings gameLevelsSettings;
        [SerializeField] private RoundListener roundListener;
        [SerializeField] private LevelView levelView;
        [SerializeField] private AudioData audioData;
        [SerializeField] private AudioClipData audioClip;
        [SerializeField] private AudioSettingsView audioSettingsView;
        [SerializeField] private SkillView skillView;

        public override void InstallBindings()
        {
            Container.Bind<GameLevelsSettings>().FromInstance(gameLevelsSettings).AsSingle().NonLazy();
            Container.Bind<AudioData>().FromInstance(audioData).AsSingle().NonLazy();
            Container.Bind<AudioSettingsView>().FromInstance(audioSettingsView).AsSingle().NonLazy();
            Container.Bind<AudioClipData>().FromInstance(audioClip).AsSingle().NonLazy();
            Container.Bind<AudioRandomizer>().AsSingle().NonLazy();
            Container.Bind<AudioMediator>().AsSingle().NonLazy();
            Container.Bind<Audio.AudioSettings>().AsSingle().NonLazy();

            Container.Bind<LevelView>().FromInstance(levelView).AsSingle().NonLazy();
            Container.Bind<LevelController>().AsSingle().NonLazy();
            Container.Bind<RoundsInfo>().AsSingle().NonLazy();
            Container.Bind<LevelSettings>().FromInstance(levelSettings).AsSingle().NonLazy();

            Container.Bind<SkillView>().FromInstance(skillView).AsSingle().NonLazy();
            Container.Bind<BulletView>().FromInstance(bulletView).AsSingle().NonLazy();
            Container.Bind<SkillController>().AsSingle().NonLazy();
            Container.Bind<BulletController>().AsSingle().NonLazy();
            Container.Bind<BulletPool>().AsSingle().NonLazy();
            Container.Bind<CannonData>().FromInstance(cannonData).AsSingle().NonLazy();
            Container.Bind<CannonController>().AsSingle().NonLazy();
            Container.Bind<InputListener>().FromInstance(inputListener).AsSingle().NonLazy();

            Container.Bind<Game>().FromInstance(game).AsSingle().NonLazy();
            Container.Bind<Transform>().FromInstance(levelsPosition).AsSingle().NonLazy();
            Container.Bind<ScreenFader>().FromInstance(fader).AsSingle().NonLazy();
            Container.Bind<RoundListener>().FromInstance(roundListener).AsSingle().NonLazy();
            
            
            Container.BindFactory<Bullet, BulletPool.BulletFactory>().FromComponentInNewPrefab(bulletPrefab);
        }
    }
}