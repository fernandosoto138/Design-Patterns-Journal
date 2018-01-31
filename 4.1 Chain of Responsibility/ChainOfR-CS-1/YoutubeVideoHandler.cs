using System;
class YoutubeVideoHandler : VideoLinkHandler
{
    public YoutubeVideoHandler(){}
    public YoutubeVideoHandler(VideoLinkHandler nextHandler)
        :base(nextHandler){}
     protected override bool AcceptRequest(string link)
     {
        if(link.Contains("youtube.com") || link.Contains("youtu.be"))
            return true;
        return false;
     }
     protected override void SucessfulAction() => Console.WriteLine("Downloading from youtube");
}
