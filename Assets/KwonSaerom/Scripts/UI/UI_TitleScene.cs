using Firebase.Extensions;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_TitleScene : InGameUI
{
    [SerializeField] UI_SignUp signUpPopup;
    [SerializeField] UI_Warning warningPopup;
    enum GameObjects
    {
        LoginButton,
        QuitButton,
        SignUpButton,
        PasswordInputField,
        IdInputField
    }

    protected override void Awake()
    {
        base.Awake();
        GetUI<Button>(GameObjects.LoginButton.ToString()).onClick.AddListener(Login);
        GetUI<Button>(GameObjects.QuitButton.ToString()).onClick.AddListener(Quit);
        GetUI<Button>(GameObjects.SignUpButton.ToString()).onClick.AddListener(SignUp);
    }

    public void SignUp()
    {
        Manager.UI.ShowPopUpUI(signUpPopup);
    }

    public void Login()
    {
        SetInteractable(false);
        string id = GetUI<TMP_InputField>(GameObjects.IdInputField.ToString()).text;
        string password = GetUI<TMP_InputField>(GameObjects.PasswordInputField.ToString()).text;

        FirebaseManager.Auth.SignInWithEmailAndPasswordAsync(id, password).ContinueWithOnMainThread(task =>
        {
            if(task.IsCanceled)
            {
                UI_Warning warning = Manager.UI.ShowPopUpUI(warningPopup);
                warning.SetLog("로그인에 실패하셨습니다.");
                SetInteractable(true);
                return;
            }
            if(task.IsFaulted)
            {
                UI_Warning warning = Manager.UI.ShowPopUpUI(warningPopup);
                warning.SetLog("로그인에 실패하셨습니다.");
                SetInteractable(true);
                return;
            }

            Debug.Log("Login Success");

            //user 정보를 들고온다.
            UserDataManager.LocalLoginGetUserData(id);
            StartCoroutine(CoWait());
            // 씬 전환(로비씬으로)
            Manager.Scene.LoadScene("LobbyScene");
            SetInteractable(true);
        });
    }

    public void Quit()
    {
        SetInteractable(false);
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); // 어플리케이션 종료
        #endif
    }

    private void SetInteractable(bool interactable)
    {
        GetUI<Button>(GameObjects.QuitButton.ToString()).interactable = interactable;
        GetUI<Button>(GameObjects.LoginButton.ToString()).interactable = interactable;
        GetUI<Button>(GameObjects.SignUpButton.ToString()).interactable = interactable;
        GetUI<TMP_InputField>(GameObjects.PasswordInputField.ToString()).interactable = interactable;
        GetUI<TMP_InputField>(GameObjects.IdInputField.ToString()).interactable = interactable;

    }

    IEnumerator CoWait()
    {
        yield return new WaitForSeconds(3f);
    }

}
