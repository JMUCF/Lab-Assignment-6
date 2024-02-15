using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class everything : MonoBehaviour
{
    public int sizeOfForest;
    public int stonesRequired;
    public GameObject[] trees;
    public GameObject[] stones;
    public Transform parentTree;

    void Start()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane); //creating the floor
        plane.transform.position = new Vector3(0, -.5f, 0);

        sizeOfForest = 15;
        stonesRequired = 55;
        trees = new GameObject[sizeOfForest];
        stones = new GameObject[stonesRequired];

        Debug.Log("length is: " + trees.Length);
        generateForest(sizeOfForest);
        createPyramid(stonesRequired);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void generateForest(int sizeOfForest)
    {
        for (int i = 0; i < sizeOfForest; i++)
        {
            GameObject tree = GameObject.CreatePrimitive(PrimitiveType.Cylinder); //creating the floor
            //tree.transform.SetParent(parentTree, false);
            tree.transform.position = new Vector3((Random.Range(-4f, -1f)), 0, (Random.Range(-4.5f, -1f)));
            tree.transform.localScale = new Vector3(Random.Range(.01f, 1.0f), Random.Range(.01f, 1.0f), Random.Range(.01f, 1.0f));
            tree.GetComponent<Renderer>().material.color = new Color(0, Random.Range(.1f, .7f), 0, 0);
            //Debug.Log(i);
        }
    }

    void createPyramid(int stonesRequired)
    {

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5 - i; j++)
            {
                for (int k = 0; k < 5 - i; k++)
                {
                    GameObject stones = GameObject.CreatePrimitive(PrimitiveType.Cube); //creating the cube
                    stones.transform.position = new Vector3(j, i, k);
                    stones.transform.localScale = new Vector3(.75f, .75f, .75f);
                    stones.GetComponent<Renderer>().material.color = new Color(1, .6f, .3f * i, 0);
                }
            }
            //GameObject stones  = GameObject.CreatePrimitive(PrimitiveType.Cube); //creating the cube
            //stones.transform.position = new Vector3(0,1,0);
        }
    }

}
