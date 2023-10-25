using Cannon;
using Cannon.Bullets;
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

        public override void InstallBindings()
        {
            Container.Bind<LevelSettings>().FromInstance(levelSettings).AsSingle().NonLazy();
            Container.Bind<BulletView>().FromInstance(bulletView).AsSingle().NonLazy();
            Container.Bind<BulletController>().AsSingle().NonLazy();
            Container.Bind<BulletPool>().AsSingle().NonLazy();
            Container.Bind<CannonData>().FromInstance(cannonData).AsSingle().NonLazy();
            Container.Bind<CannonController>().AsSingle().NonLazy();
            Container.Bind<InputListener>().FromInstance(inputListener).AsSingle().NonLazy();
            Container.Bind<Game>().FromInstance(game).AsSingle().NonLazy();

            Container.BindFactory<Bullet, BulletPool.BulletFactory>().FromComponentInNewPrefab(bulletPrefab);
        }
    }
}