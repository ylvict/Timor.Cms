using System;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Repository.MongoDb.Articles;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.Tests.Articles
{
    public class GetArticleByIdTests
    {
        [Fact]
        public async Task ShouldGetArticleSuccess()
        {
            var mockProvider = new Mock<IMongoCollectionProvider>();
            var mockCollection = new Mock<IMongoCollection<Article>>();

            mockCollection.Setup(x => x.FindAsync(It.IsAny<FilterDefinition<Article>>(), default(FindOptions<Article, Article>), default(CancellationToken)))
                .Returns(Task.FromResult(new Mock<IAsyncCursor<Article>>().Object));
            mockProvider.Setup(x => x.GetCollection<Article>("article"))
                .Returns(mockCollection.Object);

            var repository = new ArticleRepository(mockProvider.Object);

            var article = new Article
            {
                Title = Guid.NewGuid().ToString()
            };

            await repository.InsertAsync(article);

            var result = await repository.GetById(article.Id);

            Assert.Equal(article.Title, result.Title);
        }

        [Fact]
        public async Task ShouldReturnNullWhenIdNotExist()
        {
            var mockProvider = new Mock<IMongoCollectionProvider>();
            mockProvider.Setup(x => x.GetCollection<Article>("article")).Returns(new Mock<IMongoCollection<Article>>().Object);
            var repository = new ArticleRepository(mockProvider.Object);

            var result = await repository.GetById(ObjectId.GenerateNewId());

            Assert.Null(result);
        }
    }
}
