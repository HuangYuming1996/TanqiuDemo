using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Button_Animation : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler{
	public Vector3 TargetScaleNumber;
	private float scaleSpeed;
	public GameObject AudioControl;
	// Use this for initialization
	void Start () {
		TargetScaleNumber = Vector3.one;
		scaleSpeed = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<RectTransform> ().localScale = new Vector3 (
			Mathf.Lerp (this.GetComponent<RectTransform> ().localScale.x, TargetScaleNumber.x, scaleSpeed),
			Mathf.Lerp (this.GetComponent<RectTransform> ().localScale.y, TargetScaleNumber.y, scaleSpeed),
			this.GetComponent<RectTransform> ().localScale.z
		);

	}
	public void OnPointerEnter(PointerEventData eventData){
		TargetScaleNumber = new Vector3 (1.15f, 1.15f, 1f);
		AudioControl.GetComponent<StartAudioControl> ().PlayAudion ("move");
	}
	public void OnPointerExit(PointerEventData eventData){
		TargetScaleNumber = Vector3.one;
	}

}
