using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class EnemyHitMgr : MonoBehaviour
{
    private void Awake()
    {
        if (!Client.IsHost)
        {
            this.enabled = false;
            return;
        }
        Client.AddCommand(PacketType.ShootHitServer, OnEnemyHit);
    }

    private void OnEnemyHit(byte[] data, uint length, CSteamID sender)
    {
        int id = data[0];

                Enemy e = ClientTransformManager.IdEnemies[id].gameObject.GetComponent<Enemy>();
                Debug.Log("hit received");
                e.DecreaseLife();
                CheckLife(e);
            //send to all but this client a packet with hit command only if e life is not 0 
            //else send enemy death;
    }

    private void CheckLife(Enemy e)
    {
        //will then send status info to players and they'll update their enemies lives
        if (e.Life <= 0)
        {
            e.DestroyAndRecycle();
            HostEnemyDestroyer.EnemyToRecycleToAdd.Add(e);
        }
    }
}
