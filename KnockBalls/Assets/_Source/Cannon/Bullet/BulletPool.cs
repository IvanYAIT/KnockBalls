using System.Collections.Generic;
using Zenject;

namespace Cannon.Bullets
{
    public class BulletPool
    {
        private const int POOL_SIZE = 10;

        private List<Bullet> _pool;
        private BulletFactory _bulletFactory;

        [Inject]
        public BulletPool(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;

            CreatePool(POOL_SIZE);
        }

        public Bullet GetFreeElement()
        {
            if (HasFreeElement(out Bullet element))
                return element;

            return CreateObject(true);
        }

        private void CreatePool(int count)
        {
            _pool = new List<Bullet>();

            for (int i = 0; i < count; i++)
                CreateObject();
        }

        private Bullet CreateObject(bool isActive = false)
        {
            Bullet createdObject = _bulletFactory.Create();
            createdObject.gameObject.SetActive(isActive);
            _pool.Add(createdObject);
            return createdObject;
        }

        private bool HasFreeElement(out Bullet element)
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].gameObject.activeInHierarchy)
                {
                    element = _pool[i];
                    _pool[i].gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public class BulletFactory : PlaceholderFactory<Bullet> { };
    }
}