using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BusWebsiteGen : MonoBehaviour
{
    public GameObject busPrefab;
    public List<BusGenerate> allBusPrefabs;
    public List<BusInfo> allBusInfos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0;i<allBusInfos.Count;i++)
        {
            GameObject newBus = Instantiate(busPrefab);
            BusGenerate busScript = newBus.GetComponent<BusGenerate>();
            busScript.Init(allBusInfos[i].origin, allBusInfos[i].destination, allBusInfos[i].date, allBusInfos[i].price);
            allBusPrefabs.Add(busScript);
        }
        for(int i = 0;i<allBusPrefabs.Count;i++)
        {
            BusGenerate busScript = allBusPrefabs[i].GetComponent<BusGenerate>();
            busScript.transform.SetParent(transform);
            busScript.transform.localPosition = new UnityEngine.Vector3(0, (busScript.busY + busScript.busMargin)*i, 0);
            busScript.transform.localScale = new UnityEngine.Vector3(1,1,1);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
