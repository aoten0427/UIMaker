using System;
using System.Collections.Generic;
using R3;
using ObservableCollections;
using UnityEngine;
using System.Collections.Specialized;

public abstract class ModelUIElement:MonoBehaviour
{
   virtual public void ButtonHoldAction(Player player) { }
   virtual public void ButtonPressAction(Player player) { }
   virtual public void ButtonReleaseAction(Player player) { }
}