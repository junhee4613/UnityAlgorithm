using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericContainerExample : MonoBehaviour
{

    private GenericContainer<int> intContainer;         //int 컨테이너
    private GenericContainer<string> stringContainer;   //string 컨테이너
    private GenericContainer<bool> boolContainer;
    private bool[] testBool = new bool[5] { true, false, true, false, true };
    private void Start()
    {
        intContainer = new GenericContainer<int>(5);        //5칸 초기화
        stringContainer = new GenericContainer<string>(5);  //5칸 초기화
        boolContainer = new GenericContainer<bool>(5);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))   //키보드 1
        {
            intContainer.Add(Random.Range(1, 100)); //컨테이너에 더한다.
            DisplayContainerItems(intContainer);    //디버그에 보여줌
            Test(intContainer);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))   //키보드 2
        {
            string randomString = "Item " + Random.Range(1, 10);
            stringContainer.Add(randomString);      //컨테이너에 더한다.
            DisplayContainerItems(stringContainer);    //디버그에 보여줌
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
    private void Test<T>(GenericContainer<T> test)  //매개변수가 <T>로 지정이 돼있다면 메서드 이름 옆에도 <T>를 써줘야된다.
    {                                               //그래야 매개변수를 <T>타입으로 정의해줄 수 있다. 만약 안그러면 컴파일러는 이 메서드가 제네릭 타입인 걸 인식하지 못한다. 

        if (test.GetType() == typeof(GenericContainer<int>))
        {
            Debug.Log("숫자");
        }
        else if (test.GetType() == typeof(GenericContainer<string>))
        {
            Debug.Log("글자");
        }
        else if (test.GetType() == typeof(GenericContainer<bool>))
        {
            Debug.Log("불값");

        }
    }
}


