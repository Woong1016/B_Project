using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

public EnemyPath thePath;  //몬스터가 가지고 있는 path 값  
    private int currentPoint;       //  지금몇번째 포인트를 향하고 있는지 변수

    private bool reachEnd;  // 도달 완료 체크 

    // Start is called before the first frame update
    void Start()
    {
        if(thePath==null)
        {
            thePath = FindObjectOfType<EnemyPath>();    // 모든 오브젝트를 검사해서 에너미 패스가 있는 컴포넌트를 가져온다.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(reachEnd== false)// if(reacheEnd에 도달이전
        {
            transform.LookAt(thePath.points[currentPoint]);// 몬스터는 지금 방향을 향해서 본다. Lookat 이거 좀 중요함 나한테 필요함

            //MoveToward 함수 (내위치, 타겟위치 , 속도값)
            transform.position=
                Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position,moveSpeed*Time.deltaTime);

            //Vecter3 .Distanse (A,B) 벡터의 거리 => 거리가 0.01 이하일 경우 도착했다고 간주 * 이것도 필요한 기능임
            if(Vector3.Distance(transform.position,thePath.points[currentPoint].position)<0.01f)
            {
                currentPoint += 1; // 다음 포인트로 변경
                if(currentPoint>=thePath.points.Length)// 포인트 배열수보다 높을 경우에는 도착완료
                {
                    reachEnd = true;
                }
            }
        }
    }
}
