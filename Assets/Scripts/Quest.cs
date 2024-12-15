using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest : MonoBehaviour
{
    TextMeshProUGUI tmp;
    public GameObject specimenDoor;
    public GameObject powerDoor;
    public GameObject giantDoor;
    public GameObject exitDoor;
    bool specimenRoomUnlocked;
    bool powerRoomUnlocked;
    bool giantRoomUnlocked;
    bool exitRoomUnlocked;
    string isUnlocked = "isUnlocked";
    string firstQuest = "Find the passcode to unlock the Specimen Room!";
    string secondQuest = "Find the passcode to unlock the Power Room!";
    string thirdQuest = "Find all the power cell scattered around\n the map to activate the power!   ";
    string lastQuest = "Find the passcode to unlock the Exit Door!";
    string exitQuest = "Exit the laboratory!";

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        specimenRoomUnlocked = specimenDoor.GetComponent<Animator>().GetBool(isUnlocked);
        powerRoomUnlocked = powerDoor.GetComponent<Animator>().GetBool(isUnlocked);
        giantRoomUnlocked = giantDoor.GetComponent<Animator>().GetBool(isUnlocked);
        exitRoomUnlocked = exitDoor.GetComponent<Animator>().GetBool(isUnlocked);

        if(!specimenRoomUnlocked && !powerRoomUnlocked && !giantRoomUnlocked && !exitRoomUnlocked)
        {
            tmp.text = firstQuest;
        }
        else if (specimenRoomUnlocked && !powerRoomUnlocked && !giantRoomUnlocked && !exitRoomUnlocked)
        {
            tmp.text = secondQuest;
        }
        else if (specimenRoomUnlocked && powerRoomUnlocked && !giantRoomUnlocked && !exitRoomUnlocked)
        {
            tmp.text = thirdQuest + BatteryActivateDoor.batteryRecovered + "/3";
        }
        else if (specimenRoomUnlocked && powerRoomUnlocked && giantRoomUnlocked && !exitRoomUnlocked)
        {
            tmp.text = lastQuest;
        }
        else if (specimenRoomUnlocked && powerRoomUnlocked && giantRoomUnlocked && exitRoomUnlocked)
        {
            tmp.text = exitQuest;
        }
    }
}
