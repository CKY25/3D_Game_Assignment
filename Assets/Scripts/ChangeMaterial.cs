using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{

    public Material[] material;
    public GameObject[] monitor;
    string clipboard = "ClipBoard";
    string pass = "Pass";
    static List<Color> color = new List<Color>{ Color.red, Color.yellow, Color.green, Color.blue, Color.cyan, Color.magenta };
    public int index;
    int num;

    // Start is called before the first frame update
    void Start()
    {

        if(gameObject.transform.parent.tag == clipboard)
        {
            switch (index)
            {
                case 0:
                    num = Keypad.code / 100000;
                    GetComponent<MeshRenderer>().material = material[num];
                    int a = Random.Range(0, color.Count);
                    GetComponent<MeshRenderer>().material.color = color[a];
                    monitor[0].GetComponent<MeshRenderer>().material.color = color[a];
                    color.Remove(color[a]);
                    break;
                case 1:
                    num = Keypad.code / 10000 % 10;
                    GetComponent<MeshRenderer>().material = material[num];
                    int b = Random.Range(0, color.Count);
                    GetComponent<MeshRenderer>().material.color = color[b];
                    monitor[1].GetComponent<MeshRenderer>().material.color = color[b];
                    color.Remove(color[b]);
                    break;
                case 2:
                    num = Keypad.code / 1000 % 10;
                    GetComponent<MeshRenderer>().material = material[num];
                    int c = Random.Range(0, color.Count);
                    GetComponent<MeshRenderer>().material.color = color[c];
                    monitor[2].GetComponent<MeshRenderer>().material.color = color[c];
                    color.Remove(color[c]);
                    break;
                case 3:
                    num = Keypad.code / 100 % 10;
                    GetComponent<MeshRenderer>().material = material[num];
                    int d = Random.Range(0, color.Count);
                    GetComponent<MeshRenderer>().material.color = color[d];
                    monitor[3].GetComponent<MeshRenderer>().material.color = color[d];
                    color.Remove(color[d]);
                    break;
                case 4:
                    num = Keypad.code / 10 % 10;
                    GetComponent<MeshRenderer>().material = material[num];
                    int e = Random.Range(0, color.Count);
                    GetComponent<MeshRenderer>().material.color = color[e];
                    monitor[4].GetComponent<MeshRenderer>().material.color = color[e];
                    color.Remove(color[e]);
                    break;
                case 5:
                    num = Keypad.code % 10;
                    GetComponent<MeshRenderer>().material = material[num];
                    int f = Random.Range(0, color.Count);
                    GetComponent<MeshRenderer>().material.color = color[f];
                    monitor[5].GetComponent<MeshRenderer>().material.color = color[f];
                    color.Remove(color[f]);
                    break;
            }
        }
        else if (gameObject.transform.parent.tag == pass)
        {
            switch (index)
            {
                case 0:
                    num = Keypad.code2 / 100000;
                    GetComponent<MeshRenderer>().material = material[num];
                    GetComponent<MeshRenderer>().material.color = Color.yellow;
                    break;
                case 1:
                    num = Keypad.code2 / 10000 % 10;
                    GetComponent<MeshRenderer>().material = material[num];
                    GetComponent<MeshRenderer>().material.color = Color.cyan;
                    break;
                case 2:
                    num = Keypad.code2 / 1000 % 10;
                    GetComponent<MeshRenderer>().material = material[num];
                    GetComponent<MeshRenderer>().material.color = Color.green;
                    break;
                case 3:
                    num = Keypad.code2 / 100 % 10;
                    GetComponent<MeshRenderer>().material = material[num];
                    GetComponent<MeshRenderer>().material.color = Color.magenta;
                    break;
                case 4:
                    num = Keypad.code2 / 10 % 10;
                    GetComponent<MeshRenderer>().material = material[num];
                    GetComponent<MeshRenderer>().material.color = Color.red;
                    break;
                case 5:
                    num = Keypad.code2 % 10;
                    GetComponent<MeshRenderer>().material = material[num];
                    GetComponent<MeshRenderer>().material.color = Color.blue;
                    break;
            }
        }
        
        if(color.Count == 0)
        {
            color.Add(Color.red);
            color.Add(Color.yellow);
            color.Add(Color.green);
            color.Add(Color.blue);
            color.Add(Color.cyan);
            color.Add(Color.magenta);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
