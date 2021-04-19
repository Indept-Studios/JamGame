using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text truckCount;
    public Text moneyCount;
    public Text officCount;
    public Text elapsedDays;
    public Text waitForSeconds;
    public Text eventHappend;
    public Text truckCost;
    public Text officeCost;
    public Text internationalCost;

    public GameObject nextDayPanel;
    public GameObject winingPanel;

    public SpriteRenderer gerMap;
    public SpriteRenderer euMap;

    public Button btnNextDay;
    public Button btnNewOffice;
    public Button btnInternational;

    public Events events;

    public MoneyController mc;

    public List<Truck> trucks = new List<Truck>();
    public List<Office> offices = new List<Office>();

    public int money = 0;
    public int dayDuration = 5;
    public int eraningsPerTruck;

    public int iTruckCost;
    public int iOfficeCost;
    public int iInternationalCost;

    public bool isInternational = false;

    private int daysElapsed =1;

    void Start()
    {
        trucks.Add(new Truck());
        offices.Add(new Office());
        UpdateText();
    }
      
    private void UpdateText()
    {
        truckCount.text = trucks.Count.ToString();
        moneyCount.text = money.ToString();
        officCount.text = offices.Count.ToString();
        elapsedDays.text = daysElapsed.ToString();
        truckCost.text = iTruckCost.ToString();
        officeCost.text = iOfficeCost.ToString();
        internationalCost.text = iInternationalCost.ToString();
    }

    public void SwitchLevel()
    {
        if (trucks.Count >= 5)
        {
            btnNewOffice.gameObject.SetActive(true);
        }
        if (offices.Count >= 10 && isInternational == false)
        {
            btnInternational.gameObject.SetActive(true);
        }
        UpdateText();
    }

    public void AddTruck()
    {
        if (money >= iTruckCost)
        {
            trucks.Add(new Truck());
            money -= iTruckCost;
            eventHappend.text = "You buy a new truck";
        }
        SwitchLevel();
        UpdateText();
    }

    public void AddOffice()
    {
        if (money >= iOfficeCost)
        {
            offices.Add(new Office());
            money -= iOfficeCost;
            eventHappend.text = "You buy a new office";
        }
        SwitchLevel();
        UpdateText();
    }

    public void SwitchInternational()
    {
        if (money >= iInternationalCost && trucks.Count >= 50 && offices.Count >= 10 && isInternational == false)
        {
            gerMap.gameObject.SetActive(false);
            euMap.gameObject.SetActive(true);
            money -= iInternationalCost;
            offices.Clear();
            offices.Add(new Office());
            isInternational = true;
            btnInternational.gameObject.SetActive(false);
            eraningsPerTruck *= 5;
            iOfficeCost *= 10;
            iTruckCost *= 5;
            eventHappend.text = "Very good, you grow international";
        }
        UpdateText();
    }

    public void NextDay()
    {
        btnNextDay.enabled = false;
        btnNextDay.gameObject.SetActive(false);
        StartCoroutine(ElapsedTime());
        daysElapsed++;
        UpdateText();
        wonTheGame();
    }

    IEnumerator ElapsedTime()
    {
        nextDayPanel.gameObject.SetActive(true);
        for (int i = 1; i <= dayDuration; i++)
        {
            waitForSeconds.text = i.ToString();
            yield return new WaitForSecondsRealtime(1);
        }
        nextDayPanel.gameObject.SetActive(false);
        btnNextDay.enabled = true;
        btnNextDay.gameObject.SetActive(true);
        AddMoney();
        events.rndEvent();
        UpdateText();
    }

    public void AddMoney()
    {
        for (int i = 0; i <= offices.Count; i++)
        {
            foreach (Truck truck in trucks)
            {
                money += eraningsPerTruck;
                
            }
           
        }
        UpdateText();
    }

    public void wonTheGame()
    {
        if (money > 250000 && trucks.Count > 500 && offices.Count > 50)
        {
            winingPanel.gameObject.SetActive(true);
        }
    }

    public void winingTest()
    {
        for (int i = 0; i < 51; i++)
        {
            trucks.Add(new Truck());
            offices.Add(new Office());
            money = 600000;
        }
        UpdateText();
    }

}
