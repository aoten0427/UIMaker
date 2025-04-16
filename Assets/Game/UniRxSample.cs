using R3;   //UniRxから書き換え
using R3.Triggers;  //UniRx.Triggersから書き換え
//using ObservableCollections; //ObservableListを使うために追加
using UnityEngine;
//using System; //Systemをusingするのは不要になった

public class UniRxSample : MonoBehaviour
{
    ReactiveProperty<int> _reactiveProperty = new ReactiveProperty<int>(0);

    //外部のクラスにはReadOnlyReactivePropertyで公開
    public ReadOnlyReactiveProperty<int> ReadOnlyReactiveProperty => _reactiveProperty;
    //またはObservableで公開
    public Observable<int> OnValueChanged => _reactiveProperty;

    void Start()
    {
        //値が更新されたらDebug出力
        _reactiveProperty.Subscribe(x => Debug.Log(x)).AddTo(this);

        _reactiveProperty.Value = 1;
        _reactiveProperty.Value = 2;
        //これは出力されない
        _reactiveProperty.Value = 2;
        _reactiveProperty.Value = 3;
        //強制的に通知
        _reactiveProperty.OnNext(3);    //SetValueAndForceNotifyの代わりにOnNextを使う

        //マウスを押下したらDebug出力
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => Debug.Log("GetMouseButtonDown"))
            .AddTo(this);

        //Spaceキーを押下したらDebug出力(R3.Triggers)
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_ => HandleSpaceKeyPress())
            .AddTo(this);

        //TransformのPositionが変更されたらDebug出力
        //UniRxとは書き方が異なる
        Observable.EveryValueChanged(this.transform, t => t.position)
            .Subscribe(x => Debug.Log($"PositionChanged:{x}"))
            .AddTo(this);

        /*
         * UniRxでの書き方
        this.transform.ObserveEveryValueChanged(t => t.position)
            .Subscribe(x => Debug.Log($"PositionChanged:{x}"))
            .AddTo(this);
        */

       

        ////ObservableListでAdd/Remove/Replaceを監視
        //var collection = new ObservableList<int>(); //ReactiveCollectionの代わりにObservableListを使う
        //collection.ObserveAdd().Subscribe(x => Debug.Log($"Add:{x}")).AddTo(this);
        //collection.ObserveRemove().Subscribe(x => Debug.Log($"Remove:{x}")).AddTo(this);
        //collection.ObserveReplace().Subscribe(x => Debug.Log($"Replace:{x}")).AddTo(this);

        //collection.Add(1);
        //collection.Add(2);
        //collection[0] = 3;
        //collection.Remove(2);
    }

    private void HandleSpaceKeyPress()
    {
        Debug.Log("Space key was pressed!");
    }
}