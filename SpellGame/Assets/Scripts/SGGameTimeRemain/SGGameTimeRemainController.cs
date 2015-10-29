using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SGGameTimeRemainController : MonoBehaviour 
{
	private Image timeRmnImg;
	private Text timeRmnTxt;
	
	private float timeRemain = 0f;
	private bool isTimerOn = false;
	
	private static string FORMAT_TIME_REMAIN_OUTPUT = "F2";
	
	/* Unity functions */
	void Awake()
	{
		this.setupObjs();
	}
	
	void Start()
	{
		// DEBUG
		this.InitTimeBar(60f);
		this.StartTimeBar();	
	}
	
	void Update()
	{
		if(!this.isTimerOn) return;
		
		this.updateTime();
		this.updateRemainText();
		this.updateRemainBar();
	}
	
	/* Public */
	public void InitTimeBar(float duration)
	{
		this.timeRemain = duration;
	}
	
	public void StartTimeBar()
	{
		this.isTimerOn = true;
	}
	
	public void PauseTimeBar()
	{
		this.isTimerOn = false;
	}
	
	/* Private */
	private void updateTime()
	{
		this.timeRemain -= Time.deltaTime;
		
		if(this.timeRemain < 0f) this.timeRemain = 0f;
	}
	
	private void updateRemainText()
	{
		this.timeRmnTxt.text = this.timeRemain.ToString(FORMAT_TIME_REMAIN_OUTPUT);
	}
	
	private void updateRemainBar()
	{
		
	}
	
	private void setupObjs()
	{
		this.timeRmnImg = GameObject.Find("SGGameTimeRemainBarImg").GetComponent<Image>();
		this.timeRmnTxt = GameObject.Find("SGGameTimeRemainText").GetComponent<Text>();
	}
}
