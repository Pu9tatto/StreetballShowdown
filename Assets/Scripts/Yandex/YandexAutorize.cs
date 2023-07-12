using Agava.YandexGames;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class YandexAutorize : MonoBehaviour
{
    [SerializeField] private IntValueViewer _nameView;
    [SerializeField] private RawImage _profileIcon;

    private string _name;
    private string _imageUrl;

    private void Start()
    {
        if (PlayerAccount.HasPersonalProfileDataPermission)
        {
            StartCoroutine(SetProfileInfo());
        }
    }

    public void OnAuthorizeButtonClick()
    {
        PlayerAccount.Authorize();

        StartCoroutine(SetProfileInfo());

        PlayerAccount.RequestPersonalProfileDataPermission();

        StartCoroutine(SetProfileInfo());
    }

    private IEnumerator SetProfileInfo()
    {
        StartCoroutine(SetProfile());

        yield return SetProfile();

        _nameView.SetValue(_name);

        StartCoroutine(DownloadImage(_imageUrl));

        StartCoroutine(InitInfo());
    }

    private IEnumerator SetProfile()
    {
        while (PlayerAccount.IsAuthorized == false)
        {
            yield return null;
        }

        PlayerAccount.GetProfileData((result) =>
        {
            _name = result.publicName;
            _imageUrl = result.profilePicture;
            if (string.IsNullOrEmpty(name))
                _name = "Anonymous";
            //Debug.Log($"My id = {result.uniqueID}, name = {name}, image = {_imageUrl}");
        });

    }

    private IEnumerator InitInfo()
    {
        if(PlayerAccount.IsAuthorized == false)
        {
            yield return null;
        }

        Saves.LoadData();

        yield return new WaitForSeconds(0.25f);

        Data.Instance.InitInfo();
    }

    private IEnumerator DownloadImage(string imageUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            _profileIcon.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
}
