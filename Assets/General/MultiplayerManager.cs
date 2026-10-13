using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Multiplayer;
using System;
using System.Threading;
using System.Threading.Tasks;
using TMPro;

public class MultiplayerManager : MonoBehaviour
{
    // Multiplayer Management
    private ISession session;
    [SerializeField]
    public String queueName;
    public int maxPlayers;

    // Starting UI
    [SerializeField]
    public GameObject startPanel;
    [SerializeField]
    public TextMeshProUGUI startStatusText;

    // Replay UI
    [SerializeField]
    public GameObject replayPanel;
    [SerializeField]
    public TextMeshProUGUI replayStatusText;

    async void Start()
    {
        // Display Panels
        startPanel.SetActive(true);
        replayPanel.SetActive(false);

        startStatusText.text = "Initializing Unity Services...";
        try
        {
            await UnityServices.InitializeAsync();
            startStatusText.text = "Signing in...";
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            startStatusText.text = "Initialized! Press start to enter matchmaking.";
        }
        catch (Exception e)
        {
            startStatusText.text = "Failed to initialize Unity Services: " + e.Message;
        }
    }

    public async void StartMatchmaking(bool isStartOrReplay)
    {
        if (isStartOrReplay)
        {
            startStatusText.text = "Starting matchmaking...";
        }
        else
        {
            replayStatusText.text = "Starting matchmaking...";
        }
        
        var matchmakerOptions = new MatchmakerOptions { QueueName = queueName };
        var sessionOptions = new SessionOptions { MaxPlayers = maxPlayers }.WithRelayNetwork();
        var matchmakerCancellationSource = new CancellationTokenSource();

        session = await MultiplayerService.Instance.MatchmakeSessionAsync(matchmakerOptions, sessionOptions, matchmakerCancellationSource.Token);
    
        if (isStartOrReplay)
        {
            startPanel.SetActive(false);
        }
        else
        {
            replayPanel.SetActive(false);
        }
    }
}
