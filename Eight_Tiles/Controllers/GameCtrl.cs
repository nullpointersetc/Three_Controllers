using ApiController = Microsoft.AspNetCore.Mvc.ApiControllerAttribute;
using ContentResult = Microsoft.AspNetCore.Mvc.ContentResult;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;
using HttpGet = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using NotNull = System.Diagnostics.CodeAnalysis.NotNullAttribute;
using Route = Microsoft.AspNetCore.Mvc.RouteAttribute;
using StringBuilder = System.Text.StringBuilder;

#pragma warning disable IDE0130
namespace NullPointersEtc.Eight_Tiles.Controllers;

[type: ApiController, Route("eighttiles")]
public class GameController : ControllerBase
{
    [method: HttpGet, Route("index.html")]
    [return: NotNull]
    public ContentResult IndexDotHtml()
    {
        return this.GameDotHtml(
            1,2,3,
            4,5,6,
            0,7,8);
    }

    [method: HttpGet, Route("game.html")]
    [return: NotNull]
    public ContentResult GameDotHtml(
        int t11, int t12, int t13,
        int t21, int t22, int t23,
        int t31, int t32, int t33)
    {
        return new ContentResult
        {
            Content = new StringBuilder("<!DOCTYPE html>")
                .AppendLine()
                .AppendLine("<html>")
                .AppendLine("<head>")
                .AppendLine("<title>Eight-Tiles Game</title>")
                .AppendLine("<meta charset=\"UTF-8\">")
                .AppendLine("</head>")
                .AppendLine("<body>")
                .AppendLine("<h1>Eight-Tiles Game</h1>")
                .AppendLine("<table style=\"border: 1px solid;\">")
                .AppendLine("<tbody>")
                .AppendLine("<tr>")
                .Append("<td style=\"border: 1px solid;\">")
                .Append(t11).AppendLine("</td>")
                .Append("<td style=\"border: 1px solid;\">")
                .Append(t12).AppendLine("</td>")
                .Append("<td style=\"border: 1px solid;\">")
                .Append(t13).AppendLine("</td>")
                .AppendLine("</tr>")
                .AppendLine("<tr>")
                .Append("<td style=\"border: 1px solid;\">")
                .Append(t21).AppendLine("</td>")
                .Append("<td style=\"border: 1px solid;\">")
                .Append(t22).AppendLine("</td>")
                .Append("<td style=\"border: 1px solid;\">")
                .Append(t23).AppendLine("</td>")
                .AppendLine("</tr>")
                .AppendLine("<tr>")
                .Append("<td style=\"border: 1px solid;\">")
                .Append(t31).AppendLine("</td>")
                .Append("<td style=\"border: 1px solid;\">")
                .Append(t32).AppendLine("</td>")
                .Append("<td style=\"border: 1px solid;\">")
                .Append(t33).AppendLine("</td>")
                .AppendLine("</tr>")
                .AppendLine("</tbody>")
                .AppendLine("</table>")
                .AppendLine("</body>")
                .AppendLine("</html>").ToString(),
            ContentType = "text/html",
            StatusCode = 200
        };
    }
}
#pragma warning restore IDE0130
