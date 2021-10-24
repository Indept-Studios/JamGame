using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public GameController gc;
    public void rndEvent()
    {
        int rnd = Random.Range(1, 100);

        switch (rnd)
        {
            case 1:
                {
                    if (gc.trucks.Count >= 6)
                    {
                        gc.trucks.RemoveRange(0, (Random.Range(1, 5)));
                        gc.eventHappend.text = "You lost some Trucks by a theft";
                    }
                    break;
                }
            case 5:
                {
                    if (gc.offices.Count >= 6)
                    {
                        gc.offices.RemoveRange(0, (Random.Range(1, 5)));
                        gc.eventHappend.text = "You lost some Offices due a storm";
                    }
                    break;
                }
            case 10:
                {
                    gc.moneyController.Money = 0;
                    gc.eventHappend.text = "oh noooo, everything gone.... WHY???? WHY???";
                    break;
                }
            case 15:
                {
                    if (gc.isInternational == true)
                    {
                        gc.moneyController.Money +=500;
                        gc.eventHappend.text = "This damned taxes";
                    }
                    break;
                }
            case 20:
                {
                    if (gc.offices.Count >= 25)
                    {
                        gc.offices.RemoveRange(0, (Random.Range(1, 24)));
                        gc.moneyController.Money +=5000;
                        gc.eventHappend.text = "hard Times, u have to sell some Offices";
                    }
                    break;
                }
            case 25:
                if (gc.trucks.Count >= 50)
                {
                    gc.trucks.RemoveRange(0, (Random.Range(1, 49)));
                    gc.eventHappend.text = "You better watch u trucks more often, some a scrap iron";
                }
                break;
            case 30:
                {
                    if (gc.moneyController.Money > 50000)
                    {
                        gc.moneyController.Money -= Random.Range(1000, 1000000);
                        gc.eventHappend.text = "Burglary at the Bank you lost some money";
                    }
                    break;
                }
            case 35:
                {
                    if (gc.offices.Count >= 100)
                    {
                        gc.offices.RemoveRange(0, (Random.Range(1, 99)));
                        gc.moneyController.Money += 5000;
                        gc.eventHappend.text = "hard Times, u have to sell some Offices";
                    }
                    break;
                }
            default:
                break;
        }
    }
}
