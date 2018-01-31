using System;
class VimeoVideoHandler : VideoLinkHandler
{
    public VimeoVideoHandler(){}
    public VimeoVideoHandler(VideoLinkHandler nextHandler)
        :base(nextHandler){}
    protected override bool AcceptRequest(string link)
     {
        if(link.Contains("vimeo.com"))
            return true;
        return false;
     }
     protected override void SucessfulAction() => Console.WriteLine("Downloading from Vimeo");
}
