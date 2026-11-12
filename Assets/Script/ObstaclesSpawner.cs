using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    // Ứng dụng ObjectPooling và Coroutine
    private Queue<GameObject> obstaclesPool;
    [SerializeField] private int poolSize = 5;
    public GameObject pipePrefab;
    
    //Setting cho Coroutine
    [SerializeField] private float intervalTime = 2f;
    [SerializeField] private float height = 4.5f;
    
    

    private void Start()
    {
        obstaclesPool = new Queue<GameObject>();
        
        
        for (int i = 0; i < poolSize ; i++)
        {
            GameObject pipe = Instantiate(pipePrefab);
            PipeMovement pipeScript = pipe.GetComponent<PipeMovement>();
            pipeScript.OnPipeDespawned += OnReturnPipe;
            pipe.SetActive(false);
            obstaclesPool.Enqueue(pipe);
        }

        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnObstacles();
            yield return new WaitForSeconds(intervalTime);
        }
    }
    private GameObject GetPipe()
    {
        if (obstaclesPool.Count > 0)
        {
            GameObject pipe = obstaclesPool.Dequeue();
            pipe.SetActive(true);
            return pipe;
        }
        else
        {
            GameObject pipe = Instantiate(pipePrefab);
            PipeMovement pipeScript = pipe.GetComponent<PipeMovement>();
            pipeScript.OnPipeDespawned += OnReturnPipe;
            return pipe;
        }
    }

    private void OnReturnPipe(GameObject pipe)
    {
        pipe.SetActive(false);
        obstaclesPool.Enqueue(pipe);
    }

    private void SpawnObstacles()
    {
        GameObject pipe = GetPipe();
        float randomHeight = Random.Range(-height, height);
        pipe.transform.position = new Vector3(transform.position.x, randomHeight, 0);
    }
}
