using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ob : MonoBehaviour
{
    public GameObject[] objects;
    public Transform location;

    // Start is called before the first frame update
    void Start()
    {
        int randObject = Random.Range(0, objects.Length);
        Instantiate(objects[randObject], location.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
