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
        //Start �Լ��� ȣ��� �� Instance�� �����ؼ� 10���� �߰�
    }
}
