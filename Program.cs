
using System;
using System.Net;
using SpotifyAPI.Web;
using Settings;

namespace WordleClone
{
    public class Program
    {

        public static async Task Main()
        {

            var config = SpotifyClientConfig.CreateDefault().WithAuthenticator(new ClientCredentialsAuthenticator(Settings.Configs.clientId, Settings.Configs.cliendSecret));

            var spotify = new SpotifyClient(config);
            var artist = await spotify.Artists.Get("53XhwfbYqKCa1cC15pYq2q"); // The Beatles
            var albums = await spotify.Artists.GetAlbums(artist.Id);
            // get Random Album 
            var randomAlbum = albums.Items[new Random().Next(0, albums.Items.Count)];
            var randomTracks = await spotify.Albums.GetTracks(randomAlbum.Id);
            var randomTrack = randomTracks.Items[new Random().Next(0, randomTracks.Items.Count)];
            // get track from specific album


            System.Console.WriteLine(randomAlbum.Name);
            System.Console.WriteLine(randomTrack.Name);
            System.Console.WriteLine(artist.Name);

            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~");
            // Console.WriteLine(track.Name);


            // for (int i = 0; i < albums.Items.Count; i++)
            // {
            //     System.Console.WriteLine(albums.Items[i].Name);
            // }





            string pool = "  afforest aftermath be on cloud nine becalm blithesome broadsheet buffoonish caprice capricious causerie chivalrous congratulatory dapper debonaire devil may care emblazon eudaemonia extremum exultant featherbrained felicity fiddlefaddle gabble gallant gilt gleeful halcyon happygolucky heyday hotheaded indefinite quantity ism madcap majestic merry andrew natty nobleminded nuance phantasy pollyannaish prate salad days sappy snappy soda pop spiffy stunner timberland timbre tittletattle twaddle vividness wearisome whimsical whimsy zippy";
            //convert pool to String List seperated by spaces
            var poolList = pool.Split(' ');





            var game = new GameLoop(randomTrack.Name);
            game.Start();
            game.Play();

        }

        static String RandomWord(String[] stringPool)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, stringPool.Length);
            return stringPool[randomIndex];
        }
    }
}