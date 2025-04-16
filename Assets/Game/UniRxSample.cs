using R3;   //UniRx���珑������
using R3.Triggers;  //UniRx.Triggers���珑������
//using ObservableCollections; //ObservableList���g�����߂ɒǉ�
using UnityEngine;
//using System; //System��using����͕̂s�v�ɂȂ���

public class UniRxSample : MonoBehaviour
{
    ReactiveProperty<int> _reactiveProperty = new ReactiveProperty<int>(0);

    //�O���̃N���X�ɂ�ReadOnlyReactiveProperty�Ō��J
    public ReadOnlyReactiveProperty<int> ReadOnlyReactiveProperty => _reactiveProperty;
    //�܂���Observable�Ō��J
    public Observable<int> OnValueChanged => _reactiveProperty;

    void Start()
    {
        //�l���X�V���ꂽ��Debug�o��
        _reactiveProperty.Subscribe(x => Debug.Log(x)).AddTo(this);

        _reactiveProperty.Value = 1;
        _reactiveProperty.Value = 2;
        //����͏o�͂���Ȃ�
        _reactiveProperty.Value = 2;
        _reactiveProperty.Value = 3;
        //�����I�ɒʒm
        _reactiveProperty.OnNext(3);    //SetValueAndForceNotify�̑����OnNext���g��

        //�}�E�X������������Debug�o��
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => Debug.Log("GetMouseButtonDown"))
            .AddTo(this);

        //Space�L�[������������Debug�o��(R3.Triggers)
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_ => HandleSpaceKeyPress())
            .AddTo(this);

        //Transform��Position���ύX���ꂽ��Debug�o��
        //UniRx�Ƃ͏��������قȂ�
        Observable.EveryValueChanged(this.transform, t => t.position)
            .Subscribe(x => Debug.Log($"PositionChanged:{x}"))
            .AddTo(this);

        /*
         * UniRx�ł̏�����
        this.transform.ObserveEveryValueChanged(t => t.position)
            .Subscribe(x => Debug.Log($"PositionChanged:{x}"))
            .AddTo(this);
        */

       

        ////ObservableList��Add/Remove/Replace���Ď�
        //var collection = new ObservableList<int>(); //ReactiveCollection�̑����ObservableList���g��
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