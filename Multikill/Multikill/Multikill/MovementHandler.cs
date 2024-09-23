using LiteNetLib;
using LiteNetLib.Utils;
using UnityEngine;

namespace Multikill.Multikill
{
    public class MovementHandler
    {
        private MultiplayerMod mod;
        private NetDataWriter writer;

        public MovementHandler(MultiplayerMod mod)
        {
            this.mod = mod;
            writer = new NetDataWriter();
        }

        public void SendPlayerData(Vector3 position, Vector3 rotation, NetPeer serverPeer)
        {
            writer.Reset();
            writer.Put(position.x);
            writer.Put(position.y);
            writer.Put(position.z);
            writer.Put(rotation.x);
            writer.Put(rotation.y);
            writer.Put(rotation.z);

            serverPeer.Send(writer, DeliveryMethod.Unreliable);
        }

        public void ReceivePlayerData(NetPacketReader reader)
        {
            int playerId = reader.GetInt();
            float posX = reader.GetFloat();
            float posY = reader.GetFloat();
            float posZ = reader.GetFloat();
            float rotX = reader.GetFloat();
            float rotY = reader.GetFloat();
            float rotZ = reader.GetFloat();

            mod.playerManager.UpdatePlayer(playerId, new Vector3(posX, posY, posZ), new Vector3(rotX, rotY, rotZ));
        }
    }
}