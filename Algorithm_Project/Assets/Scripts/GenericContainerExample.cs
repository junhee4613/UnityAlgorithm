using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericContainerExample : MonoBehaviour
{

    private GenericContainer<int> intContainer;         //int �����̳�
    private GenericContainer<string> stringContainer;   //string �����̳�
    private GenericContainer<bool> boolContainer;
    private bool[] testBool = new bool[5] { true, false, true, false, true };
    private void Start()
    {
        intContainer = new GenericContainer<int>(5);        //5ĭ �ʱ�ȭ
        stringContainer = new GenericContainer<string>(5);  //5ĭ �ʱ�ȭ
        boolContainer = new GenericContainer<bool>(5);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))   //Ű���� 1
        {
            intContainer.Add(Random.Range(1, 100)); //�����̳ʿ� ���Ѵ�.
            DisplayContainerItems(intContainer);    //����׿� ������
            Test(intContainer);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))   //Ű���� 2
        {
            string randomString = "Item " + Random.Range(1, 10);
            stringContainer.Add(randomString);      //�����̳ʿ� ���Ѵ�.
            DisplayContainerItems(stringContainer);    //����׿� ������
            Test(stringContainer);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            boolContainer.Add(testBool[Random.Range(0, 5)]);
            Debug.Log(Random.Range(0, 5));
            DisplayContainerItems(boolContainer);
            Test(boolContainer);
        }
    }

    private void DisplayContainerItems<T>(GenericContainer<T> container)
    {
        T[] items = container.GetItems();
        string temp = "";

        for (int i = 0; i < items.Length; i++)
        {
            if(items[i] != null)
            {
                temp += items[i].ToString() + " - ";
            }
            else
            {
                temp += "Empty - ";
            }
        }
        Debug.Log(temp);
    }
    private void Test<T>(GenericContainer<T> test)  //�Ű������� <T>�� ������ ���ִٸ� �޼��� �̸� ������ <T>�� ����ߵȴ�.
    {                                               //�׷��� �Ű������� <T>Ÿ������ �������� �� �ִ�. ���� �ȱ׷��� �����Ϸ��� �� �޼��尡 ���׸� Ÿ���� �� �ν����� ���Ѵ�. 

        if (test.GetType() == typeof(GenericContainer<int>))
        {
            Debug.Log("����");
        }
        else if (test.GetType() == typeof(GenericContainer<string>))
        {
            Debug.Log("����");
        }
        else if (test.GetType() == typeof(GenericContainer<bool>))
        {
            Debug.Log("�Ұ�");

        }
    }
}


