using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    //wspó³rzêdne gracza
    Transform player;
    //wysokoœæ kamery
    public float cameraHeight = 10.0f;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //oblicz docelow¹ pozycjê kamery
        Vector3 targetPosition = player.position + Vector3.up * cameraHeight;
        //p³ynnie przesuñ kamere w kierunku gracza
        //funkcja Vector3.Lerp
        //p³ynnie przechodzi z pozycji pierwszeo argumentu do drugiego w czasie trzeciegoo
        transform.position =Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }
}
