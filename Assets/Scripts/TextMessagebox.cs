using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMessagebox : MonoBehaviour
{
    public void ShowInfoMessagebox()
    {
        Messagebox.ShowInfo("测试信息提示框");
    }
    public void ShowWarringMessagebox()
    {
        Messagebox.ShowWarring("测试警告提示框");
    }

    public void ShowErrorMessagebox()
    {
        Messagebox.ShowError("测试错误提示框");
    }
    public void ShowSuccessMessagebox()
    {
        Messagebox.ShowSuccess("测试成功提示框");
    }
}