using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpManagerNew : MonoBehaviour
{
    [Header("Object Lain")]
    public Paddle enemyPaddle;
    public BrickSpawner brickSpawner;
    
    [Header("Status")]
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public int spawnInterval;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    
    public List<GameObject> powerUpTemplateList;

    public List<GameObject> powerUpListActive;
    public List<GameObject> powerUpListNotActive;
    private float _timer;

    private void Start()
    {
        Init();
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > spawnInterval)
        {
            _timer = 0;
            GenerateRandomPowerUp();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
        }
    }

    private void Init()
    {
        _timer                = 0;
        powerUpListActive    = new List<GameObject>();
        powerUpListNotActive = new List<GameObject>();
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(
            new Vector2(
                    Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), 
                    Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)
                )
            );
    }
    
    public void GenerateRandomPowerUp(Vector2 position)
    {

        if (powerUpListNotActive.Count >= maxPowerUpAmount)
        {
            StartCoroutine(PowerUpTimer());
            return;
        }
        
        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y)
        {
            return;
        }
        
        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = 
            Instantiate(
                powerUpTemplateList[randomIndex],
                new Vector3(position.x, position.y, 0),
                Quaternion.identity, spawnArea
            );
        // powerUpTemplateList[randomIndex].transform.position.z
        
        powerUp.SetActive(true);
        powerUp.GetComponent<BasePU>().manager = this;

        powerUpListNotActive.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpListNotActive.Remove(powerUp);

        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpListNotActive.Count > 0)
        {
            //RemovePowerUp(_powerUpList[0]);
        }
    }

    private IEnumerator PowerUpTimer()
    {
        yield return new WaitForSeconds(5f);
        RemovePowerUp(powerUpListNotActive[0]);
    }

     private void OnDrawGizmos()
     {
         float centerPosX = (powerUpAreaMax.x + powerUpAreaMin.x) / 2;
         float centerPosY = (powerUpAreaMax.y + powerUpAreaMin.y) / 2;

         var center = new Vector2(centerPosX, centerPosY);
         var area = new Vector2(powerUpAreaMax.x - powerUpAreaMin.x, powerUpAreaMax.y - powerUpAreaMin.y);

         Gizmos.color = Color.green;
         Gizmos.DrawWireCube(center, area);
     }
    
}
