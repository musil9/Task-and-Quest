using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 오브젝트 풀링
// 1. 최초로 갯수에 맞도록 오브젝트를 생성한다.
// 2. Queue 에 넣어서 관리한다.
// 3. 사용이 끝나면, Pool 로 반환한다.
// 4. 
[System.Serializable]
public class Pool
{
    public string name;
    public GameObject prefab;
    public int length;
}
public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance;
    public List<Pool> pools;

    private Queue<GameObject> ObjectPoolQueue = new Queue<GameObject>();
    private Queue<GameObject> ActivePoolQueue = new Queue<GameObject>();

    public static ObjectPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObjectPool>();
                if (instance == null)
                {
                    instance = new GameObject("ObjectPool").AddComponent<ObjectPool>();
                    DontDestroyOnLoad(instance.gameObject);
                }
            }
            return instance;
        }
    }
    void Start()
    {
        InitializePool();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            MakeObject();
        }
    }

    private void InitializePool()
    {
        foreach (var pool in pools)
        {
            for (int i = 0; i < pool.length; i++)
            {
                 GameObject obj = Instantiate(pool.prefab);
                 obj.transform.SetParent(this.transform);
                 ObjectPoolQueue.Enqueue(obj);
                 obj.SetActive(false);
                
            }
        }
        
    }

    private void MakeObject()
    {
        if(ObjectPoolQueue.Count > 0)
        {
            Debug.Log("오브젝트 풀 큐의 카운트가 0보다 많다.");
            GameObject poolObj = ObjectPoolQueue.Dequeue();
            poolObj.transform.SetParent(null);
            poolObj.SetActive(true);

            ActivePoolQueue.Enqueue(poolObj);
       

        }
        else
        {
            Debug.Log("오브젝트 풀 큐의 카운트가 0보다 적다.");
          
            foreach (Pool pool in pools)
            {
                GameObject newObj = Instantiate(pool.prefab);
                newObj.SetActive(false);
                newObj.transform.SetParent(this.transform);
                ObjectPoolQueue.Enqueue(newObj);
         
            }
        }
    }

    public void ReturnToPool()
    {
        GameObject activeObj = ActivePoolQueue.Dequeue();
        activeObj.transform.position = new Vector3(0f, 0.5f, 0f);
        activeObj.transform.SetParent(this.transform);
        activeObj.SetActive(false);

    }
}
