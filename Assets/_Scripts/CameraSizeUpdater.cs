//  CameraSizeUpdater.cs
//  http://kan-kikuchi.hatenablog.com/entry/CameraSizeUpdater
//
//  Created by kan.kikuchi on 2019.07.02.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �J������OrthographicSize���A�X��ɉ����čX�V����N���X
/// </summary>
[RequireComponent(typeof(Camera)), ExecuteInEditMode]
public class CameraSizeUpdater : MonoBehaviour {

    private Camera _camera;

    //�c�A���A�������͗����̂ǂ����ɂ��邩
    private enum BaseType {
        Both, Width, Height
    }

    [SerializeField]
    private BaseType _baseType = BaseType.Both;

    //��̉�ʃT�C�Y
    [SerializeField]
    private float _baseWidth = 540, _baseHeight = 960;

    //�摜��Pixel Per Unit
    [SerializeField]
    private float _pixelPerUnit = 100f;

    //���(Update����)�X�V���邩
    [SerializeField]
    private bool _isAlwaysUpdate = false;

    //���݂̃A�X��
    private float _currentAspect;

    //=================================================================================
    //������
    //=================================================================================

    private void Awake() {
        UpdateOrthographicSize();
    }

    //�C���X�y�N�^�[�̒l���ύX���ꂽ�����s�AOrthographicSize�������I�ɍX�V����
    private void OnValidate() {
        _currentAspect = 0;
        UpdateOrthographicSize();
    }

    //=================================================================================
    //�X�V
    //=================================================================================

    private void Update() {
        if (!_isAlwaysUpdate && Application.isPlaying) {
            return;
        }
        UpdateOrthographicSize();
    }

    //�J������OrthographicSize���A�X��ɉ����čX�V
    private void UpdateOrthographicSize() {
        //���݂̃A�X�y�N�g����擾���A�ω����Ȃ���΍X�V���Ȃ�
        float currentAspect = (float)Screen.height / (float)Screen.width;
        if (Mathf.Approximately(_currentAspect, currentAspect)) {
            return;
        }
        _currentAspect = currentAspect;

        //�J�������擾���Ă��Ȃ���Ύ擾
        if (_camera == null) {
            _camera = gameObject.GetComponent<Camera>();
        }

        //��̃A�X�y�N�g��ƁA��̃A�X�y�N�g��̎���Size
        float baseAspect = _baseHeight / _baseWidth;
        float baseOrthographicSize = _baseHeight / _pixelPerUnit / 2f;

        //�J������orthographicSize��ݒ肵�Ȃ���
        if (_baseType == BaseType.Height || (baseAspect > _currentAspect && _baseType != BaseType.Width)) {
            _camera.orthographicSize = baseOrthographicSize;
        } else {
            _camera.orthographicSize = baseOrthographicSize * (_currentAspect / baseAspect);
        }
    }

}