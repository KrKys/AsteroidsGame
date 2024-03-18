using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float flySpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //dodaj do wsp�rz�dnych warto�� x=1, y=0, z=0 pomno�one przez czas
        //mierzony w sekundach od ostatniej klatki
        //transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

        //prezentacja dzia�ania wyg�adzanego sterowania (emulacja joystika)
        //Debug.Log(Input.GetAxis("Vertical"));

        //sterowanie pr�dko�ci�
        //stw�rz nowy wektor przesuni�cia o warto�ci 1 do przodu
        Vector3 movement = transform.forward;
        //pomn� go przez czas od ostatniej klatki
        movement *= Time.deltaTime;
        //pomn� go przez "wychylenie joystika"
        movement *= Input.GetAxis("Vertical");
        //pomn� pr�dko�� lotu
        movement *= flySpeed;
        //dodaj ruch do obiektu
        //zmiana na fizyke
       // --- transform.position += movement;

        //komponent fizyki wewnatrz gracza
        Rigidbody rb = GetComponent<Rigidbody>();  
       rb.GetComponent<Rigidbody>().AddForce(movement, ForceMode.VelocityChange);


        //obr�t
        //modyfikuj o� "Y" obiektu player
        Vector3 rotation = Vector3.up;
        //pomn� przez czas
        rotation *= Time.deltaTime;
        //przemn� przez klawiatur�
        rotation *= Input.GetAxis("Horizontal");
        //pomn� przez pr�dko�� obrotu
        rotation *= rotationSpeed;

        //dodaj obr�t do obiektu
        //nie mo�emy u�y� += poniewa� unity u�ywa Quaterion�w do zapisu rotacji
        transform.Rotate(rotation);

    }

    private void OnCollisionEnter(Collision collision)
    {
        //urachamia sie automatycznie jesli zetkniemy sie z innym coliderem

        //sprawdz czy dotknelismy asteroidy
        if (collision.collider.transform.CompareTag("Asteroid"))
        {
            Debug.Log("Boom!");
            //pauza
            Time.timeScale = 0;
        }
    }
}
