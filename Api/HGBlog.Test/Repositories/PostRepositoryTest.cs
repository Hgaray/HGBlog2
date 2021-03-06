using HGBlog.DataAccess;
using HGBlog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Diagnostics.CodeAnalysis;

namespace HGBlog.Test.Repositories
{
    [TestClass]
    public class PostRepositoryTest
    {

        [Fact]
        [Trait("tewst1", "test")]
        public async void test()
        {

            //Create In Memory Database
            var options = new DbContextOptionsBuilder<HGBlogDbContext>()
            .UseInMemoryDatabase(databaseName: "HGBlogDBTest")
            .Options;

            using (var ctx = new HGBlogDbContext(options))
            {


                

                ctx.Roles.Add(new Domain.Rol
                {
                    Id = 1,
                    Name = "writer"
                });


                ctx.Posts.Add(new Domain.Post
                {
                    Id = 1,
                    State = new Domain.State
                    {
                        Id = 1,
                        Name = "Approved"
                    },
                    User = new Domain.User
                    {
                        Id = 1,
                        RolId = 1
                    },
                    PostText = "text",
                    TitlePost = "title"

                });

                ctx.SaveChanges();



                var mockRepository = new PostRepository(ctx);

                var result = await mockRepository.GetAllPosts();

                Xunit.Assert.True(result.Any());

            }





        }
    }
}
