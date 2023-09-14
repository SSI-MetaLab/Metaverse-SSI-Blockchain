using UnityEngine;
using Photon.Pun;

public class RespawnManager : MonoBehaviourPunCallbacks
{
    public GameObject prefabToSpawn;

    public void SpawnPrefab()
    {
        // Spawn the prefab across the network using Photon PUN 2
        PhotonNetwork.Instantiate(prefabToSpawn.name, Vector3.zero, Quaternion.identity);
    }
}
