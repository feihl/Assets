using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxX;
    public Transform SpawnPoint;
    public float spawnRate;


    bool gameStarted = false;
    public GameObject tapText;
    public TextMeshProUGUI scoreText;
    int score = 0;
    void Update()
    {
        if(Input.GetMouseButton(0) && !gameStarted)
        {
            StartSpawing();

            gameStarted=true;
            tapText.SetActive(false);
        }
    }
    private void StartSpawing()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }
    private void SpawnBlock()
    {
        Vector3 spawnPos = SpawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate( block, spawnPos, Quaternion.identity);
        
        score++;
        scoreText.text = score.ToString();
    }
}