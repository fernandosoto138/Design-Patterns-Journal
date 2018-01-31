using System;
class FacebookPublicVideoHandler : VideoLinkHandler
{
    public FacebookPublicVideoHandler(){}
    public FacebookPublicVideoHandler(VideoLinkHandler nextHandler)
        :base(nextHandler){}
     protected override bool AcceptRequest(string link)
     {
        if(link.Contains("facebook.com"))
            return true;
        return false;
     }
     protected override void SucessfulAction() => Console.WriteLine("Downloading from Facebook");
}