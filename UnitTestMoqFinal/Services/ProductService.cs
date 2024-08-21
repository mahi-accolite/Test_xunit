using Newtonsoft.Json;
using System;
using UnitTestMoqFinal.Data;
using UnitTestMoqFinal.Models;

namespace UnitTestMoqFinal.Services
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass _dbContext;
        string url = "https://spotify-demo-api-fe224840a08c.herokuapp.com/v1/browse/featured-playlists";

        public ProductService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Product> GetProductList()
        {
            return _dbContext.Products.ToList();
        }
        public Product GetProductById(int id)
        {
            
            return _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public async Task<dynamic> MusicList()
        {
            string responseBody = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send a GET request to the API

                    HttpResponseMessage response = await client.GetAsync(url);

                    // Ensure the response is successful

                    response.EnsureSuccessStatusCode();

                    // Read the response content as a string

                     responseBody = await response.Content.ReadAsStringAsync();

                    // Output the response body to the console

                    Console.WriteLine(responseBody);

                }

                catch (HttpRequestException e)

                {

                    // Handle any errors that may have occurred

                    Console.WriteLine($"Request error: {e.Message}");
                    
                }

            }
            
            // Deserialize the JSON response using Newtonsoft.Json
            var featuredPlaylistsResponse = JsonConvert.DeserializeObject<FeaturedPlaylists>(responseBody);

            return featuredPlaylistsResponse;
        }
        private async Task<string> Music()
        {
            string responseBody = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send a GET request to the API

                    HttpResponseMessage response = await client.GetAsync(url);

                    // Ensure the response is successful

                    response.EnsureSuccessStatusCode();

                    // Read the response content as a string

                    responseBody = await response.Content.ReadAsStringAsync();

                    // Output the response body to the console

                    Console.WriteLine(responseBody);

                }

                catch (HttpRequestException e)

                {

                    // Handle any errors that may have occurred

                    Console.WriteLine($"Request error: {e.Message}");
                    return null;
                }

            }
            return responseBody;

        }

        public Product AddProduct(Product product)
        
        {
            var result = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteProduct(int Id)
        {
            var filteredData = _dbContext.Products.Where(x => x.ProductId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
  
    }


    public class FeaturedPlaylists

    {

        [JsonProperty("message")]

        public string Message { get; set; }

        [JsonProperty("playlists")]

        public Playlists Playlists { get; set; }

    }

    public class Playlists

    {

        [JsonProperty("items")]

        public List<Playlist> Items { get; set; }

    }

    public class Playlist

    {

        [JsonProperty("collaborative")]

        public bool Collaborative { get; set; }

        [JsonProperty("description")]

        public string Description { get; set; }

        [JsonProperty("external_urls")]

        public ExternalUrls ExternalUrls { get; set; }

        [JsonProperty("href")]

        public string Href { get; set; }

        [JsonProperty("id")]

        public string Id { get; set; }

        [JsonProperty("images")]

        public List<Image> Images { get; set; }

        [JsonProperty("name")]

        public string Name { get; set; }

        [JsonProperty("owner")]

        public Owner Owner { get; set; }

        [JsonProperty("public")]

        public bool Public { get; set; }

        [JsonProperty("snapshot_id")]

        public string SnapshotId { get; set; }

        [JsonProperty("tracks")]

        public Tracks Tracks { get; set; }

        [JsonProperty("type")]

        public string Type { get; set; }

        [JsonProperty("uri")]

        public string Uri { get; set; }

    }

    public class ExternalUrls

    {

        [JsonProperty("spotify")]

        public string Spotify { get; set; }

    }

    public class Image

    {

        [JsonProperty("height")]

        public int Height { get; set; }

        [JsonProperty("url")]

        public string Url { get; set; }

        [JsonProperty("width")]

        public int Width { get; set; }

    }

    public class Owner

    {

        [JsonProperty("display_name")]

        public string DisplayName { get; set; }

        [JsonProperty("external_urls")]

        public ExternalUrls ExternalUrls { get; set; }

        [JsonProperty("followers")]

        public Followers Followers { get; set; }

        [JsonProperty("href")]

        public string Href { get; set; }

        [JsonProperty("id")]

        public string Id { get; set; }

        [JsonProperty("type")]

        public string Type { get; set; }

        [JsonProperty("uri")]

        public string Uri { get; set; }

    }

    public class Followers

    {

        [JsonProperty("href")]

        public string Href { get; set; }

        [JsonProperty("total")]

        public int Total { get; set; }

    }

    public class Tracks

    {

        [JsonProperty("href")]

        public string Href { get; set; }

        [JsonProperty("total")]

        public int Total { get; set; }

    }
    //public class FeaturedPlaylistsResponse
    //{
    //    public string Message { get; set; }
    //    public Playlists Playlists { get; set; }
    //}

    //public class Playlists
    //{
    //    public List<Playlist> Items { get; set; }
    //    public int Limit { get; set; }
    //    public string Href { get; set; }
    //    public object Next { get; set; }
    //    public int Offset { get; set; }
    //    public object Previous { get; set; }
    //    public int Total { get; set; }
    //}

    //public class Playlist
    //{
    //    public bool Collaborative { get; set; }
    //    public string Description { get; set; }
    //    public ExternalUrls ExternalUrls { get; set; }
    //    public string Href { get; set; }
    //    public string Id { get; set; }
    //    public List<Image> Images { get; set; }
    //    public string Name { get; set; }
    //    public Owner Owner { get; set; }
    //    public bool Public { get; set; }
    //    public string SnapshotId { get; set; }
    //    public Tracks Tracks { get; set; }
    //    public string Type { get; set; }
    //    public string Uri { get; set; }
    //}

    //public class ExternalUrls
    //{
    //    public string Spotify { get; set; }
    //}

    //public class Image
    //{
    //    public int Height { get; set; }
    //    public string Url { get; set; }
    //    public int Width { get; set; }
    //}

    //public class Owner
    //{
    //    public string DisplayName { get; set; }
    //    public ExternalUrls ExternalUrls { get; set; }
    //    public Followers Followers { get; set; }
    //    public List<Image> Images { get; set; }
    //    public string Href { get; set; }
    //    public string Id { get; set; }
    //    public string Type { get; set; }
    //    public string Uri { get; set; }
    //}

    //public class Followers
    //{
    //    public object Href { get; set; }
    //    public int Total { get; set; }
    //}

    //public class Tracks
    //{
    //    public string Href { get; set; }
    //    public int Total { get; set; }
    //}
}
