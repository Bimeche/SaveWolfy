using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SceneManagement;
//using GooglePlayGames.BasicApi.SavedGame;

public class AwakeSignIn : MonoBehaviour {

private void Awake()
    {
        //Google Play Service
        /*GooglePlayGames.BasicApi.PlayGamesClientConfiguration config = 
            new GooglePlayGames.BasicApi.PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();*/
        //PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        SceneManager.LoadScene("MainMenu");

        Social.localUser.Authenticate((bool success) =>
        {

        });

    }

    /*//Cloud Saving
    private bool isSaving = false;
    public void OpenSave(bool saving)
    {
        if (Social.localUser.authenticated)
        {
            isSaving = saving;
            ((PlayGamesPlatform)Social.Active).SaveGame.OpenWithAutomaticConflictResolution("SaveWolfy", GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLongestPlaytime, SaveGameOpened);
        }
    }

    private void SaveGameOpened(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        if(status == SavedGamesRequestStatus.Success)
        {
            if(isSaving) //Writting
            {
                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes("Random Save");
                SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().WithUpdatedDescription("Saved at " + DateTime.Now.ToString()).Build();
                ((PlayGamesPlatform)Social.Active).SavedGame.ComitUpdate(meta, update, data, SaveUpdate);
            }
            else //Reading
            {
                ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, SaveRead);
            }
        }
    }

    // Load
    private void SaveRead(SavedGameRequestStatus status, byte[] data)
    {
        if(status == SavedGameRequestStatus.Success)
        {
            string saveData = System.Text.ASCIIEncoding.ASCII.GetString(data);
        }
    }

    //Success Save
    private void SavedUpdate(SaveGameRequestStatus status, IsavedMetaData meta)
    {
        Debug.Log(Status);
    }*/
}
