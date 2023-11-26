using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIImageLookAtPlayer : MonoBehaviour
{
    Transform player;

    private void Start()
    {
        player = GameManager.instance.player.transform;
    }

    void Update()
    {
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }
}
