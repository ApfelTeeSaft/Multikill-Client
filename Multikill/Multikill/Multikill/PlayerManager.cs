using System.Collections.Generic;
using UnityEngine;

namespace Multikill.Multikill
{
    public class PlayerManager
    {
        private Dictionary<int, GameObject> playerCubes = new Dictionary<int, GameObject>();

        // Update or create a player's cube
        public void UpdatePlayer(int playerId, Vector3 position, Vector3 rotation)
        {
            if (!playerCubes.ContainsKey(playerId))
            {
                // Create a new cube for the player
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.name = $"Player_{playerId}";
                cube.transform.position = position;
                cube.transform.eulerAngles = rotation;
                playerCubes.Add(playerId, cube);
            }
            else
            {
                // Update existing player's cube
                GameObject existingCube = playerCubes[playerId];
                existingCube.transform.position = position;
                existingCube.transform.eulerAngles = rotation;
            }
        }

        // Remove a player's cube when they disconnect
        public void RemovePlayer(int playerId)
        {
            if (playerCubes.ContainsKey(playerId))
            {
                GameObject cube = playerCubes[playerId];
                GameObject.Destroy(cube);
                playerCubes.Remove(playerId);
            }
        }
    }
}