using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PathDancer : MonoBehaviour
{
    public float _maxScale;

    [SerializeField]
    private bool _colorChanger = true;

    #region Values
    public List<float> _cielingValues;
    public List<float> _floorValues;
    public List<float> _leftValues;
    public List<float> _rightValues;
    #endregion

    #region CubeCounts
    int _cielingCubeCount;
    int _floorCubeCount;
    int _rightCubeCount;
    int _leftCubeCount;
    #endregion


    #region Children
    [SerializeField]
    GameObject[] _cielingCubes;
    [SerializeField]
    GameObject[] _floorCubes;
    [SerializeField]
    GameObject[] _rightCubes;
    [SerializeField]
    GameObject[] _leftCubes;
    #endregion 

    // Start is called before the first frame update
    void Start()
    {
        GetScaleValues();
        ApplyBandsScales();
        _cielingCubeCount = _cielingCubes.Length;
        _floorCubeCount = _floorCubes.Length;
        _rightCubeCount = _rightCubes.Length;
        _leftCubeCount = _leftCubes.Length;
    }

    void GetScaleValues()
    {
        foreach (GameObject cielingCube in _cielingCubes)
        {
            float _cielingValue = cielingCube.transform.localScale.y;
            _cielingValues.Add(_cielingValue);
        }

        foreach (GameObject floorCube in _floorCubes)
        {
            float _floorValue = floorCube.transform.localScale.y;
            _floorValues.Add(_floorValue);
        }

        foreach (GameObject rightCube in _rightCubes)
        {
            float _rightValue = rightCube.transform.localScale.x;
            _rightValues.Add(_rightValue);
        }

        foreach (GameObject leftCube in _leftCubes)
        {
            float _leftValue = leftCube.transform.localScale.x;
            _leftValues.Add(_leftValue);
        }
    }

    void ApplyBandsScales()
    {
        int i = 0;
        int j = 0;
        int k = 0;
        int l = 0;

        int ii = 0;
        int jj = 0;
        int kk = 0;
        int ll = 0;
        foreach (GameObject cielingCube in _cielingCubes)
        {
            cielingCube.AddComponent<CubeBandAssigner>();
            cielingCube.GetComponent<CubeBandAssigner>().cubeBand = i;
            cielingCube.GetComponent<CubeBandAssigner>().startScale = _cielingValues[ii];
            i++;
            ii++;
            if (i > 7)
            {
                i = 0;
            }
            if (ii > _cielingCubeCount)
            {
                ii = 0;
            }
        }
        foreach (GameObject floorCube in _floorCubes)
        {
            floorCube.AddComponent<CubeBandAssigner>();
            floorCube.GetComponent<CubeBandAssigner>().cubeBand = j;
            floorCube.GetComponent<CubeBandAssigner>().startScale = _floorValues[jj];
            j++;
            jj++;
            if (j > 7)
            {
                j = 0;
            }
            if (jj > _floorCubeCount)
            {
                jj = 0;
            }
            if (_colorChanger == true)
            {
                floorCube.GetComponent<CubeBandAssigner>().colorChangerCheck = true;
            }
        }
        foreach (GameObject rightCube in _rightCubes)
        {
            rightCube.AddComponent<CubeBandAssigner>();
            rightCube.GetComponent<CubeBandAssigner>().cubeBand = k;
            rightCube.GetComponent<CubeBandAssigner>().startScale = _rightValues[kk];
            k++;
            kk++;
            if (k > 7)
            {
                k = 0;
            }
            if (kk > _rightCubeCount)
            {
                kk = 0;
            }
        }
        foreach (GameObject leftCube in _leftCubes)
        {
            leftCube.AddComponent<CubeBandAssigner>();
            leftCube.GetComponent<CubeBandAssigner>().cubeBand = l;
            leftCube.GetComponent<CubeBandAssigner>().startScale = _leftValues[ll];
            l++;
            ll++;
            if (l > 7)
            {
                l = 0;
            }
            if (ll > _leftCubeCount)
            {
                ll = 0;
            }
        }
    }

    void FixedUpdate()
    {
        //Cieling
        foreach (GameObject cielingCube in _cielingCubes)
        {

            int _band = cielingCube.GetComponent<CubeBandAssigner>().cubeBand;

            cielingCube.transform.localScale = new Vector3(cielingCube.transform.localScale.x,
                (AudioPeer._audioBandBuffer[_band] * _maxScale) + cielingCube.GetComponent<CubeBandAssigner>().startScale, cielingCube.transform.localScale.z);
        }

        //Floor
        foreach (GameObject floorCube in _floorCubes)
        {
            int _band = floorCube.GetComponent<CubeBandAssigner>().cubeBand;
            floorCube.transform.localScale = new Vector3(floorCube.transform.localScale.x,
                (AudioPeer._audioBandBuffer[_band] * _maxScale) + floorCube.GetComponent<CubeBandAssigner>().startScale, floorCube.transform.localScale.z);
        }

        //Right
        foreach (GameObject rightCube in _rightCubes)
        {
            int _band = rightCube.GetComponent<CubeBandAssigner>().cubeBand;

            rightCube.transform.localScale = new Vector3((AudioPeer._audioBandBuffer[_band] * _maxScale) + rightCube.GetComponent<CubeBandAssigner>().startScale,
                rightCube.transform.localScale.y, rightCube.transform.localScale.z);
        }

        //Left
        foreach (GameObject leftCube in _leftCubes)
        {
            int _band = leftCube.GetComponent<CubeBandAssigner>().cubeBand;

            leftCube.transform.localScale = new Vector3((AudioPeer._audioBandBuffer[_band] * _maxScale) + leftCube.GetComponent<CubeBandAssigner>().startScale,
                leftCube.transform.localScale.y, leftCube.transform.localScale.z);
        }
    }
}
