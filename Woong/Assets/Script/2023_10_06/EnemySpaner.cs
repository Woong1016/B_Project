using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaner : MonoBehaviour
{

    public EnemyController[] enemiesToSpawn;    // 스폰위치 설정

    public Transform spawnPoint;       //스폰위치설정
    public float timeBetweenSpawns = 0.5f;  //스폰 <- 시간 -> 스폰
    public float spawncounter;  //시간을 흐르게 해서 스폰되는 시간 설정

        public int amountToSpawn = 15;  // 스폰 그룹 숫자 
    // Start is called before the first frame update
    void Start()
    {
        spawncounter = timeBetweenSpawns;   // Counter에 시간을 입력
    }

    // Update is called once per frame
    void Update()
    {
        if(amountToSpawn>0)     //소환할  몬스터 그룹이 남아있으면
        {
            spawncounter -= Time.deltaTime;  // 
            if(spawncounter<= 0 )
            {
                spawncounter = timeBetweenSpawns;
                Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], spawnPoint.position, spawnPoint.rotation);
                amountToSpawn -= 1;
            }
        }
    }
}
