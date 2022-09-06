using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalSpawner : MonoBehaviour
{
    public GameObject Slime;
    public GameObject Skelly;
    public GameObject Eyes;
    public GameObject Ghost;

    public int xPos;
    public int yPos;
    public int enemyCount;

    public int setX1;
    public int setX2;

    public int setY1;
    public int setY2;

    public int RandomEnemy;

    void Update()
    {
        StartCoroutine(EnemyDrop());
        GameObject Tracker = GameObject.FindGameObjectWithTag("EnemiesKilled");
        
        if(Tracker.GetComponent<IntToText>().value >= 50)
        {
            PlayerPrefs.SetInt("Goal 1", 1);
        }

        if(Tracker.GetComponent<IntToText>().value >= 100)
        {
            PlayerPrefs.SetInt("Goal 2", 1);
        }

    }

    IEnumerator EnemyDrop()
    {
        GameObject Tracker = GameObject.FindGameObjectWithTag("EnemiesKilled");
        var StageTime = Tracker.GetComponent<IntToText>().TimerValue;

        if (StageTime <= 30)
        {
            while (enemyCount < 5)
            {
                xPos = Random.Range(setX1, setX2);
                yPos = Random.Range(setY1, setY2);
                Instantiate(Slime, new Vector3(xPos, yPos, 0), Quaternion.identity);
                enemyCount += 1;
                yield return new WaitForSeconds(1f);
            }
        } else if(StageTime <= 200 && StageTime > 30)
        {
            while (enemyCount < 7)
            {
                xPos = Random.Range(setX1, setX2);
                yPos = Random.Range(setY1, setY2);
                RandomEnemy = Random.Range(1, 4);

                if (RandomEnemy <= 1)
                {
                    Instantiate(Slime, new Vector3(xPos, yPos, 0), Quaternion.identity);

                }
                else if (RandomEnemy <= 2 && RandomEnemy > 1)
                {
                    Instantiate(Skelly, new Vector3(xPos, yPos, 0), Quaternion.identity);

                }
                else if (RandomEnemy <= 4 && RandomEnemy > 2)
                {
                    Instantiate(Eyes, new Vector3(xPos, yPos, 0), Quaternion.identity);
                }

                enemyCount += 1;
                yield return new WaitForSeconds(1f);
                
            }
        } else if (StageTime <= 700 && StageTime > 200)
        {
            while (enemyCount < 10)
            {
                xPos = Random.Range(setX1, setX2);
                yPos = Random.Range(setY1, setY2);
                RandomEnemy = Random.Range(1, 5);

                if (RandomEnemy <= 1)
                {
                    Instantiate(Slime, new Vector3(xPos, yPos, 0), Quaternion.identity);

                }
                else if (RandomEnemy <= 2 && RandomEnemy > 1)
                {
                    Instantiate(Skelly, new Vector3(xPos, yPos, 0), Quaternion.identity);

                }
                else if (RandomEnemy <= 4 && RandomEnemy > 2)
                {
                    Instantiate(Eyes, new Vector3(xPos, yPos, 0), Quaternion.identity);
                } else if (RandomEnemy <= 5 && RandomEnemy > 4)
                {
                    Instantiate(Ghost, new Vector3(xPos, yPos, 0), Quaternion.identity);
                }

                enemyCount += 1;
                yield return new WaitForSeconds(1f);
                
            }  

        } else if (StageTime > 700)
        {
            while (enemyCount < 13)
            {
                xPos = Random.Range(setX1, setX2);
                yPos = Random.Range(setY1, setY2);
                RandomEnemy = Random.Range(1, 5);

                if (RandomEnemy <= 1)
                {
                    Instantiate(Slime, new Vector3(xPos, yPos, 0), Quaternion.identity);

                }
                else if (RandomEnemy <= 2 && RandomEnemy > 1)
                {
                    Instantiate(Skelly, new Vector3(xPos, yPos, 0), Quaternion.identity);

                }
                else if (RandomEnemy <= 4 && RandomEnemy > 2)
                {
                    Instantiate(Eyes, new Vector3(xPos, yPos, 0), Quaternion.identity);
                }
                else if (RandomEnemy <= 5 && RandomEnemy > 4)
                {
                    Instantiate(Ghost, new Vector3(xPos, yPos, 0), Quaternion.identity);
                }

                enemyCount += 1;
                yield return new WaitForSeconds(1f);
                
            }
        }
        

        

        

    }

}
