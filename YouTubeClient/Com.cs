using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeClient
{
    class Com
    {
        public ObservableCollection<VideoData> Videos { get; private set; } = new ObservableCollection<VideoData>();

        public void VideoInfosAusUploadPlaylistHolen(string lblApiKey, string channelId)
        {
            var yt = new YouTubeService(new BaseClientService.Initializer() { ApiKey = lblApiKey  });
            var channelsListRequest = yt.Channels.List("contentDetails");
            // Meine eigene ChannelID
            channelsListRequest.Id = channelId;
            // Alle Kanäle (Channel) des Anwenders abrufen
            var channelsListResponse = channelsListRequest.Execute();

            Videos.Clear();
            // Verarbeite die Informationen der enthaltenen Kanäle
            foreach (var channel in channelsListResponse.Items)
            {
                // Alle VideoInfos der UploadPlaylist abrufen
                var uploadsListId = channel.ContentDetails.RelatedPlaylists.Uploads;
                var nextPageToken = "";
                while (nextPageToken != null)
                {
                    var playlistItemsListRequest = yt.PlaylistItems.List("snippet,status");
                    playlistItemsListRequest.PlaylistId = uploadsListId;
                    playlistItemsListRequest.MaxResults = 50;
                    playlistItemsListRequest.PageToken = nextPageToken;
                    // Retrieve the list of videos uploaded to the authenticated user's channel.
                    var playlistItemsListResponse = playlistItemsListRequest.Execute();

                    foreach (var playlistItem in playlistItemsListResponse.Items)
                    {
                        VideoData vid = new VideoData(playlistItem);
                        Videos.Add(vid);
                    }
                    nextPageToken = playlistItemsListResponse.NextPageToken;
                }
            }
        }


    }
}

