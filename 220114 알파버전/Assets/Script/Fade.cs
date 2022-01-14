using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float animTime = 2f; // Fade 애니메이션 재생 시간
    private Image fadeImage; // UGUI의 Image 컴포넌트 참조 변수

    private float start = 1f; // Mathf.Lerp 메소드의 첫번째 값
    private float end = 0f; // Mathf.Lerp 메소드의 두번째 값
    private float time = 0f; // Math.Lerp 메소드의 시간 값

    public bool stopIn = false; // false 일 때 실행되는 건데, 초기값을 false로 한 이유는 게임 시작할 때 fade in으로 들어가려고 
    public bool stopOut = true;

    void Awake(){
        fadeImage = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopIn && time <= 2){
            PlayFadeIn();
        }

        if(!stopOut && time <= 2){
            PlayFadeOut();
        }
        if(time >= 2 && !stopIn){
            stopIn = true;
            time = 0;
            Debug.Log("StopIn");
        }
        if(time >= 2 && !stopOut){
            stopIn = false;
            stopOut = true;
            time = 0;
            Debug.Log("StopOut");
        }
    }

    // 흰색 -> 투명으로
    void PlayFadeIn(){
        // 경과 시간 계산
        // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기
        time += Time.deltaTime / animTime;

        // Image 컴포넌트의 색상 값 읽어오기
        Color color = fadeImage.color;

        color.a = Mathf.Lerp(start, end, time);
        fadeImage.color = color;
    }

    // 투명 -> 흰색으로
    void PlayFadeOut(){
        time += Time.deltaTime / animTime;

        Color color = fadeImage.color;
        color.a = Mathf.Lerp(end, start, time);
        fadeImage.color = color; 
    }
}
