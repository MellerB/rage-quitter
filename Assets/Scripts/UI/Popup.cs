using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Core;
using Platformer.Model;

public class Popup : MonoBehaviour
{
    public GameObject UI;
    PlatformerModel model = Simulation.GetModel<PlatformerModel>();
    private int nextUpdate = 3;
    private string message = "You died!";

    public void Start()
    {
        UI.SetActive(true);
    }

    public void Update()
    {
        var alive = model.player.health.IsAlive;
        if (!alive)
        {
            UI.GetComponent<Text>().text = message;
        }
        else
        {
            UI.GetComponent<Text>().text = "";
        }

        // Change displayed message every `nextUpdate` seconds  
        if (Time.time >= nextUpdate && UI.GetComponent<Text>().text == "")
        {
            Debug.Log(Time.time + ">=" + nextUpdate);
            // Update next timeout
            nextUpdate = Mathf.FloorToInt(Time.time) + nextUpdate;
            // Change message
            message = RandomizeText();
        }
    }

    public string RandomizeText()
    {
        string[] choices = new string[10];
        choices[0] = "Just quit already!";
        choices[1] = "You just died, again...";
        choices[2] = "HAHA, you suck!";
        choices[3] = "LOL!";
        choices[4] = "Disappointing!";
        choices[5] = "You are bad at this game!";
        choices[6] = "OMG! again?";
        choices[7] = "meh...";
        choices[8] = "You died!";
        choices[9] = "Are you blind?";

        int rand = Random.Range(0, 9);
        return choices[rand];
    }
}
