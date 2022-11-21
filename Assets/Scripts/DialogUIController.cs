using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace EasyUI.Dialogs {

	public class Dialog {
		public string Title = "Title";
		public string Message = "Message goes here.";
		public string ButtonText = "Close";
		public UnityAction OnClose = null;
	}

	public class DialogUIController : MonoBehaviour {
        public bool showed;
        public GameObject canvas;
		public Text titleUIText;
		public Text messageUIText;
		public Button closeUIButton;

		Image closeUIButtonImage;
		Text closeUIButtonText;
		CanvasGroup canvasGroup;

		//[Space ( 20f )]

		Dialog dialog = new Dialog ( );


		public bool IsActive = false;

		public static DialogUIController Instance;
        void Start()
        {
            showed = false;
			IsActive = false;
            canvas.SetActive(false);
        }

        void Awake()
        {
            Instance = this;

            closeUIButtonImage = closeUIButton.GetComponent<Image>();
            closeUIButtonText = closeUIButton.GetComponentInChildren<Text>();
            canvasGroup = canvas.GetComponent<CanvasGroup>();

            //Add close event listener
            closeUIButton.onClick.RemoveAllListeners();
            closeUIButton.onClick.AddListener(Hide);
        }


        public DialogUIController SetTitle ( string title ) {
			dialog.Title = title;
			return Instance;
		}

		
		public DialogUIController SetMessage ( string message ) {
			dialog.Message = message;
			return Instance;
		}

		
		public DialogUIController SetButtonText ( string text ) {
			dialog.ButtonText = text;
			return Instance;
		}

		
		public DialogUIController OnClose(UnityAction action) {
            //UnityEngine.Debug.Log("click close");
            dialog.OnClose = action;
            Time.timeScale = 1;
            canvas.SetActive(false);
            IsActive = false;
            //UnityEngine.Debug.Log("Go");
            //Hide();
            return Instance;
        }

        public void OnTriggerEnter(Collider other) {
            //UnityEngine.Debug.Log("hit");
   //         if (other.tag == "Notifier")
			//{
                //UnityEngine.Debug.Log("enter");
                titleUIText.text = dialog.Title;
				messageUIText.text = dialog.Message;
				IsActive = true;
				dialog = new Dialog();
				canvas.SetActive(true);
				//showed = true;// show once
				Time.timeScale = 0;
				//UnityEngine.Debug.Log("stop");
			//}
           
        }

		public void Hide ( ) {
			canvas.SetActive ( false );
            Time.timeScale = 1;
            IsActive = false;
		}

	}

}