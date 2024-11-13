using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class ViewBlackChangeScene : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private AnimationCurve _animationCurveEnable;
    [SerializeField] private AnimationCurve _animationCurveDisable;
    [SerializeField] private TypeViewChande _viewChande;
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _currentDuraction;
    [SerializeField] private Color _currentColor;

    private async void Start()
    {
        _currentColor = _image.color;
        EnableView(TypeViewChande.Disable);
    }
    public async void EnableView(TypeViewChande typeViewChande = TypeViewChande.Disable)
    {
        Debug.Log("Начало");
        Debug.Log(_currentDuraction.Equals(_animationDuration));
        while (_currentDuraction < _animationDuration)
        {
            switch (typeViewChande)
            {
                case TypeViewChande.Enable:
                    _currentColor.a = _animationCurveEnable.Evaluate(_currentDuraction);
                    break;

                case TypeViewChande.Disable:
                    _currentColor.a = _animationCurveDisable.Evaluate(_currentDuraction);
                    break;
            }
            await UniTask.Delay(0);
            _image.color = _currentColor;

            _currentDuraction += Time.deltaTime;
        }
        Debug.Log("закончили");
    }
}
public enum TypeViewChande
{
    Enable, Disable
}
