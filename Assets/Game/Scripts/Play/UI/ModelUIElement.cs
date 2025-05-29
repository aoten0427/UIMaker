using System;
using System.Collections.Generic;
using R3;
using ObservableCollections;
using UnityEngine;
using System.Collections.Specialized;

public abstract class ModelUIElement:MonoBehaviour
{
   //ボタンが押されている間
   virtual public void ButtonHoldAction(Player player) { }
   //ボタンが押された瞬間
   virtual public void ButtonPressAction(Player player) { }
   //ボタンが離された瞬間
   virtual public void ButtonReleaseAction(Player player) { }
}