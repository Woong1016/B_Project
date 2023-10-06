using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaner : MonoBehaviour
{

    public EnemyController[] enemiesToSpawn;    // ������ġ ����

    public Transform spawnPoint;       //������ġ����
    public float timeBetweenSpawns = 0.5f;  //���� <- �ð� -> ����
    public float spawncounter;  //�ð��� �帣�� �ؼ� �����Ǵ� �ð� ����

        public int amountToSpawn = 15;  // ���� �׷� ���� 
    // Start is called before the first frame update
    void Start()
    {
        spawncounter = timeBetweenSpawns;   // Counter�� �ð��� �Է�
    }

    // Update is called once per frame
    void Update()
    {
        if(amountToSpawn>0)     //��ȯ��  ���� �׷��� ����������
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
