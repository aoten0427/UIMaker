using System;
using System.Collections.Generic;
using R3;
using ObservableCollections;
using UnityEngine;
using System.Collections.Specialized;

public abstract class ModelUIElement:MonoBehaviour
{
   //�{�^����������Ă����
   virtual public void ButtonHoldAction(Player player) { }
   //�{�^���������ꂽ�u��
   virtual public void ButtonPressAction(Player player) { }
   //�{�^���������ꂽ�u��
   virtual public void ButtonReleaseAction(Player player) { }
}