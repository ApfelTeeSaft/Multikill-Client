using LiteNetLib;
using LiteNetLib.Utils;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace Multikill.Multikill
{
    public class NetworkManager : INetEventListener
    {
        private NetManager client;
        private NetPeer serverPeer;

        public void InitializeNetwork()
        {
            client = new NetManager(this);
            client.Start();
        }

        public void ConnectToServer(string ip, int port)
        {
            serverPeer = client.Connect(ip, port, "ConnectionKey");
            Debug.Log($"Attempting to connect to {ip}:{port}");
        }

        public void PollNetworkEvents()
        {
            client.PollEvents();
        }

        public void OnPeerConnected(NetPeer peer)
        {
            Debug.Log("Connected to server!");
        }

        public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
        {
            Debug.Log($"Disconnected from server: {disconnectInfo.Reason}");
        }

        public void OnNetworkError(IPEndPoint endPoint, SocketError socketErrorCode)
        {
            Debug.LogError($"Network error: {socketErrorCode}");
        }

        public void OnConnectionRequest(ConnectionRequest request)
        {
            request.Accept();
        }

        public void OnNetworkReceive(NetPeer peer, NetPacketReader reader, byte channelNumber, DeliveryMethod deliveryMethod)
        {
            Debug.Log("Received data from server.");
        }

        public void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader, UnconnectedMessageType messageType)
        {
        }

        public void OnNetworkLatencyUpdate(NetPeer peer, int latency)
        {
            Debug.Log($"Latency update: {latency} ms");
        }
    }
}