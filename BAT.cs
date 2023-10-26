using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAT : MonoBehaviour
{
    /**
    Rigidbody2D rigid;
    public int nextMoveX;
    public int nextMoveY;
    public float height = 1.7f;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 5);
        Debug.Log("1");
    }
    void FixedUpdate()
    {
        //rigid.velocity = new Vector2(nextMoveY, rigid.velocity.y);
        rigid.velocity = new Vector2(transform.position.y + height, 0);
        Debug.Log("2");
    }
    void Think()
    {
        nextMoveX = Random.Range(-1, 1);
        nextMoveY = Random.Range(-1, 2);
        Invoke("Think", 5);
        rigid.velocity = new Vector2(nextMoveX * 10, nextMoveY * 10);
        Debug.Log("생각 실행");
    } **/

    public int atkDmg;
    public float atkSpeed;
    public float moveSpeed;
    public float atkRange;
    public float fieldOfVision;

    private void SetEnemyStatus(int _atkDmg, float _atkSpeed, float _moveSpeed, float _atkRange, float _fieldOfVision)
    {
        atkDmg = _atkDmg;
        atkSpeed = _atkSpeed;
        moveSpeed = _moveSpeed;
        atkRange = _atkRange;
        fieldOfVision = _fieldOfVision;
    }

    public Vector2 boxSize;
    Rigidbody2D rigid;
    public int nextMoveX;  //다음 행동지표를 결정할 변수
    public int nextMoveY;

    void Start()
    {
        SetEnemyStatus(10, 1.5f, 100, 1.5f, 400f);

        StartCoroutine("BatMoving");  // 박쥐 움직임 반복
    }

    IEnumerator BatMoving()  // 박쥐 몬스터의 일상 움직임
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);  // 초마다 계속 움직이기

            nextMoveX = Random.Range(-1, 2);  // 좌우 다음에 어디로 이동할지 결정
            nextMoveY = Random.Range(-1, 2);  // 상하 다음에 어디로 이동할지 결정
            rigid.velocity = new Vector2(nextMoveX * 10, nextMoveY * 100);
        }
    }
}
