using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool Destroy;
    public bool Recycling;
    public float randomSpawnTimer;
    [SerializeField]
    private int networkId;

    public int NetworkId
    {
        get
        {
            return networkId;
        }
        
    }
//network id of object, needed to get object from list and update its transform
    public int Life;
    public Vector3 position;
//variable to save position for pathfinding. it does not affect gameobject position!

    private void OnEnable()
    {
        networkId = GetComponent<GameNetworkObject>().NetworkId;
        //Debug.Log("Spawn: " + networkId);
        randomSpawnTimer = Random.Range(0f, 5.0f);
        Life = UnityEngine.Random.Range(1, 6);
        Destroy = false;
        Recycling = false;
    }

    private void Awake()
    {       
        randomSpawnTimer = Random.Range(0f, 5.0f);
        Destroy = false;
        Recycling = false;        
    }

    public void Reset()
    {        
        Life = UnityEngine.Random.Range(1, 6);
    }

    //this will be managed by the host to send enemies datas to players
    public void DestroyAndRecycle()
    {
        Destroy = true;
        Recycling = true;
    }

    //TO DELETE
    public void DecreaseLife()
    {
        this.Life--;
    }

   

}
