using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    [Header("Movement")]
    public float speed;

    [Header("Paddle Settings")] 
    public GameObject paddleTop;
    public GameObject paddleBase;
    public GameObject paddleBottom;
    public int size = 1;

    private List<GameObject> paddleBasesTmp = new List<GameObject>();
    public List<GameObject> PaddleBases
    {
        get { return paddleBasesTmp; }
    }

    private void Start()
    {
        UpdatePaddle(size, paddleBasesTmp);
    }

    void Update()
    {
        // TODO: move paddle up and down
        // use player input
        // give value from -1f to 1f
        var verticalInput = Input.GetAxis("VerticalPlayer1");
        transform.Translate(Vector3.up * (Time.deltaTime * speed * verticalInput), Space.World);

    }

    public void UpdatePaddle(int amount, List<GameObject> bases)
    {
        if (amount == 1) return ;
        
        var top = paddleTop.transform.position;
        var center = paddleBase.transform.position;
        var bottom = paddleBottom.transform.position;

        var distanceTop = (top - center);
        var distanceBot = (bottom - center);

        if (amount < 1)
        {
            paddleBase.SetActive(false);
            paddleTop.transform.position = center + distanceTop/2;
            paddleBottom.transform.position = center + distanceBot / 2;
            return ;
        }

        for (int i = 1; i < amount; i++)
        {
            paddleTop.transform.Translate(distanceTop);
            var spawnedTop = Instantiate(paddleBase, transform);
            spawnedTop.transform.Translate(top);
            top = paddleTop.transform.position;

            paddleBottom.transform.Translate(distanceBot);
            var spawnedBot = Instantiate(paddleBase, transform);
            spawnedBot.transform.Translate(bottom);
            bottom = paddleBottom.transform.position;
            
            bases.Add(spawnedTop);
            bases.Add(spawnedBot);
        }
    }

    public void ResetPadle(List<GameObject> paddleBases)
    {
        var count = paddleBases.Count;
        for (int i = count; i > 0; i--)
        {
            DestroyImmediate(paddleBases[i-1].gameObject);
        }
        paddleBase.SetActive(true);
        paddleTop.transform.position = paddleBase.transform.position + Vector3.up;
        paddleBottom.transform.position = paddleBase.transform.position - Vector3.up;
        
        paddleBases.Clear();
    }

    
}
