using UnityEngine;

public class RandomModel : MonoBehaviour
{
    public GameObject[] models;

    void Start()
    {
        int index = Random.Range(0, models.Length);

        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(i == index);
        }
    }
}