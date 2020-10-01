using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Pool : MonoBehaviour
{
    public static Pool Instance = null;
    [System.Serializable]
    public class PoolObject
    {
        public GameObject prefab;
        public int amount;
    }
    public List<PoolObject> poolObjects;
    public List<GameObject> objectsOnScene;
    [SerializeField][Header("Координаты родительского объекта")] Transform spawner;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        foreach (PoolObject item in poolObjects)
        {
            for (int i = 0; i < item.amount; i++)
            {
                if (item.prefab.tag == "Bullet")
                {
                    GameObject objBullet = Instantiate(item.prefab, spawner);
                    objectsOnScene.Add(objBullet);
                    objBullet.SetActive(false);
                }
            }
        }
    }
    public GameObject Get(string tag)
    {
         foreach (GameObject item in objectsOnScene)
         {
             if(item.CompareTag(tag) && !item.activeInHierarchy)
             {
                 item.transform.position = new Vector3(Input.mousePosition.x, 0, 0);
                 item.SetActive(true);
                 return item;
             }
         }
        Debug.Log("Пуль нету");
        return null;
    }
}