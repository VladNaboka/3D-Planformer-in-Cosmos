using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    Vector3 target;

    public float speedCamera = 10f;

    void Update()
    {
        Vector3 currentVector = Vector3.Lerp(transform.position, target, speedCamera * Time.deltaTime);

        transform.position = currentVector;

        target = new Vector3(player.transform.position.x + 5f, player.transform.position.y + 7f, player.transform.position.z + 7f);
        gameObject.transform.rotation = Quaternion.Euler(30f, -120f, 0);
    }
}
