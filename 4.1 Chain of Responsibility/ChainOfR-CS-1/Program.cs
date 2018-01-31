namespace ChainOfR_CS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string link1 = "https://vimeo.com/channels/staffpicks/212731897";
            string link2 = "https://www.youtube.com/watch?v=AAW9ktEOKJ0";
            string link3 = "http://www.oodesign.com/chain-of-responsibility-pattern.html";

            var fbDownloader = new FacebookPublicVideoHandler();
            var vimeoDownloader = new VimeoVideoHandler(fbDownloader);
            var mainDownloader = new YoutubeVideoHandler(vimeoDownloader);

            mainDownloader.ProcessRequest(link1);
            mainDownloader.ProcessRequest(link2);
            mainDownloader.ProcessRequest(link3);

        }
    }
}
