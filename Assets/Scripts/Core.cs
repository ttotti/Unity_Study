using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 오브젝트의 자식 콜라이더가 다른 콜라이더에 충돌했을때 호출합니다
    // 관련된 해당 오브젝트에 대한 추가 정보는 호출동안에 전달된 Collision2D 파리미터를 통해 보고됩니다. 이 정보가 필요없다면, 해당 파라미터없이 OnCollisionEnter2D를 선언할 수 있습니다
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Tank_Shell")
        {
            Debug.Log(">>>>>>>>>>>> Hit!");
            transform.localScale += new Vector3(1.0f, 1.0f, 1.0f);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1000.0f,-1000.0f));
        }
    }
}
