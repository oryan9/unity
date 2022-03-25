using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;
using System.Text;
using System.Windows;

public class Generate : MonoBehaviour
{
    public static Generate instance;
    public GameObject blueCube;
    public Transform blueCubeParent;
    public int minX, maxX, minZ, maxZ;
    public LayerMask layerMask;



    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    public void Generates(int number)
    {
        if (number == 1)
        {
            Generates(blueCube,blueCubeParent);
        }
    }

    private void Generates(GameObject gameObject,Transform parent)
    {
        GameObject g = Instantiate(gameObject);
        g.transform.parent = parent;
        Vector3 desPos = GiveRandomPos();
        g.SetActive(false);
        Collider[] colliders = Physics.OverlapSphere(desPos, 1, layerMask);
        while (colliders.Length!=0)
        {
            Debug.Log("Çarptý:" + colliders[0].gameObject + " " + desPos);

            desPos = GiveRandomPos();
            colliders = Physics.OverlapSphere(desPos, 1, layerMask);
            g.SetActive(true);
            g.transform.position = desPos;
        }
    }

    private Vector3 GiveRandomPos()
    {
        return new Vector3(Random.Range(minX, maxX), blueCube.transform.position.y, Random.Range(minZ, maxZ)); 

    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
