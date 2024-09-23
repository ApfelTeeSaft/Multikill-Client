# Multikill Client (for Ultrakill 0.9.0)

**Multikill** is a mod for **Ultrakill version 0.9.0**, designed to bring full-featured multiplayer functionality to the game, allowing players to engage in **PvP combat** across different maps. This client-side mod is built using **BepInEx** and connects to dedicated **Multikill Servers**.

## Features
- **Multiplayer PvP**: Battle against other players on various Ultrakill maps.
- **BepInEx Mod Integration**: Uses BepInEx to seamlessly integrate into the Ultrakill client.
- **Basic Movement Syncing**: Sync player positions and basic movements between connected clients.
- **Map Syncing**: The map set by the server is replicated across all connected clients.
- **Multiplayer UI**: Connect to dedicated servers directly through an in-game UI.

> **Note**: The current version only includes **basic movement syncing** and **map syncing**. More advanced features like weapon synchronization, team modes, and PvP mechanics are planned for future updates.

---

## Requirements
- **Ultrakill version 0.9.0** (latest version)
- **BepInEx_win_x64_5.4.23.2** (for modding the client)
- **LiteNetLib** (for network communication)

---

## Installation

### 1. Install BepInEx
1. Download **BepInEx_win_x64_5.4.23.2** from the [BepInEx GitHub](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.23.2).
2. Extract the contents into your **Ultrakill** installation folder (version 0.9.0). The folder structure should look like this:
   ```
   Ultrakill/
     BepInEx/
     ultrakill.exe
     winhttp.dll (installed by BepInEx)
   ```

### 2. Install the Multikill Client Mod
1. Download the **latest stable version** of the **Multikill.dll** from the [client release page](https://github.com/ApfelTeeSaft/Multikill-Client/releases).
2. Place `Multikill.dll` in the `BepInEx/plugins` directory inside your **Ultrakill 0.9.0** installation folder.

### 3. Launch the Game
1. Start **Ultrakill 0.9.0**. BepInEx will automatically load the mod.
2. Press **F1** to bring up the multiplayer UI.
3. Enter the IP address and port of the **Multikill Server** and click **Connect** to start playing.

---

## How to Play

1. **Connect to a Server**:
   - Start **Ultrakill 0.9.0** with the **Multikill Mod** installed.
   - Press **F1** to open the multiplayer UI.
   - Enter the server's IP address and port (default: `9050`) and click **Connect**.

2. **Basic Movement Sync**:
   - Players can move around in-game, and their positions will be synced with other connected clients.
   - The map will be synced from the server to all clients.

---

## Features Under Development
- **Weapon Synchronization**: Sync weapon pickups and other player-specific actions.
- **Team Modes**: Play **Team Deathmatch** and other team-based modes.
- **Competitive Stats**: Track player stats and display leaderboards.
- **Custom Map Support**: Allow server administrators to load custom maps.

---

## Contributing
The **Multikill Client** project is open to contributions! Help improve the mod by reporting issues, suggesting new features, or submitting pull requests.

To contribute:
1. Fork the **client repository**.
2. Make your changes and submit a pull request.