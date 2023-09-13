using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Singleton.Instance.inscreaseScore(10);
        GameManager.instance.inscreaseScore(15);
        //Start 함수가 호출될 때 Instance에 접근해서 10점을 추가
    }
}
