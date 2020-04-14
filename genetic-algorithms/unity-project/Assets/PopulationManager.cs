using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PopulationManager : MonoBehaviour
{
    public GameObject personPrefab;
    public int populationSize = 10;
    List<GameObject> population = new List<GameObject>();
    public static float elapsed = 0;
    int trialTime = 10;
    int generation = 1;

    GUIStyle guiSytle = new GUIStyle();
    void OnGui()
    {
        guiSytle.fontSize = 50;
        guiSytle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 20), "Generation: " + generation, guiSytle);
        GUI.Label(new Rect(10, 65, 100, 20), "Trial Time: " + (int)elapsed, guiSytle);
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < populationSize; i++)
        {
            Vector3 position = new Vector3(Random.Range(-7, 7), Random.Range(-4.5f, 4.5f), 0);
            GameObject gameObject = Instantiate(personPrefab, position, Quaternion.identity);
            gameObject.GetComponent<DNA>().r = Random.Range(0.0f, 1.0f);
            gameObject.GetComponent<DNA>().g = Random.Range(0.0f, 1.0f);
            gameObject.GetComponent<DNA>().b = Random.Range(0.0f, 1.0f);
            population.Add(gameObject);
        }
        
    }

    void BreedNewPopulation()
    {
        List<GameObject> newPopulation = new List<GameObject>();
        //get rid of unfit individuals
        List<GameObject> sortedList = population.OrderBy(o => o.GetComponent<DNA>().timeToDie).ToList();
        

        population.Clear();
        //Breed upper half of sorted list
        for (int i = (int) (sortedList.Count /2.0f) - 1; i < sortedList.Count -1; i ++)
        {
            population.Add(Breed(sortedList[i], sortedList[i + 1]));
            population.Add(Breed(sortedList[i + 1], sortedList[i]));
        }

        //destroy all parents and previous population
        for(int i = 0; i < sortedList.Count; i ++)
        {
            Destroy(sortedList[i]);
        }
        generation++;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > trialTime)
        {
            BreedNewPopulation();
            elapsed = 0;
        }
        
    }
}
