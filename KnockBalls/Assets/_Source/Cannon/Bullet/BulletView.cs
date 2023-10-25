using TMPro;
using UnityEngine;

namespace Cannon.Bullets
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI bulletText;

        public void SetBulletText(string msg) => bulletText.text = msg;
    }
}