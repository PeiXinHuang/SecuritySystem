using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 提示框类
/// </summary>
public class Messagebox : MonoBehaviour
{
    private static GameObject messagebox;
    private static GameObject infoMessagebox;
    private static GameObject errorMessagebox;
    private static GameObject successMessagebox;
    private static GameObject warringMessagebox;


    private static Text infoText;
    private static Text errorText;
    private static Text successText;
    private static Text warringText;

    [SerializeField] private GameObject _messagebox;
    [SerializeField] private GameObject _infoMessagebox;
    [SerializeField] private GameObject _errorMessagebox;
    [SerializeField] private GameObject _successMessagebox;
    [SerializeField] private GameObject _warringMessagebox;

    [SerializeField] private Text _infoText;
    [SerializeField] private Text _errorText;
    [SerializeField] private Text _successText;
    [SerializeField] private Text _warringText;


    private void Start()
    {
        InitMessagebox();
        HideAllMessageBox();
    }


    /// <summary>
    /// 初始化UI
    /// </summary>
    private void InitMessagebox()
    {
        messagebox = _messagebox;
        infoMessagebox = _infoMessagebox;
        errorMessagebox = _errorMessagebox;
        successMessagebox = _successMessagebox;
        warringMessagebox = _warringMessagebox;

        infoText = _infoText;
        errorText = _errorText;
        successText = _successText;
        warringText = _warringText;
    }
   
    /// <summary>
    /// 显示信息提示框
    /// </summary>
    /// <param name="info">信息内容</param>
    public static void ShowInfo(string info = "")
    {
        HideAllMessageBox();

        LeanTween.cancelAll();

        infoText.text = "提示：" + info;

        //显示UI之后隐藏
        infoMessagebox.LeanMoveLocalY(180, 0.3f).setEaseOutSine();
        infoMessagebox.LeanMoveLocalY(250, 0.1f).setDelay(3.0f);
     

    }

    /// <summary>
    /// 显示警告提示框
    /// </summary>    
    /// <param name="warring">警告内容</param>
    public static void ShowWarring(string warring = "")
    {
        HideAllMessageBox();

        LeanTween.cancelAll();

        warringText.text = "警告：" + warring;

        warringMessagebox.LeanMoveLocalY(180, 0.3f).setEaseOutSine();
        warringMessagebox.LeanMoveLocalY(250, 0.1f).setDelay(3.0f);
    }

    /// <summary>
    /// 显示成功提示框
    /// </summary>
    /// <param name="success">成功内容</param>
    public static void ShowSuccess(string success = "")
    {
        HideAllMessageBox();

        LeanTween.cancelAll();

        successText.text = "成功：" + success;

        successMessagebox.LeanMoveLocalY(180, 0.3f).setEaseOutSine();
        successMessagebox.LeanMoveLocalY(250, 0.1f).setDelay(3.0f);
    }

    /// <summary>
    /// 显示错误提示框
    /// </summary>
    /// <param name="error">错误内容</param>
    public static void ShowError(string error = "")
    {
        HideAllMessageBox();

        LeanTween.cancelAll();

        errorText.text = "错误：" + error;

        errorMessagebox.LeanMoveLocalY(180, 0.3f).setEaseOutSine();
        errorMessagebox.LeanMoveLocalY(250, 0.1f).setDelay(3.0f);
    }



    /// <summary>
    /// 隐藏所有提示框
    /// </summary>
    private static void HideAllMessageBox()
    {
       
        infoMessagebox.transform.localPosition = new Vector3(infoMessagebox.transform.localPosition.x, 250, infoMessagebox.transform.localPosition.z);
        errorMessagebox.transform.localPosition = new Vector3(errorMessagebox.transform.localPosition.x, 250, errorMessagebox.transform.localPosition.z);
        successMessagebox.transform.localPosition = new Vector3(successMessagebox.transform.localPosition.x, 250, successMessagebox.transform.localPosition.z);
        warringMessagebox.transform.localPosition = new Vector3(warringMessagebox.transform.localPosition.x, 250, warringMessagebox.transform.localPosition.z);

    }    


}

