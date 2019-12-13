using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerPresenceScript : NetworkBehaviour
{
    public GameObject playerUnit;

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
        
    }

    [Command]
    void CmdSpawnMyUnit()
    {
        GameObject go = Instantiate(playerUnit);

        //go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);

        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }
}
