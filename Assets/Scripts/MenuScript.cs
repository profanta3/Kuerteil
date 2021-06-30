using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuScript : MonoBehaviour
{
    public GameObject _MenuView;
    public GameObject _KeyManagerView;

    public GameObject BackgroundImage;

    private bool menuOn;

    private void Start()
    {
        if (_MenuView == null)
        {
            _MenuView = GameObject.FindGameObjectWithTag("MenuView");
        }
        if (_KeyManagerView == null)
        {
            _KeyManagerView = GameObject.FindGameObjectWithTag("KeyManagerView");
        }
        if (BackgroundImage == null)
        {
            BackgroundImage = GameObject.FindGameObjectWithTag("BackgroundImage");
            BackgroundImage.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && GameControl.Instance._GameOver == false)
        {
            if (Input.GetKeyUp(KeyCode.Tab) && _MenuView.GetComponent<Animator>().GetBool("menuOpen") == false && _KeyManagerView.GetComponent<Animator>().GetBool("menuOpen") == false)
            {
                _KeyManagerView.GetComponent<Animator>().Play("MenuOpeningState");
                _MenuView.GetComponent<Animator>().Play("MenuOpeningState");
                _MenuView.GetComponent<Animator>().SetBool("menuOpen", true);
                _KeyManagerView.GetComponent<Animator>().SetBool("menuOpen", true);
                //KeyManager:

            }
            else if (Input.GetKeyUp(KeyCode.Tab) && _MenuView.GetComponent<Animator>().GetBool("menuOpen") == true && _KeyManagerView.GetComponent<Animator>().GetBool("menuOpen") == true)
            {
                _KeyManagerView.GetComponent<Animator>().Play("MenuClosingState");
                _MenuView.GetComponent<Animator>().Play("MenuClosingState");

                _MenuView.GetComponent<Animator>().SetBool("menuOpen", false);
                //KeyManager:
                _KeyManagerView.GetComponent<Animator>().SetBool("menuOpen", false);
            }
            if (GameControl.Instance._MenuState == true)
            {
                GameControl.Instance.player.gameObject.GetComponent<FirstPersonController>().canLook = false;
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
            }
            else if (GameControl.Instance._MenuState == false)
            {
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
                GameControl.Instance.player.gameObject.GetComponent<FirstPersonController>().canLook = true;
            }
            if (GameControl.Instance.SceneLoading == true)
            {
                BackgroundImage.gameObject.SetActive(true);
            }
            else
            {
                BackgroundImage.gameObject.SetActive(false);
            }
        }
    }
}
