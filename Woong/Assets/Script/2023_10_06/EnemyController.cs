using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;

public class EnemyController : MonoBehaviour
{
    public float speedMod = 1.0f;               //�ӵ� ����
    public float timeSinceStart = 0.0f;         //�ð� ����
    public bool modeEnd = true;                 //State ���� ���� BOOL
    public float moveSpeed;

public EnemyPath thePath;  //���Ͱ� ������ �ִ� path ��  
    private int currentPoint;       //  ���ݸ��° ����Ʈ�� ���ϰ� �ִ��� ����

    private bool reachEnd;  // ���� �Ϸ� üũ 

    // Start is called before the first frame update
    void Start()
    {
        if(thePath==null)
        {
            thePath = FindObjectOfType<EnemyPath>();    // ��� ������Ʈ�� �˻��ؼ� ���ʹ� �н��� �ִ� ������Ʈ�� �����´�.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (modeEnd == false)
        {
            timeSinceStart -= Time.deltaTime;

            if (timeSinceStart <= 0.0f)
            {
                speedMod = 1.0f;
                modeEnd = true;
            }
        }
        if (reachEnd == false)  // if(!reacheEnd) ���� ����
        {
            transform.LookAt(thePath.points[currentPoint]);// ���ʹ� ���� ������ ���ؼ� ����. Lookat �̰� �� �߿��� ������ �ʿ���

            //MoveToward �Լ� (����ġ, Ÿ����ġ , �ӵ���)
            transform.position=
                Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position,moveSpeed*Time.deltaTime*speedMod);

            //Vecter3 .Distanse (A,B) ������ �Ÿ� => �Ÿ��� 0.01 ������ ��� �����ߴٰ� ���� * �̰͵� �ʿ��� �����
            if(Vector3.Distance(transform.position,thePath.points[currentPoint].position)<0.01f)
            {
                currentPoint += 1; // ���� ����Ʈ�� ����
                if(currentPoint>=thePath.points.Length)// ����Ʈ �迭������ ���� ��쿡�� �����Ϸ�
                {
                    reachEnd = true;
                }
            }
        }
    }
    public void SetMode(float Value)
    {
        modeEnd = false;
        speedMod = Value;
        timeSinceStart = 2.0f;


    }
}
