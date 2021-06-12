using UnityEngine;
using Photon.Pun;

public class InstantiatePlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;

    private void Start()
    {
        // x: 12,24  z:-3,-6  y:15
        var xPos = Random.Range(12f, 24f);
        var yPos = 15f;
        var zPos = Random.Range(-3f, -6f);
        var playerPos = new Vector3(xPos, yPos, zPos);

        PhotonNetwork.Instantiate(playerPrefab.name, playerPos, Quaternion.identity );
    }
}
