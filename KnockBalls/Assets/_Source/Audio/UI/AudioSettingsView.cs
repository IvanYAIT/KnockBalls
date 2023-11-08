using UnityEngine;
using UnityEngine.UI;

namespace Audio
{
    public class AudioSettingsView : MonoBehaviour
    {
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private Button openSettingsBtn;
        [SerializeField] private Button closeSettingsBtn;

        public GameObject SettingsPanel => settingsPanel;
        public Button OpenSettingsBtn => openSettingsBtn;
        public Button CloseSettingsBtn => closeSettingsBtn;
    }
}