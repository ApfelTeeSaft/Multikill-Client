using UnityEngine;
using UnityEngine.UI;

namespace Multikill.Multikill
{
    public class UIManager
    {
        private GameObject panel;
        private InputField ipInput;
        private InputField portInput;
        private Button connectButton;

        public void SetupUI(System.Action<string, int> onConnectButtonClick)
        {
            panel = new GameObject("MultiplayerPanel");
            panel.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

            GameObject ipFieldObj = new GameObject("IPInputField");
            ipInput = ipFieldObj.AddComponent<InputField>();
            ipInput.placeholder.GetComponent<Text>().text = "Enter Server IP";
            ipInput.text = "127.0.0.1";
            ipFieldObj.transform.SetParent(panel.transform);

            GameObject portFieldObj = new GameObject("PortInputField");
            portInput = portFieldObj.AddComponent<InputField>();
            portInput.placeholder.GetComponent<Text>().text = "Enter Port";
            portInput.text = "9050";
            portFieldObj.transform.SetParent(panel.transform);

            GameObject buttonObj = new GameObject("ConnectButton");
            connectButton = buttonObj.AddComponent<Button>();
            connectButton.GetComponentInChildren<Text>().text = "Connect";
            buttonObj.transform.SetParent(panel.transform);

            connectButton.onClick.AddListener(() =>
            {
                string ip = ipInput.text;
                int port = int.Parse(portInput.text);
                onConnectButtonClick(ip, port);
            });

            panel.SetActive(false);
        }

        public void ToggleUIVisibility()
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}