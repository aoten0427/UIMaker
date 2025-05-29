using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIElement : MonoBehaviour
{
    //���g�̃^�C�v
    UIDataList.UIElementType m_type;
    //���f��
    ModelUIElement m_model;
    //�r���[
    GameObject m_viewObj;
    ViewUIElement m_view;
    //�L�����o�X
    Canvas m_canvas;

    //������
    public void Initalzie(UIDataList.UIElementType type,Canvas canvas)
    {
        //�^�C�v�ݒ�
        m_type = type;
        //�L�����o�X�ݒ�
        m_canvas = canvas;

        //�f�[�^���X�g������
        UIDataList datas = Resources.Load<UIDataList>("UIDataList");
        UIDataList.UIData data = datas.SearchData(m_type);
        if (data == null)
        {
            Debug.LogError("�f�[�^�����݂��܂���");
        }

        //���f�����쐬
        m_model = UIFactory.CreateUIModel(m_type, gameObject);

        //�r���[�𐶐�
        GameObject view = data.ViewObject;
        m_viewObj = Instantiate(view, m_canvas.GetComponent<RectTransform>());
        m_view = m_viewObj.GetComponent<ViewUIElement>();
        //�r���[�̈ʒu��ݒ�
        m_view.m_mainPosition = data.Position;
        //�r���[�̏�����
        m_view.Initialize();

        //�p����̏�����
        SuccessorInitialize();
    }

    /// <summary>
    /// �eUI�v�f�̏��������L�q
    /// </summary>
    public abstract void SuccessorInitialize();

    //���f�����擾����
    public T GetModel<T>()
    {
        T model = GetComponent<T>();
        if (model == null)
        {
            Debug.Log("�w�肳�ꂽ���f���������Ă��܂���");
        }
        return model;
    }

    //�r���[���擾����
    public T GetView<T>()
    {
        T view = m_viewObj.GetComponent<T>();
        if(view == null)
        {
            Debug.Log("�w�肳�ꂽ�r���[�������Ă��܂���");
        }
        return view;
    }

    /// <summary>
    /// �{�^���v���X�A�N�V����
    /// </summary>
    /// <param name="player"></param>
    public void ButtonHoldAction(Player player)
    {
        m_model.ButtonHoldAction(player);
    }

    /// <summary>
    /// �{�^���v���X�A�N�V����
    /// </summary>
    /// <param name="player"></param>
    public void ButtonPressAction(Player player)
    {
        m_model.ButtonPressAction(player);
    }

    /// <summary>
    /// �{�^�������[�X�A�N�V����
    /// </summary>
    /// <param name="player"></param>
    public void ButtonReleaseAction(Player player)
    {
        m_model.ButtonReleaseAction(player);
    }
}
