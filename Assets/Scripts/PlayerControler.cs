using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float flySpeed = 5f;

    GameObject levelManagerObject;
    //stan oslon w procentach (1=100%)
    float shieldCapacity = 1;


    // Start is called before the first frame update
    void Start()
    {
        levelManagerObject = GameObject.Find("LevelManager");
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
        Vector3 movement = transform.forward;
        //pomnó¿ go przez czas od ostatniej klatki
        movement *= Time.deltaTime;
        //pomnó¿ go przez "wychylenie joystika"
        movement *= Input.GetAxis("Vertical");
        //pomnó¿ prêdkoœæ lotu
        movement *= flySpeed;
        //dodaj ruch do obiektu
        //zmiana na fizyke
       // --- transform.position += movement;

        //komponent fizyki wewnatrz gracza
        Rigidbody rb = GetComponent<Rigidbody>();  
       rb.GetComponent<Rigidbody>().AddForce(movement, ForceMode.VelocityChange);


        //obrót
        //modyfikuj oœ "Y" obiektu player
        Vector3 rotation = Vector3.up;
        //pomnó¿ przez czas
        rotation *= Time.deltaTime;
        //przemnó¿ przez klawiaturê
        rotation *= Input.GetAxis("Horizontal");
        //pomnó¿ przez prêdkoœæ obrotu
        rotation *= rotationSpeed;

        //dodaj obrót do obiektu
        //nie mo¿emy u¿yæ += poniewa¿ unity u¿ywa Quaterionów do zapisu rotacji
        transform.Rotate(rotation);
        UpdateUI();

    }

    private void UpdateUI()
    {
        Vector3 target = levelManagerObject.GetComponent<LevelManager>().exitPosition;
        //obroc znacznik w strone wyjscia
        transform.Find("NavUI").Find("TargetMarker").LookAt(target);
        //zmien ilosc procentow widoczna w interfejsie
        TextMeshPro shieldText = 
            GameObject.Find("Canvas").transform.Find("ShieldCapacityText").GetComponent<TextMeshPro>();
        shieldText.text = "Shield: " + shieldCapacity.ToString() + "%";
    }

    private void OnCollisionEnter(Collision collision)
    {
        //urachamia sie automatycznie jesli zetkniemy sie z innym coliderem

        //sprawdz czy dotknelismy asteroidy
        if (collision.collider.transform.CompareTag("Asteroid"))
        {
            //transform asteroidy
           Transform asteroid = collision.collider.transform;
            //policz wektor wedlug ktorego odepchniemy asteroide
            Vector3 shieldForce = asteroid.position - transform.position;
            //popchnij asteroide
            asteroid.GetComponent<Rigidbody>().AddForce(shieldForce * 5, ForceMode.Impulse);
            shieldCapacity -= 0.25f;
           
        }
    }
}
