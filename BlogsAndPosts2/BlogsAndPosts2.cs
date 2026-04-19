using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using DbContextOptionsBuilder =
Microsoft.EntityFrameworkCore.DbContextOptionsBuilder;
using SqliteDbCtxOptBuildExt =
Microsoft.EntityFrameworkCore.SqliteDbContextOptionsBuilderExtensions;
using ListOfPosts = System.Collections.Generic.List<
    NullPointersEtc.BlogsAndPosts2.Post>;
using DbSetOfBlogs = Microsoft.EntityFrameworkCore.DbSet<NullPointersEtc.BlogsAndPosts2.Blog>;
using DbSetOfPosts = Microsoft.EntityFrameworkCore.DbSet<NullPointersEtc.BlogsAndPosts2.Post>;
using AllowNull = System.Diagnostics.CodeAnalysis.AllowNullAttribute;
using DisallowNull = System.Diagnostics.CodeAnalysis.DisallowNullAttribute;
using NotNull = System.Diagnostics.CodeAnalysis.NotNullAttribute;
using ArgumentNullException = System.ArgumentNullException;
using NullReferenceException = System.NullReferenceException;
using Key = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace NullPointersEtc.BlogsAndPosts2;

public static class BlogsAndPosts2
{
    public static void Main()
    {
    }

    public static void F1() { }

    public static async Task F2()
    {
        using var db = new BloggingContext();

        var blogs = db.Blogs.Where(b => b.Rating > 3).OrderBy(b => b.Rating).ToList();
    }
}

public class BloggingContext : DbContext
{
    protected override void OnConfiguring(
        DbContextOptionsBuilder builder)
    {
        SqliteDbCtxOptBuildExt.UseSqlite(
            builder, "Data Source=blogging.db");
    }

    [NotNull, DisallowNull]
    public DbSetOfBlogs Blogs
    {
        get => myBlogs ??
            throw new NullReferenceException(nameof(Blogs));

        set => myBlogs = value ??
            throw new ArgumentNullException(nameof(Blogs));
    }

    [NotNull, DisallowNull]
    public DbSetOfPosts Posts
    {
        get => myPosts ??
            throw new NullReferenceException(nameof(Posts));

        set => myPosts = value ??
            throw new ArgumentNullException(nameof(Posts));
    }

    [AllowNull]
    private DbSetOfBlogs myBlogs;

    [AllowNull]
    private DbSetOfPosts myPosts;
}

public class Blog
{
    [Key]
    public int BlogId
    {
        get => myBlogId ?? throw new NullReferenceException(nameof(BlogId));
        set => myBlogId = value;
    }

    private int? myBlogId = null;

    public string Url
    {
        get => myUrl ?? throw new NullReferenceException(nameof(Url));
        set => myUrl = value ?? throw new ArgumentNullException(nameof(Url));
    }

    private string? myUrl;

    public int Rating
    {
        get => myRating ?? throw new NullReferenceException(nameof(Rating));
        set => myRating = value < 0 ? throw new ArgumentException(nameof(Rating))
            : value > 5 ? throw new ArgumentException(nameof(Rating))
            : value;
    }

    private int? myRating;

    public ListOfPosts Posts
    {
        get => myPosts;
        set => myPosts = value ?? throw new ArgumentNullException(nameof(Posts));
    }

    private ListOfPosts myPosts=new ();

}

public class Post
{
    [Key]
    public int PostId
    {
        get => myPostId ?? throw new NullReferenceException(nameof(PostId));
        set => myPostId = value;
    }

    private int? myPostId = null;

    public string Title
    {
        get => myTitle ?? throw new NullReferenceException(nameof(Title));
        set => myTitle = value ?? throw new ArgumentNullException(nameof(Title));
    }

    private string? myTitle = null;

    public string Content
    {
        get => myContent ?? throw new NullReferenceException(nameof(Content));
        set => myContent = value ?? throw new ArgumentNullException(nameof(Content));
    }

    private string? myContent = null;
}

