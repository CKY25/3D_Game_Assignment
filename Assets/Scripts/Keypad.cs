using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public GameObject keypadUI;
    public RawImage interactUI;
    public GameObject Door;
    public GameObject door3;
    public GameObject cat;
    public GameObject lifter;
    public AudioClip granted;
    public AudioClip denied;
    public Button[] button;
    AudioSource audioSource;
    string player = "Player";
    string isUnlocked = "isUnlocked";
    string powerDoor = "PowerRoom";
    string specimenDoor = "SpecimenRoom";
    string ExitDoor = "ExitDoor";
    bool entered;
    bool solved;

    //Code
    [HideInInspector]
    public static int code;
    public static int code2;
    int code3 = 781562;
    string nr = null;
    int nrIndex = 0;
    public Text UiText = null;

    private void Awake()
    {
        code = Random.Range(100000, 999999);
        code2 = Random.Range(100000, 999999);
    }

    // Start is called before the first frame update
    void Start()
    {
        solved = false;
        audioSource = GetComponent<AudioSource>();
        keypadUI.SetActive(false);
        entered = false;
        Door.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
        Door.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.red;
        if(Door.CompareTag(specimenDoor))
        {
            Door.transform.GetChild(2).GetComponent<MeshRenderer>().material.color = Color.red;
            Door.transform.GetChild(3).GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (entered && Door.CompareTag(powerDoor))
        {
            if(Input.GetKeyDown("e"))
            {
                interactUI.enabled = false;
                keypadUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                cat.GetComponent<SC_FPSController>().lookSpeed = 0;
            }
            buttonMapping();
        }
        else if (entered && Door.CompareTag(specimenDoor))
        {
            if (Input.GetKeyDown("e"))
            {
                interactUI.enabled = false;
                keypadUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                cat.GetComponent<SC_FPSController>().lookSpeed = 0;
            }
            buttonMapping();
        }
        else if (entered && Door.CompareTag(ExitDoor))
        {
            if (Input.GetKeyDown("e"))
            {
                interactUI.enabled = false;
                keypadUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                cat.GetComponent<SC_FPSController>().lookSpeed = 0;
            }
            buttonMapping();
        }
        else
        {
            keypadUI.SetActive(false); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!solved)
        {
            if (other.gameObject.CompareTag(player))
            {
                interactUI.enabled = true;
                entered = true;
            }
        }
        Debug.Log(code + "    " + code2);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag(player))
        {
            interactUI.enabled = false;
            entered = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cat.GetComponent<SC_FPSController>().lookSpeed = 2;
        }
    }

    public void CodeFunction(string numbers)
    {
        nrIndex++;
        nr += numbers;
        UiText.text = nr;
    }

    public void Enter()
    {
        if (Door.CompareTag(powerDoor) && nr == code.ToString())
        {
            Door.GetComponent<Animator>().SetBool(isUnlocked, true);
            audioSource.clip = granted;
            audioSource.Play();
            solved = true;
            keypadUI.SetActive(false);
            Door.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.green;
            Door.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.green;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cat.GetComponent<SC_FPSController>().lookSpeed = 2;
        }
        else if (Door.CompareTag(specimenDoor) && nr == code2.ToString())
        {
            Door.GetComponent<Animator>().SetBool(isUnlocked, true);
            door3.GetComponent<Animator>().SetBool(isUnlocked, true);
            audioSource.clip = granted;
            audioSource.Play();
            solved = true;
            keypadUI.SetActive(false);
            Door.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.green;
            Door.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.green;
            Door.transform.GetChild(2).GetComponent<MeshRenderer>().material.color = Color.green;
            Door.transform.GetChild(3).GetComponent<MeshRenderer>().material.color = Color.green;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cat.GetComponent<SC_FPSController>().lookSpeed = 2;

            lifter.transform.GetChild(1).gameObject.SetActive(false);
            lifter.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (Door.CompareTag(ExitDoor) && nr == code3.ToString())
        {
            Door.GetComponent<Animator>().SetBool(isUnlocked, true);
            audioSource.clip = granted;
            audioSource.Play();
            solved = true;
            keypadUI.SetActive(false);
            Door.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.green;
            Door.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.green;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cat.GetComponent<SC_FPSController>().lookSpeed = 2;
        }
        else
        {
            audioSource.clip = denied;
            audioSource.Play();
            Delete();
        }
    }

    public void Delete()
    {
        nrIndex++;
        nr = null;
        UiText.text = nr;
    }

    void buttonMapping()
    {
        if (keypadUI.activeSelf)
        {
            if(Input.GetKeyDown("0"))
            {
                button[0].onClick.Invoke();
            }
            else if (Input.GetKeyDown("1"))
            {
                button[1].onClick.Invoke();
            }
            else if (Input.GetKeyDown("2"))
            {
                button[2].onClick.Invoke();
            }
            else if (Input.GetKeyDown("3"))
            {
                button[3].onClick.Invoke();
            }
            else if (Input.GetKeyDown("4"))
            {
                button[4].onClick.Invoke();
            }
            else if (Input.GetKeyDown("5"))
            {
                button[5].onClick.Invoke();
            }
            else if (Input.GetKeyDown("6"))
            {
                button[6].onClick.Invoke();
            }
            else if (Input.GetKeyDown("7"))
            {
                button[7].onClick.Invoke();
            }
            else if (Input.GetKeyDown("8"))
            {
                button[8].onClick.Invoke();
            }
            else if (Input.GetKeyDown("9"))
            {
                button[9].onClick.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                button[10].onClick.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                button[11].onClick.Invoke();
            }
        }
    }
}
