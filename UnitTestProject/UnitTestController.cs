using Microsoft.AspNetCore.Authentication;
using Moq;
using Newtonsoft.Json;
using UnitTestMoqFinal.Controllers;
using UnitTestMoqFinal.Data;
using UnitTestMoqFinal.Models;
using UnitTestMoqFinal.Services;

namespace UnitTestProject
{
    public class UnitTestController
    {
        private readonly Mock<IProductService> productService;
        public UnitTestController()
        {
            productService = new Mock<IProductService>();
        }

        [Fact]
        public void GetProductList_ProductList()
        {
            //arrange
            var productList = GetProductsData();
            productService.Setup(x => x.GetProductList())
                .Returns(productList);
            var productController = new ProductController(productService.Object);

            //act
            var productResult = productController.ProductList();

            //assert
            Assert.NotNull(productResult);
            Assert.Equal(GetProductsData().Count(), productResult.Count());
            Assert.Equal(GetProductsData().ToString(), productResult.ToString());
            Assert.True(productList.Equals(productResult));
        }

        [Fact]
        public void GetProductByID_Product()
        {
            //arrange
            var productList = GetProductsData();
            productService.Setup(x => x.GetProductById(2))
                .Returns(productList[1]);
            var productController = new ProductController(productService.Object);

            //act
            var productResult = productController.GetProductById(2);

            //assert
            Assert.NotNull(productResult);
            Assert.Equal(productList[1].ProductId, productResult.Result.ProductId);
            Assert.True(productList[1].ProductId == productResult.Result.ProductId);
        }

        [Theory]
        [InlineData("IPhone")]
        public void CheckProductExistOrNotByProductName_Product(string productName)
        {
            //arrange
            var productList = GetProductsData();
            productService.Setup(x => x.GetProductList())
                .Returns(productList);
            var productController = new ProductController(productService.Object);

            //act
            var productResult = productController.ProductList();
            var expectedProductName = productResult.ToList()[0].ProductName;

            //assert
            Assert.Equal(productName, expectedProductName);

        }


        [Fact]
        public void AddProduct_Product()
        {
            //arrange
            var productList = GetProductsData();
            productService.Setup(x => x.AddProduct(productList[2]))
                .Returns(productList[2]);
            var productController = new ProductController(productService.Object);

            //act
            var productResult = productController.AddProduct(productList[2]);

            //assert
            Assert.NotNull(productResult);
            Assert.Equal(productList[2].ProductId, productResult.ProductId);
            Assert.True(productList[2].ProductId == productResult.ProductId);
        }

        [Fact]
        public void GetMusicList()
        {
            //arrange
            var playlist = MusicListData();
            productService.Setup(x => x.MusicList().Result)
                .Returns(playlist);
            var productController = new ProductController(productService.Object);

            //act
            var productResult = productController.MusicMatcher();

            //assert
            Assert.NotNull(productResult);
            Assert.Equal(playlist, productResult.Result);
            Assert.True(playlist == productResult.Result);
        }


        private dynamic MusicListData()
        {
            var playlists = new FeaturedPlaylists

            {

                Message = "Featured playlists",

                Playlists = new Playlists

                {

                    Items = new List<Playlist>

                {

                    new Playlist

                    {

                        Collaborative = false,

                        Description = "Tooth-achingly sweet beats for your sweet eats",

                        ExternalUrls = new ExternalUrls

                        {

                            Spotify = "https://open.spotify.com/playlist/6Fl8d6KF0O4V5kFdbzalfW"

                        },

                        Href = "https://api.spotify.com/v1/playlists/6Fl8d6KF0O4V5kFdbzalfW",

                        Id = "6Fl8d6KF0O4V5kFdbzalfW",

                        Images = new List<Image>

                        {

                            new Image

                            {

                                Height = 640,

                                Url = "https://mosaic.scdn.co/640/ab67616d0000b27306b42768ebe736eec21336eaab67616d0000b27343511b8c20112757edddc7baab67616d0000b27355ef4cc7e56a02c68c3abc0fab67616d0000b273bd2feaef7519dbfbc402201e",

                                Width = 640

                            },

                            new Image

                            {

                                Height = 300,

                                Url = "https://mosaic.scdn.co/300/ab67616d0000b27306b42768ebe736eec21336eaab67616d0000b27343511b8c20112757edddc7baab67616d0000b27355ef4cc7e56a02c68c3abc0fab67616d0000b273bd2feaef7519dbfbc402201e",

                                Width = 300

                            },

                            new Image

                            {

                                Height = 60,

                                Url = "https://mosaic.scdn.co/60/ab67616d0000b27306b42768ebe736eec21336eaab67616d0000b27343511b8c20112757edddc7baab67616d0000b27355ef4cc7e56a02c68c3abc0fab67616d0000b273bd2feaef7519dbfbc402201e",

                                Width = 60

                            }

                        },

                        Name = "Sweet Beats & Eats",

                        Owner = new Owner

                        {

                            DisplayName = "Odyssey Learner",

                            ExternalUrls = new ExternalUrls

                            {

                                Spotify = "https://open.spotify.com/user/31ec74sabsbxkw7oiwnoalq2r6bm"

                            },

                            Followers = new Followers

                            {

                                Href = null,

                                Total = 100

                            },

                            Href = "https://api.spotify.com/v1/users/31ec74sabsbxkw7oiwnoalq2r6bm",

                            Id = "31ec74sabsbxkw7oiwnoalq2r6bm",

                            Type = "user",

                            Uri = "spotify:user:31ec74sabsbxkw7oiwnoalq2r6bm"

                        },

                        Public = true,

                        SnapshotId = "MTEsMTNhZGExNjkwN2I4YzgzOTBmNWE3ZjUyNDFjOGIwNzUwMjk3YjdmMw==",

                        Tracks = new Tracks

                        {

                            Href = "https://api.spotify.com/v1/playlists/6Fl8d6KF0O4V5kFdbzalfW/tracks?offset=0&limit=100&locale=en-US,en;q=0.9",

                            Total = 5

                        },

                        Type = "playlist",

                        Uri = "spotify:playlist:6Fl8d6KF0O4V5kFdbzalfW"

                    },

                    // Add other Playlist instances here

                }

                }

            };

            return playlists; 
        }


        private List<Product> GetProductsData()
        {
            List<Product> productsData = new List<Product>
        {
            new Product
            {
                ProductId = 1,
                ProductName = "IPhone",
                ProductDescription = "IPhone 12",
                ProductPrice = 55000,
                ProductStock = 10
            },
             new Product
            {
                ProductId = 2,
                ProductName = "Laptop",
                ProductDescription = "HP Pavilion",
                ProductPrice = 100000,
                ProductStock = 20
            },
             new Product
            {
                ProductId = 3,
                ProductName = "TV",
                ProductDescription = "Samsung Smart TV",
                ProductPrice = 35000,
                ProductStock = 30
            },
        };
            return productsData;
        }
    }
}
