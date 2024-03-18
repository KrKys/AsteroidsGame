using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    //wsp�rz�dne gracza
    Transform player;
    //wysoko�� kamery
    public float cameraHeight = 10.0f;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //oblicz docelow� pozycj� kamery
        Vector3 targetPosition = player.position + Vector3.up * cameraHeight;
        //p�ynnie przesu� kamere w kierunku gracza
        //funkcja Vector3.Lerp
        //p�ynnie przechodzi z pozycji pierwszeo argumentu do drugiego w czasie trzeciegoo
        transform.position =Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }
}
