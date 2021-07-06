using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 按钮样式类，用于在Editor状态下修改按钮样式以及设置按钮样式的切换
/// </summary>
public class BtnStyleControl : MonoBehaviour, ISelectHandler,IDeselectHandler
{

    #region ui部件相关
    [Header("UI部件相关")]
    [SerializeField] private Button _selfBtn; //按钮
    [SerializeField] private GameObject _disablePanel; //未选中时候显示的面板
    [SerializeField] private GameObject _enablePanel; //选中时候显示的面板
    [SerializeField] private Text _disUserNameText; //未选中的面板里面的标题组件
    [SerializeField] private Text _ablUserNameText; //选中的面板里面的标题组件
    [SerializeField] private Image _disIconImage; //未选中的面板的图标组件
    [SerializeField] private Image _ablIconImage; //选中的面板的图标组件
    #endregion

    #region ui内容
    [Header("ui内容")]
    [SerializeField] private string _title; //按钮标题
    [SerializeField] private Sprite _icon; //按钮图标
    #endregion

  
    /// <summary>
    /// 按钮选中，改变状态
    /// </summary>
    /// <param name="eventData"></param>
    public void OnSelect(BaseEventData eventData)
    {
        this.SetSelect(true);
    }

    /// <summary>
    /// 按钮取消选中，改变状态
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDeselect(BaseEventData eventData)
    {
        this.SetSelect(false);
    }

    /// <summary>
    /// 设置按钮选中状态
    /// </summary>
    /// <param name="isSelect">是否选中</param>
    public void SetSelect(bool isSelect)
    {
        if (isSelect)
        {
            _disablePanel.SetActive(false);
            _enablePanel.SetActive(true); 
        }
        else
        {
            _disablePanel.SetActive(true);
            _enablePanel.SetActive(false);
        }
    }


#if UNITY_EDITOR
    /// <summary>
    /// 设置按钮的最初样式，在Editor状态下调用，用于动态修改按钮Prefab
    /// </summary>
    public void OnValidate()
    {
        _disUserNameText.text = _title;
        _ablUserNameText.text = _title;
        _disIconImage.sprite = _icon;
        _ablIconImage.sprite = _icon;
    }
#endif
}
