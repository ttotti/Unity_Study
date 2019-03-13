using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tank : MonoBehaviour {

    GameObject goShell = null;
    bool action = false;

	// Use this for initialization
	void Start () {
        // 포탄 게임 오브젝트를 가져오고
        goShell = transform.Find("Tank_Shell").gameObject;
        // 포탄을 표시하지 않게 설정
        goShell.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        // 버튼을 눌렀는가?
		if(Input.GetMouseButton(0))
        {
            // 탱크를 클릭했는가?
            // 카메라를 기준으로 마우스 포인트를 얻어오고
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 해당 마우스 포인트에 콜라이더가 있는지 확인한다
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);

            // 있을 경우
            if(collition2d)
            {
                if (collition2d.gameObject == gameObject)
                {
                    // 액션 유효화
                    action = true;
                }
            }

            // 버튼을 누른 상태인가?
            if(action)
            {
                // 탱크 이동
                GetComponent<Rigidbody2D>().AddForce(new Vector2(+30.0f, 0.0f));
            }
        }
        else
        {
            // 버튼을 놓았는가?
            if (Input.GetMouseButtonUp(0) && action)
            {
                // 포탄 발사
                if(goShell)
                {
                    // 포탄 표시
                    goShell.SetActive(true);
                    goShell.GetComponent<Rigidbody2D>().AddForce(new Vector2(+300.0f, 500.0f));

                    // 3초 후 포탄오브젝트를 지운다
                    Destroy(goShell.gameObject, 3.0f);
                }

                action = false;
            }
        }

	}

    public void OnGUI()
    {
        GUI.TextField(new Rect(10, 10, 300, 60), "[Unity 2D Sample 2-1]\n" + "탱크를 클릭하면 가속\n놓으면 발사!");

        if (GUI.Button(new Rect(10, 80, 100, 20), "다시 시작"))
        {
            // 씬 전환함수 Application.LoadLevel() 함수는 이제 사용하지 않는다
            // Application.LoadLevel(Application.loadedLevelName);

            // 대신 다음 함수를 사용한다
            // using using UnityEngine.SceneManagement; 을 포함해주고
            // SceneManger.LoadScene("씬 이름");
            SceneManager.LoadScene("SampleScene");
        }
    }
}