using BepInEx;
using UnityEngine;


namespace Multikill
{
    [BepInPlugin("com.apfelteesaft.multikillmod", "MultikillMod", "1.0.0")]
    public class MultiplayerMod : BaseUnityPlugin
    {
        private Multikill.ConsoleManager consoleManager;
        private Multikill.UIManager uiManager;
        private Multikill.NetworkManager networkManager;

        void Awake()
        {
            consoleManager = new Multikill.ConsoleManager();
            consoleManager.InitializeConsole();

            uiManager = new Multikill.UIManager();
            uiManager.SetupUI(ConnectToServer);

            networkManager = new Multikill.NetworkManager();
            networkManager.InitializeNetwork();
        }

        void Update()
        {
            networkManager.PollNetworkEvents();

            if (Input.GetKeyDown(KeyCode.F4))
            {
                consoleManager.ToggleConsole();
            }

            if (Input.GetKeyDown(KeyCode.F1))
            {
                uiManager.ToggleUIVisibility();
            }
        }

        private void ConnectToServer(string ip, int port)
        {
            networkManager.ConnectToServer(ip, port);
        }

        void OnDestroy()
        {
            consoleManager.Cleanup();
        }
    }
}