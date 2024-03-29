using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Events;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public static class LoadoutManager
{
    static LoadoutManager()
    {
        _playerDevices = new Dictionary<int, InputDevice>();
        _playerPrimaryWeapons = new Dictionary<int, Events.PrimaryWeapon>();
        _playerSecondaryWeapons = new Dictionary<int, Events.SecondaryWeapon>();
        _playerUltimateWeapons = new Dictionary<int, Events.UltimateWeapon>();
        _playerColors = new Dictionary<int, Color>();
    }

    private static Dictionary<int, InputDevice> _playerDevices;

    private static Dictionary<int, Events.PrimaryWeapon> _playerPrimaryWeapons;

    private static Dictionary<int, Events.SecondaryWeapon> _playerSecondaryWeapons;

    private static Dictionary<int, Events.UltimateWeapon> _playerUltimateWeapons;

    private static Dictionary<int, Color> _playerColors;

    public static void JoinPlayer(int playerId, InputDevice device)
    {
        _playerDevices.Add(playerId, device);
    }

    public static void ChoosePrimary(int playerId, Events.PrimaryWeapon primaryWeapon)
    {
        _playerPrimaryWeapons.Add(playerId, primaryWeapon);
    }

    public static void ChooseSecondary(int playerId, Events.SecondaryWeapon secondaryWeapon)
    {
        _playerSecondaryWeapons.Add(playerId, secondaryWeapon);
    }

    public static void ChooseUltimate(int playerId, Events.UltimateWeapon ultimateWeapon)
    {
        _playerUltimateWeapons.Add(playerId, ultimateWeapon);
    }

    public static void ChooseColor(int playerId, Color color)
    {
        _playerColors.Add(playerId, color);
    }

    public static Tuple<Events.PrimaryWeapon, Events.SecondaryWeapon, Events.UltimateWeapon>
        GetPlayerLoadout(int playerId)
    {
        return new Tuple<Events.PrimaryWeapon, Events.SecondaryWeapon, Events.UltimateWeapon>(
            _playerPrimaryWeapons[playerId], _playerSecondaryWeapons[playerId], _playerUltimateWeapons[playerId]);
    }

    public static List<int> GetPlayerIds()
    {
        return _playerDevices.Keys.ToList();
    }

    public static InputDevice GetPlayerDevice(int playerId)
    {
        return _playerDevices[playerId];
    }

    public static Color GetPlayerColor(int playerId)
    {
        return _playerColors[playerId];
    }

    public static void Reset()
    {
        _playerDevices.Clear();
        _playerPrimaryWeapons.Clear();
        _playerSecondaryWeapons.Clear();
        _playerUltimateWeapons.Clear();
        _playerColors.Clear();
    }
}