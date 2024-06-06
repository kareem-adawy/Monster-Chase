using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterSpawner : MonoBehaviour
{

    public static bool isdead = false;

    [SerializeField]
    private GameObject[] monsterRefrence;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex, randomSide;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());

        isdead = false;


    }


    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterRefrence.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterRefrence[randomIndex]);

            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(6, 10);
            }
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(6, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }










    // Update is called once per frame
    private void Update()
    {
        if(isdead)
        {
            Invoke("ReloadScene", 3f);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
