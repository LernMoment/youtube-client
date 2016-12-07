using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;


namespace YouTubeClient
{
    class VideoData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string videoPublishedAt;
        public string VideoPublishedAt
        {
            get { return videoPublishedAt; }
            set
            {
                videoPublishedAt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VideoPublishedAt"));
            }
        }

        string videoTitel;
        public string VideoTitel
        {
            get { return videoTitel; }
            set
            {
                videoTitel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VideoTitel"));
            }
        }

        string videoId;
        public string VideoId
        {
            get { return videoId; }
            set
            {
                videoId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VideoId"));
            }
        }

        string videoStatus;
        public string VideoStatus
        {
            get { return videoStatus; }
            set
            {
                videoStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VideoStatus"));
            }
        }


        public VideoData(PlaylistItem playlistItem)
        {
            VideoId = playlistItem.Snippet.ResourceId.VideoId;
            VideoTitel = playlistItem.Snippet.Title;
            VideoPublishedAt = Convert2ShortDate(playlistItem.Snippet.PublishedAtRaw);
            VideoStatus = playlistItem.Status.PrivacyStatus;
        }

        private string Convert2ShortDate(string publishedAt)
        {
            DateTime dat = Convert.ToDateTime(publishedAt);
            return dat.ToShortDateString();// ToString("dd.MM.yyyy");
        }



    }
}
