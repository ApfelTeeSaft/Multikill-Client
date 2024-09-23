using BepInEx;
using LiteNetLib;
using LiteNetLib.Utils;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using UnityEngine;
using Multikill.Multikill;

namespace Multikill
{
    [BepInPlugin("com.apfelteesaft.multikillmod", "MultikillMod", "1.0.0")]
    public class Plugin : BaseUnityPlugin, INetEventListener
    {
        private NetManager client;
        private NetPeer serverPeer;
        private MovementHandler movementHandler;
        public PlayerManager playerManager { get; private set; }

        void Awake()
        {
            movementHandler = new MovementHandler(this);
            playerManager = new PlayerManager();
            InitializeNetwork();
        }

        void InitializeNetwork()
        {
            client = new NetManager(this);
            client.Start();
        }

        void ConnectToServer(string ip, int port)
        {
            serverPeer = client.Connect(ip, port, "ConnectionKey");
            Debug.Log($"Attempting to connect to {ip}:{port}");
        }

        void Update()
        {
            client.PollEvents();

            if (serverPeer != null && serverPeer.ConnectionState == ConnectionState.Connected)
            {
                SendPlayerData();
            }
        }

        private void SendPlayerData()
        {
            Vector3 playerPosition = transform.position;
            Vector3 playerRotation = transform.eulerAngles;

            movementHandler.SendPlayerData(playerPosition, playerRotation, serverPeer);
        }

        public void OnNetworkReceive(NetPeer peer, NetPacketReader reader, byte channelNumber, DeliveryMethod deliveryMethod)
        {
            movementHandler.ReceivePlayerData(reader);
        }

        public void OnPeerConnected(NetPeer peer)
        {
            Debug.Log("Connected to server!");
        }

        public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
        {
            Debug.Log($"Disconnected from server: {disconnectInfo.Reason}");
        }

        public void OnConnectionRequest(ConnectionRequest request)
        {
            // Not used on client side
        }

        public void OnNetworkError(IPEndPoint endPoint, SocketError socketError)
        {
            Debug.LogError($"Network error at {endPoint}: {socketError}");
        }

        public void OnNetworkLatencyUpdate(NetPeer peer, int latency)
        {
            Debug.Log($"Latency update: {latency} ms");
        }

        public void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader, UnconnectedMessageType messageType)
        {
            // Handle unconnected messages
        }
    }
}