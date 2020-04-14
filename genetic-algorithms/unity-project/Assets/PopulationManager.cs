using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationManager : MonoBehaviour
{
    public GameObject personPrefab;
    public int populationSize = 10;
    List<GameObject> population = new List<GameObject>();
    public static float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < populationSize; i++)
        {
            Vector3 position = new Vector3(Random.Range(-9, 9), Random.Range(-4.5f, 4.5f), 0);
            GameObject gameObject = Instantiate(personPrefab, position, Quaternion.identity);
            gameObject.GetComponent<DNA>().r = Random.Range(0.0f, 1.0f);
            gameObject.GetComponent<DNA>().g = Random.Range(0.0f, 1.0f);
            gameObject.GetComponent<DNA>().b = Random.Range(0.0f, 1.0f);
            population.Add(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
