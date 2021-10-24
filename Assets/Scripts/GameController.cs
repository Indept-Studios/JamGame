using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("UI")]
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

    [Header("Controller")]
    public EventController eventController;
    public MoneyController moneyController;

    [Header("Options")]
    public int dayDuration = 5;
    public int eraningsPerTruck;

    public int iTruckCost;
    public int iOfficeCost;
    public int iInternationalCost;

    public bool isInternational = false;

    [Header("not visible")]
    private int daysElapsed = 1;

    public List<Truck> trucks = new List<Truck>();
    public List<Office> offices = new List<Office>();

    void Start()
    {
        trucks.Add(new Truck());
        offices.Add(new Office());
        UpdateUI();
    }

    private void UpdateUI()
    {
        truckCount.text = trucks.Count.ToString();
        moneyCount.text = moneyController.Money.ToString();
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
        UpdateUI();
    }

    public void AddTruck()
    {
        if (moneyController.Money >= iTruckCost)
        {
            trucks.Add(new Truck());
            moneyController.Money -= iTruckCost;
            eventHappend.text = "You buy a new truck";
        }
        SwitchLevel();
        UpdateUI();
    }

    public void AddOffice()
    {
        if (moneyController.Money >= iOfficeCost)
        {
            offices.Add(new Office());
            moneyController.Money -= iOfficeCost;
            eventHappend.text = "You buy a new office";
        }
        SwitchLevel();
        UpdateUI();
    }

    public void SwitchInternational()
    {
        if (moneyController.Money >= iInternationalCost && trucks.Count >= 50 && offices.Count >= 10 && isInternational == false)
        {
            gerMap.gameObject.SetActive(false);
            euMap.gameObject.SetActive(true);
            moneyController.Money -= iInternationalCost;
            offices.Clear();
            offices.Add(new Office());
            isInternational = true;
            btnInternational.gameObject.SetActive(false);
            eraningsPerTruck *= 5;
            iOfficeCost *= 10;
            iTruckCost *= 5;
            eventHappend.text = "Very good, you grow international";
        }
        UpdateUI();
    }

    public void NextDay()
    {
        btnNextDay.enabled = false;
        btnNextDay.gameObject.SetActive(false);
        StartCoroutine(ElapsedTime());
        daysElapsed++;
        UpdateUI();
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
        eventController.rndEvent();
        UpdateUI();
    }

    public void AddMoney()
    {
        for (int i = 0; i <= offices.Count; i++)
        {
            foreach (Truck truck in trucks)
            {
                moneyController.Money += eraningsPerTruck;
            }
        }
        UpdateUI();
    }

    public void wonTheGame()
    {
        if (moneyController.Money > 250000 && trucks.Count > 500 && offices.Count > 50)
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
            moneyController.Money += 600000;
        }
        UpdateUI();
    }
}
