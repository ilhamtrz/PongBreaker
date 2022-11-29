using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManagerNew : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public int spawnInterval;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;
    public List<GameObject> powerUpTemplateList;

    private List<GameObject> powerUpList;
    private float timer;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));

    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
            Debug.Log(powerUpList[0].transform.position);
        }
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {

        if (powerUpList.Count >= maxPowerUpAmount)
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

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex],
            new Vector3(position.x, position.y,
            powerUpTemplateList[randomIndex].transform.position.z),
            Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }

    private IEnumerator PowerUpTimer()
    {
        yield return new WaitForSeconds(5f);
        RemovePowerUp(powerUpList[0]);
    }

    /*private void OnDrawGizmos()
    {
        float centerPosX = powerUpAreaMax.x - powerUpAreaMin.x / 2;
        float centerPosY = powerUpAreaMax.y - powerUpAreaMin.y / 2;
        var center = new Vector2(centerPosX, centerPosY);
        var area = new Vector2(powerUpAreaMax.x - powerUpAreaMin.x, powerUpAreaMax.y - powerUpAreaMin.y);

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(center, area);
    }*/
}
