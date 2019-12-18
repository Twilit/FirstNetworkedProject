using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerPresenceScript : NetworkBehaviour
{
    public GameObject playerUnit;

    [SyncVar(hook = "OnPlayerNameChange")]
    public string PlayerName = "Anonymous";

    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        CmdSpawnMyUnit();
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            string n = "Kin" + Random.Range(1, 100);

            Debug.Log("Sending the server a request to change name to:" + n);
            CmdChangePlayerName(n);
        }
    }

    void OnPlayerNameChange(string newName)
    {
        Debug.Log("OnPlayerNameChange: Old :" + PlayerName + " New: " + newName);

        PlayerName = newName;

        gameObject.name = "PlayerPresence [" + newName + "] ";
    }

    // Commands

    [Command]
    void CmdSpawnMyUnit()
    {
        GameObject go = Instantiate(playerUnit);

        //go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);

        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }

    [Command]
    void CmdChangePlayerName(string n)
    {
        Debug.Log("CmdChangePlayerName: " + n);
        PlayerName = n;

        //RpcChangePlayerName(PlayerName);
    }

    // Rpcs
    /*
    [ClientRpc]
    void RpcChangePlayerName(string n)
    {
        Debug.Log("RpcChangePlayerName: A player's name change requested by: " + n);
        PlayerName = n;
    }*/
}
