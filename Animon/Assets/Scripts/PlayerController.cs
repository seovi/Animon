using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Animon.Const;

public class PlayerController : MonoBehaviourPun
{
    private GameManager gameManager;
    private Rigidbody playerRigidbody; // 이동에 사용할 리지드바디 컴포넌트
    private Animator animator;
    private int selectedCharacter = 0;
    private int coinSum = 0;
    private string userId;

    public float speed = 8f; // 이동 속력    

    void Start() {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        userId = PhotonNetwork.LocalPlayer.NickName;

        gameManager = FindObjectOfType<GameManager>();
        coinSum = gameManager.GetCoinCount(userId);
        gameManager.SetCoinText(coinSum);
    }

    void Update() {
        if (!photonView.IsMine) {
            return;
        }

        // 수평과 수직 축 입력 값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xInput, 0, zInput);
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // 부드러운 회전 
            playerRigidbody.rotation = Quaternion.Slerp(playerRigidbody.rotation, Quaternion.Euler(0, angle, 0), 5.0f * Time.fixedDeltaTime);      
        }

        if (0 != xInput || 0 != zInput) {
            animator.SetBool("Walk", true);
        } else {
            animator.SetBool("Idle", true);
        }

        // 실제 이동 속도를 입력 값과 이동 속력을 통해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        
        // Vector3 속도를 (xSpeed, 0, zSpeed)으로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);       

        // 리지드바디의 속도에 newVelocity를 할당
        playerRigidbody.velocity = newVelocity;
                
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!photonView.IsMine) {
            return;
        }
        if (collision.gameObject.tag == "Coin")
        {
            coinSum += 1;
            gameManager.SetCoinCount(userId, coinSum);
            gameManager.SetCoinText(coinSum);            
        }
    }


    public void Die() {
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();
        // 가져온 GameManager 오브젝트의 EndGame() 메서드 실행
        gameManager.EndGame();
    }

    public void SelectCharacter(int selectIndex)
    {
        //characterPrefab[selectedCharacter].SetActive(false);
        //selectedCharacter = selectIndex;
        //characterPrefab[selectedCharacter].SetActive(true);
        //animator = characterPrefab[selectedCharacter].GetComponent<Animator>();
    }
}