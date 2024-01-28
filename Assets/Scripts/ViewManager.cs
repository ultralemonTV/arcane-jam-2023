using ArcanepadSDK;
using ArcanepadSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public GameObject _playerPrefab;
    List<Player> _players = new List<Player>();

    async void Awake()
    {
        Arcane.Init();
        var initialState = await Arcane.ArcaneClientInitialized();

        initialState.pads.ForEach(pad => CreatePlayer(pad));

        Arcane.Msg.On(AEventName.IframePadConnect, new Action<IframePadConnectEvent>(CreatePlayerIfDontExist));
        Arcane.Msg.On(AEventName.IframePadDisconnect, new Action<IframePadDisconnectEvent>(DestroyPlayer));
    }

    void CreatePlayer(ArcanePad pad)
    {
        if (string.IsNullOrEmpty(pad.IframeId)) return;

        GameObject newPlayer = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);
        Player playerComponent = newPlayer.GetComponent<Player>();
        playerComponent.Initialize(pad);

        _players.Add(playerComponent);
    }

    void CreatePlayerIfDontExist(IframePadConnectEvent e)
    {
        var playerExists = _players.Any(player => player._pad.IframeId == e.iframeId);
        if (playerExists) return;

        var pad = new ArcanePad(deviceId: e.deviceId, internalId: e.internalId, iframeId: e.iframeId, isConnected: true, user: e.user);
        CreatePlayer(pad);
    }

    void DestroyPlayer(IframePadDisconnectEvent e)
    {
        var player = _players.FirstOrDefault(player => player._pad.IframeId == e.IframeId);
        if (player == null)
        {
            Debug.LogError("Player not found to remove on disconnect event.");
            return;
        }

        player._pad.Dispose();
        _players.Remove(player);
        Destroy(player.gameObject);
    }
}
