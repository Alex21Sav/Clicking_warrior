using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RewardedAds : MonoBehaviour, IUnityAdsListener
{
    
    [SerializeField] private Button _adsButton;
    [SerializeField] private Advertising _advertising;

    private string _gameId = "4295417"; // game id

    private string _rewardedVideo = "Rewarded_Android";

    void Start()
    {
        _adsButton = GetComponent<Button>();
        _adsButton.interactable = Advertisement.IsReady(_rewardedVideo);

        if (_adsButton)
            _adsButton.onClick.AddListener(ShowRewardedVideo);

        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, true);
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(_rewardedVideo);
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _rewardedVideo)
        {
            _adsButton.interactable = true; //��������, ���� ������� ��������
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        //������ �������
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // ������ ��������� �������
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) //��������� ������� (��� ����������� ��������������)
    {
        if (showResult == ShowResult.Finished)
        {
            if (placementId == "Rewarded_Android")
                _advertising.OnButtonClick();                
                //��������, ���� ������������ ��������� ������� �� �����
        }
        else if (showResult == ShowResult.Skipped)
        {
            //��������, ���� ������������ ��������� �������
        }
        else if (showResult == ShowResult.Failed)
        {
            //�������� ��� ������
        }
    }
}
