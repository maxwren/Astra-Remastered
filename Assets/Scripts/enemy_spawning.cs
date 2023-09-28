using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawning : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject meteor_bgPrefab;
    public GameObject meteor_bgPrefab2;
    private int randomAbility;
    public float abilityRespawnTime = 30f;
    public float respawnTime = 1.0f;
    public float meteorBGrespawnTime;

    public GameObject boostPrefab;
    public GameObject shieldPrefab;
    public GameObject fieldPrefab;
    public GameObject gunPrefab;

    [SerializeField] float bgMeteorLowerSpawnValue;
    [SerializeField] float bgMeteorHigherSpawnValue;

    [SerializeField] GameObject meteorMainBg;
    [SerializeField] GameObject meteorMainBg2;

    public int playerScore;

    [SerializeField] bool spawnMeteorbgCheck;

    [SerializeField] int notSoRandomAbility = 0;

    [SerializeField] float meteorMainBgRespawnTime;
    [SerializeField] bool spawnMeteorMainBgCheck;

    [SerializeField] float verticalBorder = 0.55f;
    [SerializeField] float offsetWidth;
    [SerializeField] float offsetHeight; //1.1 for spaceship
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyCurrent());
        StartCoroutine(abilitiesCurrent());
        StartCoroutine(meteorbgCurrent());
        StartCoroutine(meteorbg2Current());
        StartCoroutine(meteorMainBgCurrent());
        StartCoroutine(meteorMainBgCurrent2());
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(enemyPrefab) as GameObject;
        a.transform.position = new Vector2(1.5f, Random.Range(-screenBounds.y + offsetHeight, screenBounds.y - offsetHeight));
    }

    // ABILITIES
    private void spawnAbility()
    {
        randomAbility = Random.Range(1, 5); //1 to 5
        if (notSoRandomAbility != 0)
        {
            randomAbility = notSoRandomAbility;
        }
        if (randomAbility == 1)
        {
            GameObject b = Instantiate(boostPrefab) as GameObject;
            b.transform.position = new Vector2(1.5f, Random.Range(-screenBounds.y + offsetHeight, screenBounds.y - offsetHeight));
        }
        if (randomAbility == 2)
        {
            GameObject b = Instantiate(shieldPrefab) as GameObject;
            b.transform.position = new Vector2(1.5f, Random.Range(-screenBounds.y + offsetHeight, screenBounds.y - offsetHeight));
            Debug.Log("Shield has been summoned");
        }
        if (randomAbility == 3)
        {
            GameObject b = Instantiate(fieldPrefab) as GameObject;
            b.transform.position = new Vector2(1.5f, Random.Range(-screenBounds.y + offsetHeight, screenBounds.y - offsetHeight));
        }
        if (randomAbility == 4)
        {
            //GameObject b = Instantiate(gunPrefab) as GameObject;
            //b.transform.position = new Vector2(1.5f, Random.Range(-screenBounds.y + offsetHeight, screenBounds.y - offsetHeight));

            //MAKE GUN STRONK!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }
    private void spawnMeteorbg()
    {
        if (spawnMeteorbgCheck)
        {
            GameObject b = Instantiate(meteor_bgPrefab) as GameObject;
            b.transform.position = new Vector2(1.5f, Random.Range(-0.7f, 0f));
        }
    }
    private void spawnMeteorbg2()
    {
        if (spawnMeteorbgCheck)
        {
            GameObject b = Instantiate(meteor_bgPrefab2) as GameObject;
            b.transform.position = new Vector2(1.5f, Random.Range(-0.7f, 0f));
        }
    }

    IEnumerator enemyCurrent()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
    IEnumerator abilitiesCurrent()
    {
        while(true)
        {
            yield return new WaitForSeconds(abilityRespawnTime);
            spawnAbility();
        }
    }
    IEnumerator meteorbgCurrent()
    {
        while (true)
        {
            yield return new WaitForSeconds(meteorBGrespawnTime);
            spawnMeteorbg();
        }
    }
    IEnumerator meteorbg2Current()
    {
        while (true)
        {
            yield return new WaitForSeconds(meteorBGrespawnTime);
            spawnMeteorbg2();
        }
    }
    IEnumerator meteorMainBgCurrent()
    {
        while (true)
        {
            yield return new WaitForSeconds(meteorMainBgRespawnTime);
            spawnMeteorMainBg();
        }
    }
    void spawnMeteorMainBg()
    {
        if (spawnMeteorMainBgCheck)
        {
            GameObject b = Instantiate(meteorMainBg) as GameObject;
            b.transform.position = new Vector2(1.5f, Random.Range(-screenBounds.y + offsetHeight, screenBounds.y - offsetHeight));
        }
    }
    void spawnMeteorMainBg2()
    {
        if (spawnMeteorMainBgCheck)
        {
            GameObject b = Instantiate(meteorMainBg2) as GameObject;
            b.transform.position = new Vector2(1.5f, Random.Range(-screenBounds.y + offsetHeight, screenBounds.y - offsetHeight));
        }
    }
    IEnumerator meteorMainBgCurrent2()
    {
        while (true)
        {
            yield return new WaitForSeconds(meteorMainBgRespawnTime);
            spawnMeteorMainBg2();
        }
    }

    // Update is called once per frame
    void Update()
    {
        meteorBGrespawnTime = Random.Range(bgMeteorLowerSpawnValue, bgMeteorHigherSpawnValue); // 0.5 to 3
    }
    private void FixedUpdate()
    {
        playerScore = updateScore.playerScore;
        if ((updateScore.fakePlayerScore != 0) && (updateScore.fakePlayerScore % 5000 == 0))
        {
            if (respawnTime > 1f)
            {
                respawnTime -= 0.1f;
                Debug.Log("Respawn time is " + respawnTime);
            }
        }
    }
}
