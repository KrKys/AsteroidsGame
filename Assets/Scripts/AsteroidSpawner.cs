using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    //gracz (jego pozycja)
    Transform player;

    //prefab statycznej asteroidy
    public GameObject staticAsteroid;

    //czas od ostatnio wygenerowanej asteroidy
    float timeSinceSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //znajdz gracza i przypisz do zmienej
        player = GameObject.FindWithTag("Player").transform;

        //zresetuj czas
        timeSinceSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn > 1)
        {
            GameObject asteroid = SpawnAsteroid(staticAsteroid);
            timeSinceSpawn = 0;
        }
    }
       

    GameObject SpawnAsteroid(GameObject prefab)
    {
        //generyczna funkcja sluzaca do wylosowania wspolrzednych i umieszczenia w tym miejscu asteroidy z prefaba
        
        //losowa pozycja w odleglosci 10 jednostek od srodka swiata
        Vector3 randomPosition = Random.onUnitSphere * 10;

        //na³ó¿ pozycjê gracza - teraz mamy pozycje 10 jednostek od gracza
        randomPosition += player.position;

        //stworz zmienna asteroid, zesawnuj nowy asteroid korzystajac z prefaba w losowym miejscu, z rotacja domyslna (Quaternion,indentity)
        GameObject asteroid = Instantiate(staticAsteroid, randomPosition, Quaternion.identity);

        //zwroc asteroide jako wynik dzialania
        return asteroid;
    }
}
