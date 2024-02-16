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
    public Transform parentPyramid;

    void Start()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane); //creating the floor
        plane.transform.position = new Vector3(0, -.4f, 0);

        sizeOfForest = 15;
        stonesRequired = 55;
        trees = new GameObject[sizeOfForest];
        stones = new GameObject[stonesRequired];

        parentTree = new GameObject("Forest").transform; // Create empty parent GameObject for forest
        generateForest(sizeOfForest, parentTree);

        parentPyramid = new GameObject("Pyramid").transform; // Create empty parent GameObject for pyramid
        createPyramid(stonesRequired, parentPyramid);
    }

    void generateForest(int sizeOfForest, Transform parent)
    {
        for (int i = 0; i < sizeOfForest; i++)
        {
            GameObject tree = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            tree.transform.SetParent(parent, false);
            tree.transform.position = new Vector3((Random.Range(-4.5f, -1f)), 0, (Random.Range(-4.5f, -1f)));
            tree.transform.localScale = new Vector3(Random.Range(.01f, 1.0f), Random.Range(.5f, 1.0f), Random.Range(.01f, 1.0f));
            tree.GetComponent<Renderer>().material.color = new Color(0, Random.Range(.1f, .7f), 0, 0);
        }
    }

    void createPyramid(int stonesRequired, Transform parent)
    {
        float layerWidth = 0.75f; // Width of each layer
        float offset = (layerWidth * 5 - layerWidth) / 2; // Offset to center the pyramid

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5 - i; j++)
            {
                for (int k = 0; k < 5 - i; k++)
                {
                    float layerOffset = (layerWidth * (5 - i) - layerWidth) / 2; // Offset to center the layer
                    GameObject stones = GameObject.CreatePrimitive(PrimitiveType.Cube); //creating the cube
                    stones.transform.SetParent(parent, false);
                    stones.transform.position = new Vector3(j * layerWidth - layerOffset, i * layerWidth, k * layerWidth - layerOffset) + new Vector3(-offset, 0, offset);
                    stones.transform.localScale = new Vector3(.75f, .75f, .75f);
                    stones.GetComponent<Renderer>().material.color = new Color(1, .6f, .3f * i, 0);
                }
            }
        }
    }
}
