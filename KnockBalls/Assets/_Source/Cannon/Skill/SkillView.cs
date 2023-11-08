using UnityEngine;
using UnityEngine.UI;

namespace Cannon.Skill
{
    public class SkillView : MonoBehaviour
    {
        [SerializeField] private Button skillBtn;

        public Button SkillBtn => skillBtn;
    }
}