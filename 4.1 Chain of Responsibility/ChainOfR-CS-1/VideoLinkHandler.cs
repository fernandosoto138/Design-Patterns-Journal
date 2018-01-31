using System;
abstract class VideoLinkHandler
{
    private VideoLinkHandler nextHandler;
    public VideoLinkHandler()
    {
    }

    public VideoLinkHandler(VideoLinkHandler nextHandler) => this.nextHandler = nextHandler;

    public void ProcessRequest(string link)
    {
        if(AcceptRequest(link))
            SucessfulAction();
        else if(nextHandler == null)
            Console.WriteLine("Can't process that link");
        else
            nextHandler.ProcessRequest(link);

    }

    abstract protected bool AcceptRequest(string link);
    abstract protected void SucessfulAction();
}
