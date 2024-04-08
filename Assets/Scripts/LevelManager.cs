using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    Transform player;
    //odleglosc od konca poziomu
    public float levelExitDistance = 100;
    //punkt konca poziomu
    public Vector3 exitPosition;
    public GameObject exitPrefab;
    //zmienna - flaga oznaczajaca ukonczenie poziomu
    public bool levelComplete = false;
    // Start is called before the first frame update
    public bool levelFailed = false;
    void Start()
    {
        //znajdz gracza
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //wylosuj pozycje na kole o srednicy 100 jednostek
        Vector2 spawnCircle = Random.insideUnitCircle; //randomowa pozycja x,y wewnatrz kola o r=1
        //chcemy tylko pozycje na okregu, a nie wewnatrz kola
        spawnCircle = spawnCircle.normalized; //pozycje x,y w odleglosci 1 od srodka
        spawnCircle *= levelExitDistance; //otrzymujemy pozycja x,y w odleglosci 100 od srodka
        //konwertujemy do Vector3
        exitPosition = new Vector3(spawnCircle.x, 0, spawnCircle.y);
        Instantiate(exitPrefab, exitPosition, Quaternion.identity);

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //funkcja jest uruchamiana kiedy dany poziom (level) jest zakonczony sukcesem
    public void OnSuccess()
    {
        //zatrzymaj fizyke gry
        Time.timeScale = 0f;

        levelComplete = true;
        Camera.main.transform.Find("LevelCompleteSound").GetComponent<AudioSource>().Play();
    }
    public void OnFailure()
    {
        Time.timeScale = 0f;
        levelFailed = true;
        Camera.main.transform.Find("GameOverSound").GetComponent<AudioSource>().Play();
    }
}


