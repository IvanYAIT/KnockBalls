using Cannon.Bullets;
using UnityEngine;
using Zenject;

namespace Cannon
{
    public class InputListener : MonoBehaviour
    {
        private CannonData _data;
        private CannonController _controller;
        private BulletController _bulletController;
        private int _enviromentLayer;
        private bool input;

        [Inject]
        public void Construct(CannonData data, CannonController controller, BulletController bulletController)
        {
            input = true;
            _data = data;
            _controller = controller;
            _bulletController = bulletController;
            _enviromentLayer = 1<<(int)Mathf.Log(data.EnviromentLayerMask.value, 2);
            BulletController.OnBulletEnd += DisableInput;
        }

        void Update()
        {
            if (( Input.touchCount > 0 || Input.GetMouseButtonDown(0)) && input)
            {
                //Touch touch = Input.GetTouch(0);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _enviromentLayer))
                {
                    _controller.Rotate(_data.CannonTransform, hitInfo);
                }
                _bulletController.UseBullet();
                _controller.Fire(_data.FirePoint, _data.FireForce);
            }
        }

        public void EnableInput() => input = true;
        public void DisableInput() => input = false;
    }
}