using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SGGameTimeRemainController : MonoBehaviour 
{
	private Image timeRmnBar;
	private Text timeRmnTxt;

	private Animator animator;
	
	private float timeRemain = 0f;
	private float timeRemainMax = 0f;
	private float cautionThres = 0f;
	private float warningThres = 0f;
	private bool isTimerOn = false;
	private bool isWarning = false;
	private bool isCaution = false;
	
	private static string OUTPUT_FORMAT_TIME_REMAIN = "F2";
	private static string ANIM_TRG_CAUTION = "caution";
	private static string ANIM_TRG_WARNING = "warning";

	/* Unity functions */
	void Awake()
	{
		this.setupObjs();
	}
	
	void Start()
	{
		// DEBUG
		this.InitTimeBar(20f);
		this.SetCautionThres(15f);
		this.SetWarningThres(10f);
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
		this.timeRemainMax = duration;
	}

	public void SetCautionThres(float thres)
	{
		this.cautionThres = thres;
	}

	public void SetWarningThres(float thres)
	{
		this.warningThres = thres;
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
		this.timeRmnTxt.text = this.timeRemain.ToString(OUTPUT_FORMAT_TIME_REMAIN);
	}
	
	private void updateRemainBar()
	{
		float remainRatio = this.timeRemain / this.timeRemainMax;
		this.timeRmnBar.rectTransform.localScale = new Vector3(remainRatio, 1f, 1f);

		if(this.timeRemain < this.cautionThres && this.warningThres < this.timeRemain) this.startCaution();
		else if(this.timeRemain < this.warningThres) this.startWarning();
	}

	private void startCaution()
	{
		if(!this.isCaution) 
		{
			Debug.Log("start");
			this.animator.SetTrigger(ANIM_TRG_CAUTION);
			this.isCaution = true;
		}

	}

	private void startWarning()
	{
		if(!this.isWarning)
		{
			Debug.Log("start");
			this.animator.SetTrigger(ANIM_TRG_WARNING);
			this.isWarning = true;
		}

	}
	
	private void setupObjs()
	{
		this.timeRmnBar = GameObject.Find("SGGameTimeRemainBarImg").GetComponent<Image>();
		this.timeRmnTxt = GameObject.Find("SGGameTimeRemainText").GetComponent<Text>();
		this.animator = this.GetComponent<Animator>();
	}
}
