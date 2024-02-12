using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //dodaj do wspó³rzêdnych wartoœæ x=1, y=0, z=0 pomno¿one przez czas
        //mierzony w sekundach od ostatniej klatki
        //transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

        //prezentacja dzia³ania wyg³adzanego sterowania (emulacja joystika)
        //Debug.Log(Input.GetAxis("Vertical"));

        //sterowanie prêdkoœci¹
        //stwórz nowy wektor przesuniêcia o wartoœci 1 do przodu
        Vector3 movement = Vector3.forward;
        //pomnó¿ go przez czas od ostatniej klatki
        movement *= Time.deltaTime;
        //pomnó¿ go przez "wychylenie joystika"
        movement *= Input.GetAxis("Vertical");
        //dodaj ruch do obiektu
        transform.position += movement;
    }
}
